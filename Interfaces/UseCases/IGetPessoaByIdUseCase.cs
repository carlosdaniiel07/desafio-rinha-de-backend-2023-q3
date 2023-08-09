using DesafioBackEnd.Dtos;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Interfaces.UseCases
{
    public interface IGetPessoaByIdUseCase
    {
        Task<BaseUseCaseResponse<GetPessoaResponseDto>> ExecuteAsync(Guid id);
    }
}
