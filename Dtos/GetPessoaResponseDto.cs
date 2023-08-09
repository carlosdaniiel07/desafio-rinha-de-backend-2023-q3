namespace DesafioBackEnd.Dtos
{
    public class GetPessoaResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime Nascimento { get; set; }
        public IEnumerable<string> Stack { get; set; }
    }
}
