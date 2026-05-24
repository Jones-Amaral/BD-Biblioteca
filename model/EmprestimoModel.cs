namespace model;

public class EmprestimoModel
{
    public int ID { get; set; }
    public int ExemplarID { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
    public bool Disponivel { get; set; }
    public decimal Multa { get; set; }
}
