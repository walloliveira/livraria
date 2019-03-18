using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LivrariaAPI.Api.Resources.Livros
{
    [Route("api/livro/{id}", Name = "GetLivroById")]
    [ApiController]
    public class PutLivroController : ControllerBase
    {
        private readonly IUpdateLivroUseCase _useCase;

        public PutLivroController(IUpdateLivroUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPut]
        [NotFoundExceptionFilter]
        public ActionResult Get([FromRoute(Name = "id")] Guid id, [FromBody] LivroDTO livroDTO)
        {
            return Ok(_useCase.Execute(
                Livro.Builder()
                .WithId(LivroId.Of(id))
                .WithAuthor(livroDTO.Autor)
                .WithNome(livroDTO.Nome)
                .WithPaginas(livroDTO.Paginas)
                .Build())
            );
        }
    }
}
