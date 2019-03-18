
using LivrariaAPI.Domain.Livro.UseCases;
using Microsoft.AspNetCore.Mvc;
namespace LivrariaAPI.Api.Resources.Livros
{
    [Route("api/livro")]
    [ApiController]
    public class PostLivroController : ControllerBase
    {
        private readonly IAddLivroUseCase _useCase;

        public PostLivroController(IAddLivroUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LivroDTO novoLivro)
        {
            LivroResource resource = LivroResource.From(_useCase.Execute(novoLivro));
            return CreatedAtRoute("GetLivroById", new { id = resource.Id }, resource);
        }
    }
}
