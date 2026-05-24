namespace model;

public class UsuarioModel
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime DataCadastro { get; set; }
    public string TipoUsuario { get; set; }
    public string Status { get; set; }
}
