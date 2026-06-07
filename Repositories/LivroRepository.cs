using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly IConnection _connection;

    public LivroRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<LivroModel>> GetAllAsync()
    {
        var livros = new List<LivroModel>();
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            SELECT id,
                   titulo,
                   autor
            FROM Livro";

        cmd.CommandText = sql;

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            livros.Add(new LivroModel
            {
                ID = reader.GetInt32(reader.GetOrdinal("id")),
                Titulo = reader["titulo"]?.ToString() ?? string.Empty,
                Autor = reader["autor"]?.ToString() ?? string.Empty,
                Editora = string.Empty
            });
        }

        return livros;
    }

    public async Task<bool> AddAsync(LivroModel livro)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            INSERT INTO Livro (
                Titulo,
                Autor,
                AnoPublicacao,
                Editora
            ) VALUES (
                @Titulo,
                @Autor,
                @AnoPublicacao,
                @Editora
            );";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
        cmd.Parameters.AddWithValue("@Autor", livro.Autor);
        cmd.Parameters.AddWithValue("@AnoPublicacao", livro.AnoPublicacao);
        cmd.Parameters.AddWithValue("@Editora", livro.Editora);

        var rowsAffected = await cmd.ExecuteNonQueryAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            DELETE FROM Livro
            WHERE ID = @ID";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@ID", id);

        var rowsAffected = await cmd.ExecuteNonQueryAsync();
        return rowsAffected > 0;
    }
}
