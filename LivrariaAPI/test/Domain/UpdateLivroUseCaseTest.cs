
using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Domain.Livro.UseCases;
using LivrariaAPI.Persistence.LivroPersistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace test.Domain
{
    [TestClass]
    public class UpdateLivroUseCaseTest
    {
        IUpdateLivroUseCase _useCase;

        [TestMethod]
        public void GetLivro()
        {
            var mock = new Mock<ILivroRepository>();
            _useCase = new UpdateLivroUseCase(mock.Object);
            var livroId = LivroId.Of(Guid.Parse("3c0fb75c-316a-42d0-9600-90657b9a74ff"));
            var livro = Livro.Builder()
                .WithAuthor("Autor 1")
                .WithNome("Nome 1")
                .WithPaginas(100)
                .WithId(livroId)
                .Build();
            var result = _useCase.Execute(livro);
            mock.Verify(m => m.Update(It.Is<Livro>(v => v.Equals(livro))));
            mock.VerifyNoOtherCalls();
        }
    }
}
