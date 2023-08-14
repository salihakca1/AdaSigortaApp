using AdaSigortaMaui.Models;
using System.Net.Http.Json;


namespace AdaSigortaMaui.Services
{
    public class TrafficService : ITrafficPolicyRepository
    {
        public async Task<Traffic> TrafficPolicy(string productName, string kimlikNo, DateTime dogumTarihi, string adi, string soyadi, DateTime tanzimTarihi, DateTime vadeBaslangic, DateTime vadeBitis, double prim, string plakaIlKodu, string plakaKodu)
        {
            try
            {
                var client = CreateHttpClient();

                string address =
                   DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";

                string localHostUrl = address + "/api/traffic";

                client.BaseAddress = new Uri(localHostUrl);
            
                var newTraffic = new Traffic
                {
                    Person = new Person
                    {
                        KimlikNo = kimlikNo,
                        DogumTarihi = dogumTarihi,
                        Adi = adi,
                        Soyadi = soyadi
                    },
                    Product = new Product
                    {
                        Name = productName
                    },
                    TanzimTarihi = tanzimTarihi,
                    VadeBaslangic = vadeBaslangic,
                    VadeBitis = vadeBitis,
                    Prim = prim,
                    PlakaIlKodu = plakaIlKodu,
                    PlakaKodu = plakaKodu
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, newTraffic);
                if (response.IsSuccessStatusCode)
                {

                    Traffic traffic = await response.Content.ReadFromJsonAsync<Traffic>();
                    await Shell.Current.DisplayAlert("Teklifimiz: ", prim.ToString()+"TL","Ok");
                    await Shell.Current.GoToAsync("///PolicePage");
                    return await Task.FromResult(traffic);

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
