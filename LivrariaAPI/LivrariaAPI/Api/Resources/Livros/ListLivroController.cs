
using LivrariaAPI.Domain;
using LivrariaAPI.Domain.Livro;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaAPI.Api.Resources.Livros
{
    [Route("api/livros")]
    [ApiController]
    public class ListLivroController : ControllerBase
    {
        private IListLivroUseCase _useCase;

        public ListLivroController(IListLivroUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public ActionResult List()
        {
            return Ok(
                _useCase.Execute(NullDomain.GetInstance())
                .ConvertAll(l => LivroResource.From(l)));
        }
    }
}
