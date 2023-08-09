using DesafioBackEnd.Entities;

namespace DesafioBackEnd.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> SaveAsync(Pessoa pessoa);
        Task<Pessoa> GetByIdAsync(Guid id);
        Task<IEnumerable<Pessoa>> GetAllAsync(string searchCriteria);
        Task<long> CountAsync();
    }
}
