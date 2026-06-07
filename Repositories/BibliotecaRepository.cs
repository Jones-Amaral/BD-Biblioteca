using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Repositories;

public class BibliotecaRepository : IBibliotecaRepository
{
    private readonly IConnection _connection;

    public BibliotecaRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AddAsync(BibliotecaModel biblioteca)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            INSERT INTO Bibliotecas (
                Nome,
                Endereco,
                Telefone
            ) VALUES (
                @Nome,
                @Endereco,
                @Telefone
            );";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@Nome", biblioteca.Nome);
        cmd.Parameters.AddWithValue("@Endereco", biblioteca.Endereco);
        cmd.Parameters.AddWithValue("@Telefone", biblioteca.Telefone);

        var rowsAffected = await cmd.ExecuteNonQueryAsync();
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<BibliotecaModel>> GetAllAsync()
    {
        var bibliotecas = new List<BibliotecaModel>();
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            SELECT ID,
                   Nome,
                   Endereco,
                   Telefone
            FROM Bibliotecas";

        cmd.CommandText = sql;
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            bibliotecas.Add(new BibliotecaModel(
                reader["Nome"]?.ToString() ?? string.Empty,
                reader["Endereco"]?.ToString() ?? string.Empty,
                reader["Telefone"]?.ToString() ?? string.Empty)
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID"))
            });
        }

        return bibliotecas;
    }
}
