using AdaSigortaMaui.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AdaSigortaMaui.Services
{

    public class LoginService : ILoginRepository
    { 
        public async Task<LoginResponse> GetJwtToken(string email, string password)
        {
            try
            {
                var loginData = new LoginRequest
                {
                    Email = email,
                    Password = password
                };

                var client = CreateHttpClient();

                string address =
                   DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";

                string localHostUrl = address + "/api/users/loginJwt";
                client.BaseAddress = new Uri(localHostUrl);

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, loginData);

                if (!response.IsSuccessStatusCode)
                {
                    return null; 
                }

                var tokenResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return tokenResponse;
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

            var httpClient = new HttpClient(httpClientHandler);
            var securityKey = "UserKeyControlUserKeyControlUserKeyControlUserKeyControlUserKeyControlUserKeyControl";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", securityKey);
            string address =
                     DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";

            string localHostUrl = address + "/api/users/loginJwt";
            httpClient.BaseAddress = new Uri(localHostUrl); 
            return httpClient;
        }
    }


}
    

