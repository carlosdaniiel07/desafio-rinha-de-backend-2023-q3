using DesafioBackEnd.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace DesafioBackEnd.Infrastructure.Data
{
    public class PessoaMapping
    {
        public BsonClassMap<Pessoa> RegisterMap()
        {
            return BsonClassMap.RegisterClassMap<Pessoa>(classMap =>
            {
                classMap.MapIdMember(pessoa => pessoa.Id)
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIdGenerator(new GuidGenerator())
                    .SetElementName("id");
                classMap.MapMember(pessoa => pessoa.Nome).SetElementName("nome");
                classMap.MapMember(pessoa => pessoa.Apelido).SetElementName("apelido");
                classMap.MapMember(pessoa => pessoa.Nascimento)
                    .SetSerializer(new DateTimeSerializer(dateOnly: true))
                    .SetElementName("nascimento");
                classMap.MapMember(pessoa => pessoa.Stack).SetElementName("stack");
            });
        }
    }
}
