using AdaSigortaMaui.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace AdaSigortaMaui.Services
{
    public class RegisterService : IRegisterRepository
    {
        public async Task<User> Register(string email, string name, string password)
        {
            try
            {

                var client = CreateHttpClient();

                string address =
                   DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";

                string localHostUrl = address + "/api/users";

                client.BaseAddress = new Uri(localHostUrl);

                

            var registerData = new User
            {
                Email = email,
                Name = name,
                Password = password
            };


            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, registerData);

                 
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadFromJsonAsync<User>();

                    await Shell.Current.GoToAsync("///LoginPage");

                    return await Task.FromResult(user);

                }

                return null;
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }
       

        private HttpClient CreateHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                }
            };

            return new HttpClient(httpClientHandler);
        }
    }
}
