using System;
using LivrariaAPI.Domain.Livro;

namespace LivrariaAPI.Persistence.LivroPersistence
{
    public class LivroEntity
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Author { get; private set; }
        public int Paginas { get; private set; }

        private LivroEntity () { }

        public static LivroEntity Of(Livro livro)
        {
            return new LivroEntity
            {
                Id = livro.Id.Value,
                Author = livro.Autor,
                Nome = livro.Nome,
                Paginas = livro.Paginas
            };
        }

        public Livro ToDomain()
        {
            return Livro.Builder()
                .WithAuthor(Author)
                .WithId(LivroId.Of(Id))
                .WithNome(Nome)
                .WithPaginas(Paginas)
                .Build();
        }

        internal void Update(Livro livro)
        {
            Author = livro.Autor;
            Nome = livro.Nome;
            Paginas = livro.Paginas;
        }
    }
}
