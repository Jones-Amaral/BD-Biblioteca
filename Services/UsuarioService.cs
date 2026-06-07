using System.Security.Cryptography;
using System.Threading.Tasks;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<bool> RegistrarAsync(UsuarioModel usuario, string senha)
    {
        if (usuario == null || string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Nome))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
        {
            return false;
        }

        var usuarioExistente = await _usuarioRepository.GetByEmailAsync(usuario.Email);
        if (usuarioExistente != null)
        {
            return false;
        }

        usuario.SenhaHash = GerarHashSenha(senha);
        return await _usuarioRepository.AddAsync(usuario);
    }

    public async Task<bool> AutenticarAsync(string email, string senha)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
        {
            return false;
        }

        var usuario = await _usuarioRepository.GetByEmailAsync(email);
        if (usuario == null)
        {
            return false;
        }

        if (!usuario.Status.Equals("Ativo", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return ValidarSenha(senha, usuario.SenhaHash);
    }

    private static string GerarHashSenha(string senha)
    {
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        using var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 100000, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(32);
        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
    }

    private static bool ValidarSenha(string senha, string senhaHash)
    {
        if (string.IsNullOrWhiteSpace(senhaHash))
        {
            return false;
        }

        if (!senhaHash.Contains(':'))
        {
            return senha == senhaHash;
        }

        var partes = senhaHash.Split(':');
        if (partes.Length != 2)
        {
            return false;
        }

        var salt = Convert.FromBase64String(partes[0]);
        var hashEsperado = Convert.FromBase64String(partes[1]);

        using var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 100000, HashAlgorithmName.SHA256);
        var hashComparado = pbkdf2.GetBytes(hashEsperado.Length);

        return CryptographicOperations.FixedTimeEquals(hashComparado, hashEsperado);
    }

    public async Task<bool> AlterarSenhaAsync(string email, string senhaAtual, string novaSenha)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senhaAtual) || string.IsNullOrWhiteSpace(novaSenha))
        {
            return false;
        }

        if (novaSenha.Length < 6)
        {
            return false;
        }

        // Autentica primeiro com a senha atual
        var autenticado = await AutenticarAsync(email, senhaAtual);
        if (!autenticado)
        {
            return false;
        }

        var novoHash = GerarHashSenha(novaSenha);
        return await _usuarioRepository.UpdateSenhaAsync(email, novoHash);
    }
}
