using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaBibliotecario.Interfaces.Infrastructure;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Repositories;

public class ConsultaRepository : IConsultaRepository
{
    private readonly IConnection _connection;

    public ConsultaRepository(IConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetLivrosComExemplaresAsync()
    {
        // Query de JOIN entre Livro, Exemplar e Bibliotecas
        var sql = @"
            SELECT l.ID AS LivroID,
                   l.Titulo,
                   l.Autor,
                   e.ID AS ExemplarID,
                   e.Quantidade,
                   e.Disponivel,
                   b.Nome AS Biblioteca
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            JOIN Bibliotecas b ON e.BibliotecaID = b.ID";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetEmprestimosComLivroEBibliotecaAsync()
    {
        // Query de JOIN entre Emprestimo, Exemplar, Livro e Bibliotecas
        var sql = @"
            SELECT em.ID AS EmprestimoID,
                   l.Titulo,
                   b.Nome AS Biblioteca,
                   e.Situacao,
                   em.DataEmprestimo,
                   em.DataDevolucao,
                   em.Multa
            FROM Emprestimo em
            JOIN Exemplar e ON em.ExemplarID = e.ID
            JOIN Livro l ON e.LivroID = l.ID
            JOIN Bibliotecas b ON e.BibliotecaID = b.ID";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetTitulosDeDuasBibliotecasUnionAsync()
    {
        // Consulta de conjuntos usando UNION entre dois conjuntos de títulos de bibliotecas distintas
        var sql = @"
            SELECT l.Titulo
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            WHERE e.BibliotecaID = 1
            UNION
            SELECT l.Titulo
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            WHERE e.BibliotecaID = 2";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetTitulosPresentesEmAmbasBibliotecasIntersectAsync()
    {
        // Consulta de conjuntos usando INTERSECT para encontrar títulos presentes nas duas bibliotecas
        var sql = @"
            SELECT l.Titulo
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            WHERE e.BibliotecaID = 1
            INTERSECT
            SELECT l.Titulo
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            WHERE e.BibliotecaID = 2";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetTitulosDeUmaBibliotecaNaoEmOutraAsync()
    {
        // Consulta de conjuntos usando EXCEPT para encontrar títulos de Biblioteca 1 que não existem na Biblioteca 2
        var sql = @"
            SELECT l.Titulo
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            WHERE e.BibliotecaID = 1
            EXCEPT
            SELECT l.Titulo
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            WHERE e.BibliotecaID = 2";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetTotalExemplaresPorBibliotecaAsync()
    {
        // Consulta de agregação com SUM e GROUP BY para total de exemplares por biblioteca
        var sql = @"
            SELECT b.Nome AS Biblioteca,
                   SUM(e.Quantidade) AS TotalExemplares
            FROM Exemplar e
            JOIN Bibliotecas b ON e.BibliotecaID = b.ID
            GROUP BY b.Nome
            HAVING SUM(e.Quantidade) >= 0";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetLivrosDisponiveisPorAutorAsync()
    {
        // Consulta de agregação com COUNT, GROUP BY e HAVING para livros disponíveis por autor
        var sql = @"
            SELECT l.Autor,
                   COUNT(*) AS LivrosDisponiveis
            FROM Livro l
            JOIN Exemplar e ON e.LivroID = l.ID
            WHERE e.Disponivel = TRUE
            GROUP BY l.Autor
            HAVING COUNT(*) > 1";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetMediaExemplaresPorBibliotecaAsync()
    {
        // Consulta de agregação com AVG, GROUP BY e HAVING para média de exemplares por biblioteca
        var sql = @"
            SELECT b.Nome AS Biblioteca,
                   AVG(e.Quantidade) AS MediaExemplares
            FROM Exemplar e
            JOIN Bibliotecas b ON e.BibliotecaID = b.ID
            GROUP BY b.Nome
            HAVING AVG(e.Quantidade) > 2";

        return await ExecuteQueryAsync(sql);
    }

    public async Task<IEnumerable<ConsultaResultadoModel>> GetMultasMaxMinMediaAsync()
    {
        // Consulta de agregação global com MAX, MIN e AVG das multas
        var sql = @"
            SELECT MAX(Multa) AS MultaMaxima,
                   MIN(Multa) AS MultaMinima,
                   AVG(Multa) AS MultaMedia
            FROM Emprestimo";

        return await ExecuteQueryAsync(sql);
    }

    private async Task<IEnumerable<ConsultaResultadoModel>> ExecuteQueryAsync(string sql)
    {
        var resultados = new List<ConsultaResultadoModel>();
        var conn = _connection.GetConexao();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var linha = new ConsultaResultadoModel { Sql = sql };
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var nome = reader.GetName(i);
                var valor = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i)?.ToString() ?? string.Empty;
                linha.Valores[nome] = valor;
            }

            resultados.Add(linha);
        }

        return resultados;
    }
}
