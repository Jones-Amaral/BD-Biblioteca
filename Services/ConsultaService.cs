using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Services;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;

    public ConsultaService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public Task<IEnumerable<ConsultaResultadoModel>> GetLivrosComExemplaresAsync()
        => _consultaRepository.GetLivrosComExemplaresAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetEmprestimosComLivroEBibliotecaAsync()
        => _consultaRepository.GetEmprestimosComLivroEBibliotecaAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetTitulosDeDuasBibliotecasUnionAsync()
        => _consultaRepository.GetTitulosDeDuasBibliotecasUnionAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetTitulosPresentesEmAmbasBibliotecasIntersectAsync()
        => _consultaRepository.GetTitulosPresentesEmAmbasBibliotecasIntersectAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetTitulosDeUmaBibliotecaNaoEmOutraAsync()
        => _consultaRepository.GetTitulosDeUmaBibliotecaNaoEmOutraAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetTotalExemplaresPorBibliotecaAsync()
        => _consultaRepository.GetTotalExemplaresPorBibliotecaAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetLivrosDisponiveisPorAutorAsync()
        => _consultaRepository.GetLivrosDisponiveisPorAutorAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetMediaExemplaresPorBibliotecaAsync()
        => _consultaRepository.GetMediaExemplaresPorBibliotecaAsync();

    public Task<IEnumerable<ConsultaResultadoModel>> GetMultasMaxMinMediaAsync()
        => _consultaRepository.GetMultasMaxMinMediaAsync();
}
