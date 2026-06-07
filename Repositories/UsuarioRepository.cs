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
                    Status,
                    senhaHash
                ) VALUES (
                    @Nome,
                    @Email,
                    @Telefone,
                    @DataCadastro,
                    @TipoUsuario,
                    @Status,
                    @SenhaHash
                );";

        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
        cmd.Parameters.AddWithValue("@Email", usuario.Email);
        cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
        cmd.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);
        cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
        cmd.Parameters.AddWithValue("@Status", usuario.Status);
        cmd.Parameters.AddWithValue("@SenhaHash", usuario.SenhaHash);

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

    public async Task<UsuarioModel?> GetByEmailAsync(string email)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
                SELECT
                    ID,
                    Nome,
                    Email,
                    Telefone,
                    DataCadastro,
                    TipoUsuario,
                    Status,
                    SenhaHash
                FROM Usuario
                WHERE Email = @Email
                LIMIT 1;";
        cmd.Parameters.AddWithValue("@Email", email);

        using var reader = await cmd.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return new UsuarioModel
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID")),
            Nome = reader.GetString(reader.GetOrdinal("Nome")),
            Email = reader.GetString(reader.GetOrdinal("Email")),
            Telefone = reader.GetString(reader.GetOrdinal("Telefone")),
            DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
            TipoUsuario = reader.GetString(reader.GetOrdinal("TipoUsuario")),
            Status = reader.GetString(reader.GetOrdinal("Status")),
            SenhaHash = reader.GetString(reader.GetOrdinal("SenhaHash"))
        };
    }

    public async Task<bool> UpdateSenhaAsync(string email, string senhaHash)
    {
        var conn = _connection.GetConexao();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
                UPDATE Usuario
                SET SenhaHash = @SenhaHash
                WHERE Email = @Email;";
        cmd.Parameters.AddWithValue("@SenhaHash", senhaHash);
        cmd.Parameters.AddWithValue("@Email", email);

        try
        {
            var rows = await cmd.ExecuteNonQueryAsync();
            return rows > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar senha no repositório de usuário: {ex.Message}");
            return false;
        }
    }
}
