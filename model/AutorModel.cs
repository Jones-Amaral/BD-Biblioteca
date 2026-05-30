namespace SistemaBibliotecario.Model;

public class AutorModel
{
    public int ID { get; set; }
    public required string Nome { get; set; }
    public required string Nacionalidade { get; set; }

    public AutorModel(string nome, string nacionalidade)
    {
        Nome = nome;
        Nacionalidade = nacionalidade;
    }
}
