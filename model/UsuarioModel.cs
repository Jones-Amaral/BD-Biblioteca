namespace SistemaBibliotecario.Model;

public class UsuarioModel
{
    public int ID { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public DateTime DataCadastro { get; set; }
    public required string TipoUsuario { get; set; }
    public required string Status { get; set; }

    public UsuarioModel()
    {
    }

    public UsuarioModel(string nome, string email, string telefone, DateTime dataCadastro, string tipoUsuario, string status)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        DataCadastro = dataCadastro;
        TipoUsuario = tipoUsuario;
        Status = status;
    }
}
