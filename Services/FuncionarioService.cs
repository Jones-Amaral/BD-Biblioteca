using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public Task<bool> RegistrarAsync(FuncionarioModel funcionario)
        => _funcionarioRepository.AddAsync(funcionario);

    public Task<IEnumerable<FuncionarioModel>> ListarFuncionariosAsync()
        => _funcionarioRepository.GetAllAsync();

    public Task<bool> ExcluirAsync(int id)
        => _funcionarioRepository.DeleteAsync(id);
}
