using System;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using SistemaBibliotecario.Interfaces.Infrastructure;
using System.Data;

namespace SistemaBibliotecario.Infrastructure;

public class Connection : IConnection
{
    private MySqlConnection? conexao;
    private IConfiguration? configuration;

    public void Inicializar(IConfiguration config)
    {
        configuration = config;
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        conexao = new MySqlConnection(connectionString);
    }

    public bool AbrirConexao()
    {
        try
        {
            if (conexao == null)
                throw new InvalidOperationException("Conexao não foi inicializada. Chame Inicializar() primeiro.");

            conexao.Open();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao abrir conexão: " + ex.Message);
            return false;
        }
    }

    public bool FecharConexao()
    {
        if (conexao != null && conexao.State == ConnectionState.Open)
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

    public MySqlConnection GetConexao()
    {
        if (conexao == null)
        {
            throw new InvalidOperationException("Conexao não foi inicializada. Chame Inicializar() primeiro.");
        }
        return conexao!;
    }
}
