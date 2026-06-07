using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace SistemaBibliotecario.Interfaces.Infrastructure;

public interface IConnection
{
    void Inicializar(IConfiguration config);
    bool AbrirConexao();
    bool FecharConexao();
    MySqlConnection GetConexao();
}
