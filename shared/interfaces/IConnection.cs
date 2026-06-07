namespace Sahred.Interfaces;

public interface IConnection
{
    public static void Inicializar(IConfiguration config);
    public static Boolean AbrirConexao();
    public static Boolean FecharConexao();
    public static MySqlConnection getConexao();
}