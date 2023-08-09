using DesafioBackEnd.Entities;
using DesafioBackEnd.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace DesafioBackEnd.Infrastructure.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IMongoCollection<Pessoa> _collection;

        public PessoaRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");

            new PessoaMapping().RegisterMap();

            var mongoClient = new MongoClient(connectionString);
            var mongoDatabase = mongoClient.GetDatabase(connectionString.Split('/').LastOrDefault());

            _collection = mongoDatabase.GetCollection<Pessoa>("pessoa");
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync(string searchCriteria)
        {
            var regex = BsonRegularExpression.Create(new Regex(searchCriteria, RegexOptions.IgnoreCase));
            var filterBuilder = Builders<Pessoa>.Filter;
            var filter = filterBuilder.Or(
                filterBuilder.Regex(pessoa => pessoa.Nome, regex),
                filterBuilder.Regex(pessoa => pessoa.Apelido, regex),
                filterBuilder.Regex(pessoa => pessoa.Stack, regex)
            );
            return await _collection
                .Find(filter)
                .Limit(50)
                .ToListAsync();
        }

        public async Task<Pessoa> GetByIdAsync(Guid id)
        {
            var filter = Builders<Pessoa>.Filter.Eq(pessoa => pessoa.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<Pessoa> SaveAsync(Pessoa pessoa)
        {
            await _collection.InsertOneAsync(pessoa);
            return pessoa;
        }

        public async Task<long> CountAsync()
        {
            return await _collection.CountDocumentsAsync(Builders<Pessoa>.Filter.Empty);
        }
    }
}
