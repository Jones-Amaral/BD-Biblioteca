using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBibliotecario.Interfaces.Repositories;
using SistemaBibliotecario.Interfaces.Services;
using SistemaBibliotecario.Model;

namespace SistemaBibliotecario.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _livroRepository;

    public LivroService(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public Task<IEnumerable<LivroModel>> ListarLivrosAsync()
        => _livroRepository.GetAllAsync();

    public Task<bool> RegistrarAsync(LivroModel livro)
        => _livroRepository.AddAsync(livro);

    public Task<bool> ExcluirAsync(int id)
        => _livroRepository.DeleteAsync(id);
}
