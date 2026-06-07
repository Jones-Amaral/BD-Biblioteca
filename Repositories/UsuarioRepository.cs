using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IConnection _connection;

    public UsuarioRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AddAsync(UsuarioModel usuario)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();

            var sql = @"
                INSERT INTO Usuario (
                    Nome,
                    Email,
                    Telefone,
                    DataCadastro,
                    TipoUsuario,
                    Status
                ) VALUES (
                    @Nome,
                    @Email,
                    @Telefone,
                    @DataCadastro,
                    @TipoUsuario,
                    @Status
                );";

            cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
        cmd.Parameters.AddWithValue("@Status", usuario.Status);

        try
        {
            var rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no repositório de usuário: {ex.Message}");
            return false;
        }
    }
}
