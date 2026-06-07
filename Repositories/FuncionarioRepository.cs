using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly IConnection _connection;

    public FuncionarioRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AddAsync(FuncionarioModel funcionario)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            INSERT INTO Funcionario (
                Nome,
                Cargo,
                Salario,
                DataContratacao
            ) VALUES (
                @Nome,
                @Cargo,
                @Salario,
                @DataContratacao
            );";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
        cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
        cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
        cmd.Parameters.AddWithValue("@DataContratacao", funcionario.DataContratacao);

        var rowsAffected = await cmd.ExecuteNonQueryAsync();
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<FuncionarioModel>> GetAllAsync()
    {
        var funcionarios = new List<FuncionarioModel>();
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            SELECT ID,
                   Nome,
                   Cargo,
                   Salario,
                   DataContratacao
            FROM Funcionario";

        cmd.CommandText = sql;
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            funcionarios.Add(new FuncionarioModel(
                reader["Nome"]?.ToString() ?? string.Empty,
                reader["Cargo"]?.ToString() ?? string.Empty,
                reader.GetDecimal(reader.GetOrdinal("Salario")),
                reader.GetDateTime(reader.GetOrdinal("DataContratacao")))
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID"))
            });
        }

        return funcionarios;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

        var sql = @"
            DELETE FROM Funcionario
            WHERE ID = @ID";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@ID", id);

        var rowsAffected = await cmd.ExecuteNonQueryAsync();
        return rowsAffected > 0;
    }
}
