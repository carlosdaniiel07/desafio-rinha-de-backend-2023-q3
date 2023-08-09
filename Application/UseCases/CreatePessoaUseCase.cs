using DesafioBackEnd.Dtos;
using DesafioBackEnd.Entities;
using DesafioBackEnd.Interfaces.Repositories;
using DesafioBackEnd.Interfaces.Services;
using DesafioBackEnd.Interfaces.UseCases;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.UseCases
{
    public class CreatePessoaUseCase : ICreatePessoaUseCase
    {
        private readonly ICacheService _cacheService;
        private readonly IPessoaRepository _repository;

        public CreatePessoaUseCase(ICacheService cacheService, IPessoaRepository repository)
        {
            _cacheService = cacheService;
            _repository = repository;
        }

        public async Task<BaseUseCaseResponse<CreatePessoaResponseDto>> ExecuteAsync(CreatePessoaDto createPessoaDto)
        {
            var isValid = createPessoaDto.IsValid();

            if (!isValid)
                return new BaseUseCaseResponse<CreatePessoaResponseDto>();

            var alreadyExists = await _cacheService.ExistsAsync($"pessoa:{createPessoaDto.Apelido}");

            if (alreadyExists)
                return new BaseUseCaseResponse<CreatePessoaResponseDto>();

            var person = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = createPessoaDto.Nome,
                Apelido = createPessoaDto.Apelido,
                Nascimento = createPessoaDto.Nascimento.Date,
                Stack = createPessoaDto.Stack,
            };

            await _repository.SaveAsync(person);
            await _cacheService.AddAsync($"pessoa:{createPessoaDto.Apelido}", person, TimeSpan.FromDays(3));
            await _cacheService.AddAsync($"pessoa:{person.Id}", person, TimeSpan.FromDays(3));

            return new BaseUseCaseResponse<CreatePessoaResponseDto>(new CreatePessoaResponseDto
            {
                Id = person.Id,
            });
        }
    }
}
