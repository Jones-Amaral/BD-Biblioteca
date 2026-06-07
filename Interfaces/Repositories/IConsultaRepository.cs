using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Repositories;

public interface IConsultaRepository
{
    Task<IEnumerable<ConsultaResultadoModel>> GetLivrosComExemplaresAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetEmprestimosComLivroEBibliotecaAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetTitulosDeDuasBibliotecasUnionAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetTitulosPresentesEmAmbasBibliotecasIntersectAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetTitulosDeUmaBibliotecaNaoEmOutraAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetTotalExemplaresPorBibliotecaAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetLivrosDisponiveisPorAutorAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetMediaExemplaresPorBibliotecaAsync();
    Task<IEnumerable<ConsultaResultadoModel>> GetMultasMaxMinMediaAsync();
}
