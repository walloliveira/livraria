using LivrariaAPI.Persistence.LivroPersistence;
using System;
using System.Collections.Generic;

namespace LivrariaAPI.Domain.Livro.UseCases
{
    public class ListLivroUseCase : IListLivroUseCase
    {
        private readonly ILivroRepository _repository;

        public ListLivroUseCase(ILivroRepository repository)
        {
            _repository = repository;
        }

        public List<Livro> Execute(NullDomain req)
        {
            return _repository.FindAllOrderByNome();
        }
    }
}
