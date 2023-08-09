namespace DesafioBackEnd.Models
{
    public class BaseUseCaseResponse<T> where T : class
    {
        public T Data { get; set; }
        public bool HasError => Data == null;

        public BaseUseCaseResponse(T data = null)
        {
            Data = data;
        }
    }
}
