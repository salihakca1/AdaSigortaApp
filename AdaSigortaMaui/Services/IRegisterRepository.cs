using AdaSigortaMaui.Models;

namespace AdaSigortaMaui.Services
{
    public interface IRegisterRepository
    {
        Task<User> Register(string email, string name, string password);

    }
}
