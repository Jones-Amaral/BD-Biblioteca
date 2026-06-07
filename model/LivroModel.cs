namespace SistemaBibliotecario.Model;

public class LivroModel
{
    public int ID { get; set; }
    public required string Titulo { get; set; }
    public required string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public required string Editora { get; set; }

    public LivroModel()
    {
        Titulo = string.Empty;
        Autor = string.Empty;
        Editora = string.Empty;
    }

    public LivroModel(string titulo, string autor, int anoPublicacao, string editora)
    {
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
        Editora = editora;
    }
}
