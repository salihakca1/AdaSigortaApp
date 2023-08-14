using AdaSigortaMaui.Models;

namespace AdaSigortaMaui.Services

{
   public interface ILoginRepository
    {

        Task<LoginResponse> GetJwtToken(string email, string password);


    }
}
