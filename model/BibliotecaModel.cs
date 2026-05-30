namespace SistemaBibliotecario.Model;

public class BibliotecaModel
{
    public int ID { get; set; }
    public required string Nome { get; set; }
    public required string Endereco { get; set; }
    public required string Telefone { get; set; }

    public BibliotecaModel(string nome, string endereco, string telefone)
    {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
    }
}
