using LivrariaAPI.Domain;
using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Domain.Livro.UseCases;
using LivrariaAPI.Persistence.LivroPersistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace test.Domain
{
    [TestClass]
    public class ListLivroUseCaseTest
    {
        IListLivroUseCase _useCase;

        [TestMethod]
        public void ListLivro()
        {
            var mock = new Mock<ILivroRepository>();
            _useCase = new ListLivroUseCase(mock.Object);
            var livro = _useCase.Execute(NullDomain.GetInstance());
            mock.Verify(m => m.FindAllOrderByNome());
            mock.VerifyNoOtherCalls();
        }
    }   
}
