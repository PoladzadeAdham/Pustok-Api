using Pustok.Buisness.Abstractions;

namespace Pustok.Buisness.Exceptions
{
    public class LoginException(string message = " Some credentials are wrong") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 400;
    }
}
