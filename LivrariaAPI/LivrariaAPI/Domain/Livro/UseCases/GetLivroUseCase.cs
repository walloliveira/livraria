
using LivrariaAPI.Persistence.LivroPersistence;

namespace LivrariaAPI.Domain.Livro.UseCases
{
    public class GetLivroUseCase : IGetLivroUseCase
    {
        private readonly ILivroRepository _repository;

        public GetLivroUseCase(ILivroRepository repository)
        {
            _repository = repository;
        }

        public Livro Execute(LivroId livroId)
        {
            return _repository.GetByLivroId(livroId);
        }
    }
}
