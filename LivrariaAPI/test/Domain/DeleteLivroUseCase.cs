using LivrariaAPI.Domain;
using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Domain.Livro.UseCases;
using LivrariaAPI.Persistence.LivroPersistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace test.Domain
{
    [TestClass]
    public class DeleteLivroUseCaseTest
    {
        IDeleteLivroUseCase _useCase;

        [TestMethod]
        public void ListLivro()
        {
            var mock = new Mock<ILivroRepository>();
            _useCase = new DeleteLivroUseCase(mock.Object);
            var livroId = LivroId.Of(Guid.Parse("3c0fb75c-316a-42d0-9600-90657b9a74ff"));
            _useCase.Execute(livroId);
            mock.Verify(m => m.Delete(It.Is<LivroId>(v => v == livroId)));
            mock.VerifyNoOtherCalls();
        }
    }   
}
