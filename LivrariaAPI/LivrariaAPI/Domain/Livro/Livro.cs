namespace LivrariaAPI.Domain.Livro
{
    public class Livro
    {
        public string Nome { get; private set; }
        public LivroId Id { get; private set; }
        public string Autor { get; private set; }
        public int Paginas { get; private set; }

        public static LivroBuilder Builder()
        {
            return new LivroBuilder();
        }

        public class LivroBuilder
        {
            internal LivroBuilder() {
                WithId(new LivroId());
            }

            private LivroId _Id;
            private string _Nome;
            private string _Autor;
            private int _Paginas;

            public LivroBuilder WithId(LivroId id)
            {
                _Id = id;
                return this;
            }

            public LivroBuilder WithNome(string nome)
            {
                _Nome = nome;
                return this;
            }
            public LivroBuilder WithAuthor(string autor)
            {
                _Autor = autor;
                return this;
            }
            public LivroBuilder WithPaginas(int paginas)
            {
                _Paginas = paginas;
                return this;
            }

            public Livro Build()
            {
                return new Livro
                {
                    Id = _Id,
                    Autor = _Autor,
                    Paginas = _Paginas,
                    Nome = _Nome
                };
            }
        }
    }
}