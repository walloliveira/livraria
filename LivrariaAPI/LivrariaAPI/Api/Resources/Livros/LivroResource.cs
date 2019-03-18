
using LivrariaAPI.Domain.Livro;
using System;

namespace LivrariaAPI.Api.Resources.Livros
{
    public class LivroResource
    {
        public Guid Id { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public int Paginas { get; set; }

        public static LivroResource From(Livro livro)
        {
            return new LivroResource
            {
                Autor = livro.Autor,
                Id = livro.Id.Value,
                Nome = livro.Nome,
                Paginas = livro.Paginas
            };
        }
    }
}
