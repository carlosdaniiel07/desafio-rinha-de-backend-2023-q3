using DesafioBackEnd.Dtos;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Interfaces.UseCases
{
    public interface ISearchPessoasUseCase
    {
        Task<BaseUseCaseResponse<IEnumerable<GetPessoaResponseDto>>> ExecuteAsync(string searchCriteria);
    }
}
