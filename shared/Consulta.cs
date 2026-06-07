using SistemaBibliotecario.Shared;

namespace SistemaBibliotecario.Shared;

public class Consulta 
{
    private readonly IConnection _connection;

    public Consulta(IConnection connection)
    {
        _connection = connection;
    }

    public async Task ConsultarLivrosAsync() 
    {
        MySqlConnection connection = _connection.getConnection();
        string query = "SELECT * FROM livros";

        connection.Open();

        connection.QueryAsync(query).ContinueWith(task => 
        {
            if (task.IsFaulted) 
            {
                Console.WriteLine("Erro ao consultar livros: " + task.Exception?.Message);
            } 
            else 
            {
                var livros = task.Result;
                foreach (var livro in livros) 
                {
                    Console.WriteLine($"ID: {livro.Id}, Título: {livro.Titulo}, Autor: {livro.Autor}");
                }
            }
        }).Wait();
    }
}