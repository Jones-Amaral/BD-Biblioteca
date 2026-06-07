using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Repositories;

public interface IAutorRepository
{
    Task<bool> AddAsync(AutorModel autor);
    Task<IEnumerable<AutorModel>> GetAllAsync();
}
