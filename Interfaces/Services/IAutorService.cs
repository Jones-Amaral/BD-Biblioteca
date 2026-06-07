using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Services;

public interface IAutorService
{
    Task<bool> RegistrarAsync(AutorModel autor);
    Task<IEnumerable<AutorModel>> ListarAutoresAsync();
}
