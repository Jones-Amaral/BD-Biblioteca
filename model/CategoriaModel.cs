namespace SistemaBibliotecario.Model;

public class CategoriaModel
{
    public int ID { get; set; }
    public required string Nome { get; set; }

    public CategoriaModel(string nome)
    {
        Nome = nome;
    }
}
