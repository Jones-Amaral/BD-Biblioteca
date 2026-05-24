namespace model;

public class ExemplarModel
{
    public int ID { get; set; }
    public int Quantidade { get; set; }
    public int LivroID { get; set; }
    public int BibliotecaID { get; set; }
    public bool Disponivel { get; set; }
    public string Situacao { get; set; }
}
