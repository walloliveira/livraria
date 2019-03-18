
using LivrariaAPI.Api.Resources.Livros;
using LivrariaAPI.Persistence.LivroPersistence;

namespace LivrariaAPI.Domain.Livro.UseCases
{
    public class AddLivroUseCase : IAddLivroUseCase
    {
        private readonly ILivroRepository _repository;

        public AddLivroUseCase(ILivroRepository repository)
        {
            _repository = repository;
        }
        public Livro Execute(LivroDTO req)
        {
            return _repository.Save(
                Livro.Builder()
                    .WithAuthor(req.Autor)
                    .WithNome(req.Nome)
                    .WithPaginas(req.Paginas)
                    .Build()
            );
        }
    }
}
