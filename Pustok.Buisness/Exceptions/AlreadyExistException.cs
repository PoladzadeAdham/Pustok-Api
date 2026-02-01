using Pustok.Buisness.Abstractions;

namespace Pustok.Buisness.Exceptions
{
    public class AlreadyExistException(string message = "This is already exist") : ApplicationException(message), IBaseException
    {
        public int StatusCode { get; set; } = 409;
    }
}
