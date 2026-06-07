using SistemaBibliotecario.Infrastructure;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Repositories;
using SistemaBibliotecario.Services;
using SistemaBibliotecario.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBibliotecario;

class Program
{
    static async Task Main()
    {
        var basePath = AppContext.BaseDirectory;
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        IConnection connection = new Connection();
        connection.Inicializar(configuration);

        if (!connection.AbrirConexao())
        {
            Console.WriteLine("Falha ao abrir a conexão.");
            return;
        }

        try
        {
            await MostrarMenuAsync(connection);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro inesperado: " + ex.Message);
        }
        finally
        {
            connection.FecharConexao();
        }

        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para encerrar...");
        Console.ReadKey();
    }

    private static async Task MostrarMenuAsync(IConnection connection)
    {
        var livroService = new LivroService(new LivroRepository(connection));
        var autorService = new AutorService(new AutorRepository(connection));
        var bibliotecaService = new BibliotecaService(new BibliotecaRepository(connection));
        var funcionarioService = new FuncionarioService(new FuncionarioRepository(connection));
        var usuarioService = new UsuarioService(new UsuarioRepository(connection));
        var emprestimoService = new EmprestimoService(new EmprestimoRepository(connection));
        var consultaService = new ConsultaService(new ConsultaRepository(connection));

        while (true)
        {
            Console.Clear();
            ExibirCabecalho();
            ExibirOpcoes();

            Console.Write("Digite a opção desejada: ");
            var opcao = Console.ReadLine()?.Trim();

            if (opcao == "14")
            {
                Console.WriteLine("Saindo do sistema. Obrigado!");
                break;
            }

            switch (opcao)
            {
                case "1":
                    await ExecutarRegistroLivroAsync(livroService);
                    break;
                case "2":
                    await ExecutarRegistroAutorAsync(autorService);
                    break;
                case "3":
                    await ExecutarRegistroBibliotecaAsync(bibliotecaService);
                    break;
                case "4":
                    await ExecutarRegistroFuncionarioAsync(funcionarioService);
                    break;
                case "5":
                    await ExecutarCadastroUsuarioAsync(usuarioService);
                    break;
                case "6":
                    await ExecutarConsultaLivrosAsync(livroService);
                    break;
                case "7":
                    await ExecutarConsultaAutoresAsync(autorService);
                    break;
                case "8":
                    await ExecutarConsultaBibliotecasAsync(bibliotecaService);
                    break;
                case "9":
                    await ExecutarConsultaFuncionariosAsync(funcionarioService);
                    break;
                case "10":
                    await ExecutarExcluirLivroAsync(livroService);
                    break;
                case "11":
                    await ExecutarExcluirFuncionarioAsync(funcionarioService);
                    break;
                case "12":
                    await ExecutarRegistroEmprestimoAsync(emprestimoService);
                    break;
                case "13":
                    await ExecutarMenuConsultasAsync(consultaService);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }
    }

    private static void ExibirCabecalho()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("  Biblioteca Acadêmica - Sistema Demo");
        Console.WriteLine("========================================");
        Console.WriteLine("Bem-vindo ao sistema de gerenciamento de biblioteca.");
        Console.WriteLine();
    }

    private static void ExibirOpcoes()
    {
        Console.WriteLine("1 - Registrar livro");
        Console.WriteLine("2 - Registrar autor");
        Console.WriteLine("3 - Registrar biblioteca");
        Console.WriteLine("4 - Registrar funcionário");
        Console.WriteLine("5 - Registrar usuário");
        Console.WriteLine("6 - Consultar livros");
        Console.WriteLine("7 - Consultar autores");
        Console.WriteLine("8 - Consultar bibliotecas");
        Console.WriteLine("9 - Consultar funcionários");
        Console.WriteLine("10 - Excluir livro");
        Console.WriteLine("11 - Excluir funcionário");
        Console.WriteLine("12 - Registrar empréstimo");
        Console.WriteLine("13 - Consultas SQL");
        Console.WriteLine("14 - Sair");
        Console.WriteLine();
    }

    private static async Task ExecutarConsultaLivrosAsync(LivroService livroService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Lista de livros ---");

        try
        {
            var livros = await livroService.ListarLivrosAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine($"ID: {livro.ID} | Título: {livro.Titulo} | Autor: {livro.Autor}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar livros: " + ex.Message);
        }
    }

    private static async Task ExecutarCadastroUsuarioAsync(UsuarioService usuarioService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Cadastro de usuário ---");

        Console.Write("Nome: ");
        var nome = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Email: ");
        var email = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Telefone: ");
        var telefone = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Tipo de usuário (Aluno/Professor): ");
        var tipoUsuario = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Status (Ativo/Inativo): ");
        var status = Console.ReadLine()?.Trim() ?? string.Empty;

        var usuario = new UsuarioModel
        {
            Nome = nome,
            Email = email,
            Telefone = telefone,
            DataCadastro = DateTime.Now,
            TipoUsuario = string.IsNullOrWhiteSpace(tipoUsuario) ? "Aluno" : tipoUsuario,
            Status = string.IsNullOrWhiteSpace(status) ? "Ativo" : status
        };

        var sucesso = await usuarioService.RegistrarAsync(usuario);
        Console.WriteLine(sucesso ? "Usuário cadastrado com sucesso." : "Falha ao cadastrar usuário.");
    }

    private static async Task ExecutarRegistroEmprestimoAsync(EmprestimoService emprestimoService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Registro de empréstimo ---");

        Console.Write("ID do exemplar: ");
        var exemplarInput = Console.ReadLine()?.Trim() ?? string.Empty;
        Console.Write("Data de devolução (DD/MM/YYYY): ");
        var devolucaoInput = Console.ReadLine()?.Trim() ?? string.Empty;

        if (!int.TryParse(exemplarInput, out var exemplarID) || exemplarID <= 0)
        {
            Console.WriteLine("ID do exemplar inválido.");
            return;
        }

        if (!DateTime.TryParseExact(devolucaoInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataDevolucao))
        {
            Console.WriteLine("Data de devolução inválida. Use o formato DD/MM/YYYY.");
            return;
        }

        var sucesso = await emprestimoService.RegistrarAsync(exemplarID, dataDevolucao);
        Console.WriteLine(sucesso ? "Empréstimo registrado com sucesso." : "Falha ao registrar empréstimo.");
    }

    private static async Task ExecutarRegistroLivroAsync(LivroService livroService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Registro de livro ---");

        Console.Write("Título: ");
        var titulo = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Autor: ");
        var autor = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Ano de publicação: ");
        var anoInput = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!int.TryParse(anoInput, out var anoPublicacao))
        {
            Console.WriteLine("Ano de publicação inválido.");
            return;
        }

        Console.Write("Editora: ");
        var editora = Console.ReadLine()?.Trim() ?? string.Empty;

        var livro = new LivroModel
        {
            Titulo = titulo,
            Autor = autor,
            AnoPublicacao = anoPublicacao,
            Editora = editora
        };

        var sucesso = await livroService.RegistrarAsync(livro);
        Console.WriteLine(sucesso ? "Livro registrado com sucesso." : "Falha ao registrar livro.");
    }

    private static async Task ExecutarRegistroAutorAsync(AutorService autorService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Registro de autor ---");

        Console.Write("Nome: ");
        var nome = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Nacionalidade: ");
        var nacionalidade = Console.ReadLine()?.Trim() ?? string.Empty;

        var autor = new AutorModel(nome, nacionalidade);
        var sucesso = await autorService.RegistrarAsync(autor);
        Console.WriteLine(sucesso ? "Autor registrado com sucesso." : "Falha ao registrar autor.");
    }

    private static async Task ExecutarRegistroBibliotecaAsync(BibliotecaService bibliotecaService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Registro de biblioteca ---");

        Console.Write("Nome: ");
        var nome = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Endereço: ");
        var endereco = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Telefone: ");
        var telefone = Console.ReadLine()?.Trim() ?? string.Empty;

        var biblioteca = new BibliotecaModel(nome, endereco, telefone);
        var sucesso = await bibliotecaService.RegistrarAsync(biblioteca);
        Console.WriteLine(sucesso ? "Biblioteca registrada com sucesso." : "Falha ao registrar biblioteca.");
    }

    private static async Task ExecutarRegistroFuncionarioAsync(FuncionarioService funcionarioService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Registro de funcionário ---");

        Console.Write("Nome: ");
        var nome = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Cargo: ");
        var cargo = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Salário: ");
        var salarioInput = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!decimal.TryParse(salarioInput, out var salario))
        {
            Console.WriteLine("Salário inválido.");
            return;
        }

        Console.Write("Data de contratação (DD/MM/YYYY): ");
        var dataInput = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!DateTime.TryParseExact(dataInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataContratacao))
        {
            Console.WriteLine("Data de contratação inválida. Use o formato DD/MM/YYYY.");
            return;
        }

        var funcionario = new FuncionarioModel(nome, cargo, salario, dataContratacao);
        var sucesso = await funcionarioService.RegistrarAsync(funcionario);
        Console.WriteLine(sucesso ? "Funcionário registrado com sucesso." : "Falha ao registrar funcionário.");
    }

    private static async Task ExecutarConsultaAutoresAsync(AutorService autorService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Lista de autores ---");

        try
        {
            var autores = await autorService.ListarAutoresAsync();
            foreach (var autor in autores)
            {
                Console.WriteLine($"ID: {autor.ID} | Nome: {autor.Nome} | Nacionalidade: {autor.Nacionalidade}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar autores: " + ex.Message);
        }
    }

    private static async Task ExecutarConsultaBibliotecasAsync(BibliotecaService bibliotecaService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Lista de bibliotecas ---");

        try
        {
            var bibliotecas = await bibliotecaService.ListarBibliotecasAsync();
            foreach (var biblioteca in bibliotecas)
            {
                Console.WriteLine($"ID: {biblioteca.ID} | Nome: {biblioteca.Nome} | Endereço: {biblioteca.Endereco} | Telefone: {biblioteca.Telefone}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar bibliotecas: " + ex.Message);
        }
    }

    private static async Task ExecutarConsultaFuncionariosAsync(FuncionarioService funcionarioService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Lista de funcionários ---");

        try
        {
            var funcionarios = await funcionarioService.ListarFuncionariosAsync();
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"ID: {funcionario.ID} | Nome: {funcionario.Nome} | Cargo: {funcionario.Cargo} | Salário: {funcionario.Salario:C} | Contratação: {funcionario.DataContratacao:dd/MM/yyyy}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar funcionários: " + ex.Message);
        }
    }

    private static async Task ExecutarExcluirLivroAsync(LivroService livroService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Excluir livro ---");

        Console.Write("ID do livro: ");
        var idInput = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!int.TryParse(idInput, out var id) || id <= 0)
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var sucesso = await livroService.ExcluirAsync(id);
        Console.WriteLine(sucesso ? "Livro excluído com sucesso." : "Falha ao excluir livro.");
    }

    private static async Task ExecutarExcluirFuncionarioAsync(FuncionarioService funcionarioService)
    {
        Console.WriteLine();
        Console.WriteLine("--- Excluir funcionário ---");

        Console.Write("ID do funcionário: ");
        var idInput = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!int.TryParse(idInput, out var id) || id <= 0)
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var sucesso = await funcionarioService.ExcluirAsync(id);
        Console.WriteLine(sucesso ? "Funcionário excluído com sucesso." : "Falha ao excluir funcionário.");
    }

    private static async Task ExecutarMenuConsultasAsync(IConsultaService consultaService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Menu de Consultas SQL ---");
            Console.WriteLine("1 - Livros com exemplares (JOINs)");
            Console.WriteLine("2 - Empréstimos com livro e biblioteca (JOINs)");
            Console.WriteLine("3 - Títulos de duas bibliotecas - UNION");
            Console.WriteLine("4 - Títulos em ambas bibliotecas - INTERSECT");
            Console.WriteLine("5 - Títulos de uma biblioteca que não existem na outra - EXCEPT");
            Console.WriteLine("6 - Total de exemplares por biblioteca (SUM + GROUP BY + HAVING)");
            Console.WriteLine("7 - Livros disponíveis por autor (COUNT + GROUP BY + HAVING)");
            Console.WriteLine("8 - Média de exemplares por biblioteca (AVG + GROUP BY + HAVING)");
            Console.WriteLine("9 - Multa máxima, mínima e média (MAX, MIN, AVG)");
            Console.WriteLine("0 - Voltar ao menu principal");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
            var opcao = Console.ReadLine()?.Trim();

            if (opcao == "0")
            {
                return;
            }

            try
            {
                switch (opcao)
                {
                    case "1":
                        await ExibirConsultaAsync("Livros com exemplares", consultaService.GetLivrosComExemplaresAsync());
                        break;
                    case "2":
                        await ExibirConsultaAsync("Empréstimos com livro e biblioteca", consultaService.GetEmprestimosComLivroEBibliotecaAsync());
                        break;
                    case "3":
                        await ExibirConsultaAsync("Títulos de duas bibliotecas - UNION", consultaService.GetTitulosDeDuasBibliotecasUnionAsync());
                        break;
                    case "4":
                        await ExibirConsultaAsync("Títulos em ambas bibliotecas - INTERSECT", consultaService.GetTitulosPresentesEmAmbasBibliotecasIntersectAsync());
                        break;
                    case "5":
                        await ExibirConsultaAsync("Títulos de uma biblioteca que não existem na outra - EXCEPT", consultaService.GetTitulosDeUmaBibliotecaNaoEmOutraAsync());
                        break;
                    case "6":
                        await ExibirConsultaAsync("Total de exemplares por biblioteca", consultaService.GetTotalExemplaresPorBibliotecaAsync());
                        break;
                    case "7":
                        await ExibirConsultaAsync("Livros disponíveis por autor", consultaService.GetLivrosDisponiveisPorAutorAsync());
                        break;
                    case "8":
                        await ExibirConsultaAsync("Média de exemplares por biblioteca", consultaService.GetMediaExemplaresPorBibliotecaAsync());
                        break;
                    case "9":
                        await ExibirConsultaAsync("Multa máxima, mínima e média", consultaService.GetMultasMaxMinMediaAsync());
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro durante a consulta: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    private static async Task ExibirConsultaAsync(string titulo, Task<IEnumerable<ConsultaResultadoModel>> consultaTask)
    {
        Console.WriteLine();
        Console.WriteLine($"--- {titulo} ---");

        var resultados = await consultaTask;
        if (!resultados.Any())
        {
            Console.WriteLine("Nenhum resultado encontrado.");
            return;
        }

        foreach (var linha in resultados)
        {
            var linhaFormatada = string.Join(" | ", linha.Valores.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
            Console.WriteLine(linhaFormatada);
        }
    }
}
