namespace SistemaBibliotecario.Model;

public class EmprestimoModel
{
    public int ID { get; set; }
    public int ExemplarID { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
    public bool Disponivel { get; set; }
    public decimal Multa { get; set; }

    public EmprestimoModel() { }

    public EmprestimoModel(int exemplarID, DateTime dataEmprestimo, DateTime dataDevolucao, bool disponivel, decimal multa)
    {
        ExemplarID = exemplarID;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
        Disponivel = disponivel;
        Multa = multa;
    }
}
