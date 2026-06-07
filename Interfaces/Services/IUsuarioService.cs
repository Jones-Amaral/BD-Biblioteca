using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Services;

public interface IUsuarioService
{
    Task<bool> RegistrarAsync(UsuarioModel usuario, string senha);
    Task<bool> AutenticarAsync(string email, string senha);
    Task<bool> AlterarSenhaAsync(string email, string senhaAtual, string novaSenha);
}
