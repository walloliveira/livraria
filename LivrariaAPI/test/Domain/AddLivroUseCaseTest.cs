using LivrariaAPI.Api.Resources.Livros;
using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Domain.Livro.UseCases;
using LivrariaAPI.Persistence.LivroPersistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace test.Domain
{
    [TestClass]
    public class AddLivroUseCaseTest
    {
        IAddLivroUseCase _useCase;

        [TestMethod]
        public void AddLivro()
        {
            var mock = new Mock<ILivroRepository>();
            _useCase = new AddLivroUseCase(mock.Object);
            var livroDTO = new LivroDTO
            {
                Autor = "Autor1",
                Nome = "Livro1",
                Paginas = 100
            };
            var livro = _useCase.Execute(livroDTO);
            mock.Verify(m => m.Save(It.IsAny<Livro>()));
            mock.VerifyNoOtherCalls();
        }
    }
}
