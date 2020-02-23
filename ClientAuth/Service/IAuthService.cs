using ClientAuth.Models;

namespace ClientAuth.Service
{
    public interface IAuthService
    {
        AccountModel Authenticate(string username, string password);
    }
}
