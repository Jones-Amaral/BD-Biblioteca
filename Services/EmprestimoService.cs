using System;
using System.Threading.Tasks;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Services;

public class EmprestimoService : IEmprestimoService
{
    private readonly IEmprestimoRepository _emprestimoRepository;

    public EmprestimoService(IEmprestimoRepository emprestimoRepository)
    {
        _emprestimoRepository = emprestimoRepository;
    }

    public Task<bool> RegistrarAsync(int exemplarID, DateTime dataDevolucao)
    {
        var emprestimo = new EmprestimoModel
        {
            ExemplarID = exemplarID,
            DataEmprestimo = DateTime.Now,
            DataDevolucao = dataDevolucao,
            Disponivel = false,
            Multa = 0m
        };

        return _emprestimoRepository.AddAsync(emprestimo);
    }
}
