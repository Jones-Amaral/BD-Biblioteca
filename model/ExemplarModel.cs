namespace SistemaBibliotecario.Model;

public class ExemplarModel
{
    public int ID { get; set; }
    public int Quantidade { get; set; }
    public int LivroID { get; set; }
    public int BibliotecaID { get; set; }
    public bool Disponivel { get; set; }
    public required string Situacao { get; set; }

    public ExemplarModel(int quantidade, int livroID, int bibliotecaID, bool disponivel, string situacao)
    {
        Quantidade = quantidade;
        LivroID = livroID;
        BibliotecaID = bibliotecaID;
        Disponivel = disponivel;
        Situacao = situacao;
    }
}
