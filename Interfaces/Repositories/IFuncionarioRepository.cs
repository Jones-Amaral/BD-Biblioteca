using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Repositories;

public interface IFuncionarioRepository
{
    Task<bool> AddAsync(FuncionarioModel funcionario);
    Task<IEnumerable<FuncionarioModel>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
}
