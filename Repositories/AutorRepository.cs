using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly IConnection _connection;

    public AutorRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AddAsync(AutorModel autor)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            INSERT INTO Autor (
                Nome,
                Nacionalidade
            ) VALUES (
                @Nome,
                @Nacionalidade
            );";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@Nome", autor.Nome);
        cmd.Parameters.AddWithValue("@Nacionalidade", autor.Nacionalidade);

        var rowsAffected = await cmd.ExecuteNonQueryAsync();
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<AutorModel>> GetAllAsync()
    {
        var autores = new List<AutorModel>();
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            SELECT ID,
                   Nome,
                   Nacionalidade
            FROM Autor";

        cmd.CommandText = sql;
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            autores.Add(new AutorModel(
                reader["Nome"]?.ToString() ?? string.Empty,
                reader["Nacionalidade"]?.ToString() ?? string.Empty)
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID"))
            });
        }

        return autores;
    }
}
