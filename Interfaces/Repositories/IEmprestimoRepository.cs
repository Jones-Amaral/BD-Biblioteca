using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Repositories;

public interface IEmprestimoRepository
{
    Task<bool> AddAsync(EmprestimoModel emprestimo);
}
