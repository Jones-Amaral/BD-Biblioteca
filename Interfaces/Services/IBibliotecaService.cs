using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Interfaces.Services;

public interface IBibliotecaService
{
    Task<bool> RegistrarAsync(BibliotecaModel biblioteca);
    Task<IEnumerable<BibliotecaModel>> ListarBibliotecasAsync();
}
