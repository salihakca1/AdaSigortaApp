using AdaSigortaMaui.Models;
using System.Net.Http.Json;


namespace AdaSigortaMaui.Services
{
    public class DaskService : IDaskPolicyRepository
    {
        public async Task<Dask> DaskPolicy(string productName, string kimlikNo, DateTime dogumTarihi, string adi, string soyadi, DateTime tanzimTarihi, DateTime vadeBaslangic, DateTime vadeBitis, double prim, string address, string il, string ilce)
        {
            try
            {
                var client = CreateHttpClient();

                string localAddress =
                   DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";

                string localHostUrl = localAddress + "/api/dasks";

                client.BaseAddress = new Uri(localHostUrl);

                var newDask = new Dask
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
                    Adress = address,
                    Il = il,
                    Ilce = ilce
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress, newDask);
                if (response.IsSuccessStatusCode)
                {

                    Dask dask = await response.Content.ReadFromJsonAsync<Dask>();
                    
                    await Shell.Current.DisplayAlert("Teklifimiz: ", prim.ToString(), "Ok");
                    await Shell.Current.GoToAsync("///PolicePage");
                    return await Task.FromResult(dask);

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



