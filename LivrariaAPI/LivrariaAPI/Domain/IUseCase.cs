
namespace LivrariaAPI.Domain
{
    public interface IUseCase<REQUEST, RESPONSE>
    {
        RESPONSE Execute(REQUEST req);
    }
}
