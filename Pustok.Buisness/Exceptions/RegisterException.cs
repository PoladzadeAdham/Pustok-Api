using Pustok.Buisness.Abstractions;

namespace Pustok.Buisness.Exceptions
{
    public class RegisterException(string message = "Registration failed") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 400;
    }
}
