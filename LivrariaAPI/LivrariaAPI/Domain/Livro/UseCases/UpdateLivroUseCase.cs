
using LivrariaAPI.Api.Resources.Livros;
using LivrariaAPI.Persistence.LivroPersistence;

namespace LivrariaAPI.Domain.Livro.UseCases
{
    public class UpdateLivroUseCase : IUpdateLivroUseCase
    {
        private readonly ILivroRepository _repository;

        public UpdateLivroUseCase(ILivroRepository repository)
        {
            _repository = repository;
        }

        public Livro Execute(Livro req)
        {
            return _repository.Update(req);
        }
    }
}
