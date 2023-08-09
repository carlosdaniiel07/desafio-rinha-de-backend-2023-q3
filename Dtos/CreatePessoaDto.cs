using DesafioBackEnd.Models;

namespace DesafioBackEnd.Dtos
{
    public class CreatePessoaDto : Validator
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime Nascimento { get; set; }
        public IEnumerable<string> Stack { get; set; }

        public override bool IsValid()
        {
            return HasLength(Nome, 1, 100)
                && HasLength(Apelido, 1, 32)
                && Nascimento != default
                && (Stack?.All(value => HasLength(value, 1, 32)) ?? true);
        }
    }
}
