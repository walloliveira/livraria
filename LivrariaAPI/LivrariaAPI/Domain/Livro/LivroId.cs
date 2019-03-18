
using System;

namespace LivrariaAPI.Domain.Livro
{
    public class LivroId
    {
        public Guid Value { get; private set; }

        public LivroId()
        {
            Value = Guid.NewGuid();
        }

        private LivroId(Guid guid)
        {
            Value = guid;
        }

        public static LivroId Of(Guid guid)
        {
            return new LivroId(guid);
        }
    }
}
