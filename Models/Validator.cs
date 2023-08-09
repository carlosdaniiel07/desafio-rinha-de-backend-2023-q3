namespace DesafioBackEnd.Models
{
    public abstract class Validator
    {
        public abstract bool IsValid();

        protected bool HasLength(string value, int min, int max)
        {
            var length = value?.Length ?? 0;
            return length >= min && length <= max;
        }

        protected bool NotEmpty<T>(IEnumerable<T> value) =>
            value?.Any() ?? false;
    }
}
