using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Services;

public interface ILivroService
{
    Task<IEnumerable<LivroModel>> ListarLivrosAsync();
    Task<bool> RegistrarAsync(LivroModel livro);
    Task<bool> ExcluirAsync(int id);
}
