using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Services;

public class BibliotecaService : IBibliotecaService
{
    private readonly IBibliotecaRepository _bibliotecaRepository;

    public BibliotecaService(IBibliotecaRepository bibliotecaRepository)
    {
        _bibliotecaRepository = bibliotecaRepository;
    }

    public Task<bool> RegistrarAsync(BibliotecaModel biblioteca)
        => _bibliotecaRepository.AddAsync(biblioteca);

    public Task<IEnumerable<BibliotecaModel>> ListarBibliotecasAsync()
        => _bibliotecaRepository.GetAllAsync();
}
