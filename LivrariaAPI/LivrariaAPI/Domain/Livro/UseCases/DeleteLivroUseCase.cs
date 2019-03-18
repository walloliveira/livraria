
using LivrariaAPI.Persistence.LivroPersistence;

namespace LivrariaAPI.Domain.Livro.UseCases
{
    public class DeleteLivroUseCase : IDeleteLivroUseCase
    {
        private readonly ILivroRepository _repository;

        public DeleteLivroUseCase(ILivroRepository repository)
        {
            _repository = repository;
        }

        public NullDomain Execute(LivroId req)
        {
            _repository.Delete(req);
            return NullDomain.GetInstance();
        }
    }
}
