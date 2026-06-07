using System;
using System.Threading.Tasks;

namespace SistemaBibliotecario.Interfaces.Services;

public interface IEmprestimoService
{
    Task<bool> RegistrarAsync(int exemplarID, DateTime dataDevolucao);
}
