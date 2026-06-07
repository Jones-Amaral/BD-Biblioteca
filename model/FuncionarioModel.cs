using System.Diagnostics.CodeAnalysis;

namespace SistemaBibliotecario.Model;

public class FuncionarioModel
{
    public int ID { get; set; }
    public required string Nome { get; set; }
    public required string Cargo { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataContratacao { get; set; }

    [SetsRequiredMembers]
    public FuncionarioModel(string nome, string cargo, decimal salario, DateTime dataContratacao)
    {
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
        DataContratacao = dataContratacao;
    }
}
