using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LivrariaAPI.Api.Resources.Livros
{
    [Route("api/livro/{id}", Name = "GetLivroById")]
    [ApiController]
    public class GetLivroController : ControllerBase
    {
        private readonly IGetLivroUseCase _useCase;

        public GetLivroController(IGetLivroUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        [NotFoundExceptionFilter]
        public ActionResult Get([FromRoute(Name = "id")] Guid id)
        {
            return Ok(LivroResource.From(_useCase.Execute(LivroId.Of(id))));
        }
    }
}
