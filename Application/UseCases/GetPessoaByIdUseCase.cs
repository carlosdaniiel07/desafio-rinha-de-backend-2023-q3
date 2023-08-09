using DesafioBackEnd.Dtos;
using DesafioBackEnd.Entities;
using DesafioBackEnd.Interfaces.Services;
using DesafioBackEnd.Interfaces.UseCases;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.UseCases
{
    public class GetPessoaByIdUseCase : IGetPessoaByIdUseCase
    {
        private readonly ICacheService _cacheService;

        public GetPessoaByIdUseCase(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<BaseUseCaseResponse<GetPessoaResponseDto>> ExecuteAsync(Guid id)
        {
            var person = await _cacheService.RetrieveAsync<Pessoa>($"pessoa:{id}");

            if (person == null)
                return new BaseUseCaseResponse<GetPessoaResponseDto>(null);

            return new BaseUseCaseResponse<GetPessoaResponseDto>(new GetPessoaResponseDto
            {
                Id = person.Id,
                Nome = person.Nome,
                Apelido = person.Apelido,
                Nascimento = person.Nascimento,
                Stack = person.Stack,
            });
        }
    }
}
