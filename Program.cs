using SistemaBibliotecario.Shared;
using Microsoft.Extensions.Configuration;
using SistemaBibliotecario.Shared.Interfaces;
using System.Threading.Tasks;

namespace SistemaBibliotecario;

class Program
{
    private readonly IConsulta _consulta;
    public Program(IConsulta consulta)
    {
        _consulta = consulta;
    }
    static async Task Main()
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

        await _consulta.ConsultarLivrosAsync();
        Console.Readkey();
    }
}