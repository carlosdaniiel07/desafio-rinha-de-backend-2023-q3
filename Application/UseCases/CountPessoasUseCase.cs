using DesafioBackEnd.Interfaces.Repositories;
using DesafioBackEnd.Interfaces.UseCases;

namespace DesafioBackEnd.Application.UseCases
{
    public class CountPessoasUseCase : ICountPessoasUseCase
    {
        private readonly IPessoaRepository _repository;

        public CountPessoasUseCase(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> ExecuteAsync() =>
            await _repository.CountAsync();
    }
}
