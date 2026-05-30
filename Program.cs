using SistemaBibliotecario.Shared;
using Microsoft.Extensions.Configuration;

namespace SistemaBibliotecario;

class Program
{
    static void Main()
    {
        // Carregar configurações do appsettings.json
        var basePath = AppContext.BaseDirectory;
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Inicializar conexão com as configurações
        Conexao.Inicializar(configuration);

        // Teste de conexão
        bool conexaoAberta = Conexao.AbrirConexao();
        if (conexaoAberta)
        {
            Console.WriteLine("Conexão aberta com sucesso!");
            Conexao.FecharConexao();
        }
        else
        {
            Console.WriteLine("Falha ao abrir a conexão.");
        }
    }
}