using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Services;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public Task<bool> RegistrarAsync(AutorModel autor)
        => _autorRepository.AddAsync(autor);

    public Task<IEnumerable<AutorModel>> ListarAutoresAsync()
        => _autorRepository.GetAllAsync();
}
