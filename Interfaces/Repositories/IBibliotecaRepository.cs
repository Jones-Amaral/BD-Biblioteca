using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Repositories;

public interface IBibliotecaRepository
{
    Task<bool> AddAsync(BibliotecaModel biblioteca);
    Task<IEnumerable<BibliotecaModel>> GetAllAsync();
}
