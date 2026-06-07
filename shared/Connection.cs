using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace SistemaBibliotecario.Shared
{
    public class Connection : IConnection
    {
        private static MySqlConnection? conexao;
        private static IConfiguration? configuration;

        public static void Inicializar(IConfiguration config)
        {
            configuration = config;
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            conexao = new MySqlConnection(connectionString);
        }

        public static Boolean AbrirConexao()
        {
            try
            {
                conexao!.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao abrir conexão: " + ex.Message);
                return false;
            }
        }

        public static Boolean FecharConexao()
        {
            if (conexao!.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
                Console.WriteLine("Conexão fechada com sucesso!");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static MySqlConnection getConexao()
        {
            if (conexao == null)
            {
                throw new InvalidOperationException("Conexao não foi inicializada. Chame Conexao.Inicializar() primeiro.");
            }
            return conexao!;
        }
    }
}