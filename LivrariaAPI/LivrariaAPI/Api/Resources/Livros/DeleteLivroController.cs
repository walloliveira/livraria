using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LivrariaAPI.Api.Resources.Livros
{
    [Route("api/livro/{id}")]
    [ApiController]
    public class DeleteLivroController : ControllerBase
    {
        private readonly IDeleteLivroUseCase _useCase;

        public DeleteLivroController(IDeleteLivroUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpDelete]
        [NotFoundExceptionFilter]
        public ActionResult Get([FromRoute(Name = "id")] Guid id)
        {
            return Ok(_useCase.Execute(LivroId.Of(id)));
        }
    }
}
