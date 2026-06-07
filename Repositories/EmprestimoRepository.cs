using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Repositories;

public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly IConnection _connection;

    public EmprestimoRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AddAsync(EmprestimoModel emprestimo)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

            var sql = @"
                INSERT INTO Emprestimo (
                    ExemplarID,
                    DataEmprestimo,
                    DataDevolucao,
                    Disponivel,
                    Multa
                ) VALUES (
                    @ExemplarID,
                    @DataEmprestimo,
                    @DataDevolucao,
                    @Disponivel,
                    @Multa
                );";

            cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@Multa", emprestimo.Multa);

        try
        {
            var rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no repositório de empréstimo: {ex.Message}");
            return false;
        }
    }
}
