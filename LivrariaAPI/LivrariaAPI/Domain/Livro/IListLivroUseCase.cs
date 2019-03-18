using System.Collections.Generic;

namespace LivrariaAPI.Domain.Livro
{
    public interface IListLivroUseCase: IUseCase<NullDomain, List<Livro>>
    {
    }
}
