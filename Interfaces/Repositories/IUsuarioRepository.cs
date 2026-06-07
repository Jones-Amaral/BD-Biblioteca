using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<bool> AddAsync(UsuarioModel usuario);
}
