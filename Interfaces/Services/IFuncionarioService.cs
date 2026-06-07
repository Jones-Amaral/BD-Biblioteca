using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Services;

public interface IFuncionarioService
{
    Task<bool> RegistrarAsync(FuncionarioModel funcionario);
    Task<IEnumerable<FuncionarioModel>> ListarFuncionariosAsync();
    Task<bool> ExcluirAsync(int id);
}
