using System.Collections.Generic;
using System.Linq;
using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Exceptions;

namespace LivrariaAPI.Persistence.LivroPersistence
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivroContext _context;

        public LivroRepository(LivroContext context)
        {
            _context = context;
        }

        public List<Livro> FindAllOrderByNome()
        {
            return _context.LivroEntities
                .OrderBy(l => l.Nome)
                .Select(l => l.ToDomain())
                .ToList();
        }

        public Livro GetByLivroId(LivroId livroId)
        {
            LivroEntity livroEntity = FindById(livroId);
            return livroEntity.ToDomain();
        }

        private LivroEntity FindById(LivroId livroId)
        {
            LivroEntity livroEntity = _context.LivroEntities
                            .SingleOrDefault(l => l.Id == livroId.Value);
            if (livroEntity == null)
                throw new NotFoundException("Livro não encontrado");
            return livroEntity;
        }

        public Livro Save(Livro livro)
        {
            LivroEntity novoLivroEntity = LivroEntity.Of(livro);
            _context.Add(novoLivroEntity);
            _context.SaveChanges();
            return novoLivroEntity.ToDomain();
        }

        public Livro Update(Livro livro)
        {
            LivroEntity entity = FindById(livro.Id);
            entity.Update(livro);
            _context.Update(entity);
            _context.SaveChanges();
            return entity.ToDomain();
        }

        public void Delete(LivroId req)
        {
            var livroentity = FindById(req);
            _context.LivroEntities.Remove(livroentity);
            _context.SaveChanges();
        }
    }
}
