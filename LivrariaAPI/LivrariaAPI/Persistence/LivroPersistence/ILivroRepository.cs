
using System.Collections.Generic;
using LivrariaAPI.Domain.Livro;

namespace LivrariaAPI.Persistence.LivroPersistence
{
    public interface ILivroRepository
    {
        Livro Save(Livro livro);
        Livro GetByLivroId(LivroId livroId);
        List<Livro> FindAllOrderByNome();
        Livro Update(Livro req);
        void Delete(LivroId req);
    }
}
