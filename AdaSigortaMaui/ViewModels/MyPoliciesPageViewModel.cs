using AdaSigortaMaui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace AdaSigortaMaui.ViewModels
{
    public partial class MyPoliciesPageViewModel : ObservableObject
    {

        private ObservableCollection<Traffic> trafficItems;

        public ObservableCollection<Traffic> TrafficItems
        {
            get { return trafficItems; }
            set { SetProperty(ref trafficItems, value); }
        }
        private ObservableCollection<Dask> daskItems;

        public ObservableCollection<Dask> DaskItems
        {
            get { return daskItems; }
            set { SetProperty(ref daskItems, value); }
        }
        public MyPoliciesPageViewModel()
        {
            DaskItems = new ObservableCollection<Dask>();
            TrafficItems = new ObservableCollection<Traffic>();
            _ = LoadDataAsync();
            _ = LoadDaskDataAsync();
        }

        public async Task LoadDataAsync()
        {
            try
            {
                string address = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";
                string apiEndpoint = address + "/api/traffic";
               
                using (var client = CreateHttpClient())
                {
                    client.BaseAddress = new Uri(apiEndpoint);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var apiData = JsonSerializer.Deserialize<Traffic[]>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        foreach (var item in apiData)
                        {
                            TrafficItems.Add(item);
                        }
                      
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Hata", "Veri çekilemedi.", "Tamam");
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }

        public async Task LoadDaskDataAsync()
        {
            try
            {
                string address = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";
                string apiEndpoint = address + "/api/dasks";

                using (var client = CreateHttpClient())
                {
                    client.BaseAddress = new Uri(apiEndpoint);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var apiData = JsonSerializer.Deserialize<Dask[]>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        foreach (var item in apiData)
                        {
                            DaskItems.Add(item);
                        }

                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Hata", "Veri çekilemedi.", "Tamam");
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }

        [RelayCommand]
        public async Task DeleteTraffic(int policyId)
        {


            try
            {
                string address = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";
                string apiEndpoint = address + "/api/traffic/" + policyId;

                using (var client = CreateHttpClient())
                {
                    client.BaseAddress = new Uri(apiEndpoint);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);

                    if (response.IsSuccessStatusCode)
                    {

                        var trafficToRemove = TrafficItems.FirstOrDefault(d => d.PolicyId == policyId);
                        if (trafficToRemove != null)
                        {
                            TrafficItems.Remove(trafficToRemove);
                        }

                        await Shell.Current.DisplayAlert("Başarılı", "Trafik kaydı başarıyla silindi.", "Tamam");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Hata", "Trafik kaydı silinemedi.", "Tamam");
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }

        [RelayCommand]
        public async Task DeleteDask(int policyId)
        {


            try
            {
                string address = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7230" : "http://localhost:7230";
                string apiEndpoint = address + "/api/dasks/" + policyId;

                using (var client = CreateHttpClient())
                {
                    client.BaseAddress = new Uri(apiEndpoint);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);

                    if (response.IsSuccessStatusCode)
                    {

                        var daskToRemove = DaskItems.FirstOrDefault(d => d.PolicyId == policyId);
                        if (daskToRemove != null)
                        {
                            DaskItems.Remove(daskToRemove);
                        }

                        await Shell.Current.DisplayAlert("Başarılı", "Dask kaydı başarıyla silindi.", "Tamam");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Hata", "Dask kaydı silinemedi.", "Tamam");
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

