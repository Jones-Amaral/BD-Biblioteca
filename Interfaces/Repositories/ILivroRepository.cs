using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Repositories;

public interface ILivroRepository
{
    Task<IEnumerable<LivroModel>> GetAllAsync();
    Task<bool> AddAsync(LivroModel livro);
    Task<bool> DeleteAsync(int id);
}
