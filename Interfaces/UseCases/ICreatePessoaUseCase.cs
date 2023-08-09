using DesafioBackEnd.Dtos;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Interfaces.UseCases
{
    public interface ICreatePessoaUseCase
    {
        Task<BaseUseCaseResponse<CreatePessoaResponseDto>> ExecuteAsync(CreatePessoaDto createPessoaDto);
    }
}
