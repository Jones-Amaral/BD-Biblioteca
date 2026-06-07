using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Services;

public interface IUsuarioService
{
    Task<bool> RegistrarAsync(UsuarioModel usuario);
}
