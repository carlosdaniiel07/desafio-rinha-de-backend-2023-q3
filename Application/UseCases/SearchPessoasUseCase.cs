using DesafioBackEnd.Dtos;
using DesafioBackEnd.Entities;
using DesafioBackEnd.Interfaces.Repositories;
using DesafioBackEnd.Interfaces.UseCases;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.UseCases
{
    public class SearchPessoasUseCase : ISearchPessoasUseCase
    {
        private readonly IPessoaRepository _repository;

        public SearchPessoasUseCase(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseUseCaseResponse<IEnumerable<GetPessoaResponseDto>>> ExecuteAsync(string searchCriteria)
        {
            var people = string.IsNullOrEmpty(searchCriteria) ? Enumerable.Empty<Pessoa>() : await _repository.GetAllAsync(searchCriteria);
            return new BaseUseCaseResponse<IEnumerable<GetPessoaResponseDto>>(people.Select(person => new GetPessoaResponseDto
            {
                Id = person.Id,
                Nome = person.Nome,
                Apelido = person.Apelido,
                Nascimento = person.Nascimento,
                Stack = person.Stack,
            }));
        }
    }
}
