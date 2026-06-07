namespace SistemaBibliotecario.Model;

public class ConsultaResultadoModel
{
    public Dictionary<string, string> Valores { get; } = new();
    public string Sql { get; set; } = string.Empty;
}
