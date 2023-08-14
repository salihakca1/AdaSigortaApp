using AdaSigortaMaui.Models;
using AdaSigortaMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AdaSigortaMaui.ViewModels
{
    public partial class DaskPageViewModels : ObservableObject
    {
        [ObservableProperty]
        private string _tckimlikno;

        [ObservableProperty]
        private string _adı;

        [ObservableProperty]
        private string _soyadı;

        [ObservableProperty]
        private string _address;

        [ObservableProperty]
        private string _ilce;

        [ObservableProperty]
        private DateTime selectedDate;

        [ObservableProperty]
        private List<string> _cities;

        readonly IDaskPolicyRepository daskPolicyService = new DaskService();


        public DaskPageViewModels()
        {
            _cities = new List<string>
            {
                "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı","Amasya","Ankara","Antalya","Artvin","Aydın","Balıkesir","Bilecik","Bingöl","Bitlis","Bolu",
                "Burdur","Bursa","Çanakkale","Çankırı","Çorum","Denizli","Diyarbakır","Edirne","Elazığ","Erzincan","Erzurum","Eskişehir","Gaziantep","Giresun","Isparta","Mersin","İstanbul",
                "İzmir","Kars","Kastamonu","Kayseri","Kırklareli","Kırşehir","Kocaeli","Konya","Kütahya","Yalova","Karabük","Kilis","Osmaniye","Düzce","Kırıkkale","Şırnak","Batman",
            };


        }

        private string _selectedCity;
        public string SelectedCity
        {
            get => _selectedCity;
            set => SetProperty(ref _selectedCity, value);
        }



        [RelayCommand]
        public async Task CreateDaskPolicy()
        {

            try
            {
                string productName = "Dask";
                DateTime selectedDogumDate = selectedDate.Date;
                string selectedCity = SelectedCity;

                DateTime tanzimTarih = DateTime.Now.Date.ToUniversalTime();
                DateTime vadeBaslangic = DateTime.Now.Date.ToUniversalTime();
                DateTime vadeBitis = vadeBaslangic.AddYears(1);
                double prim = new Random().Next(1000, 10000);

                if (!string.IsNullOrWhiteSpace(Tckimlikno) && !string.IsNullOrWhiteSpace(Adı) && !string.IsNullOrWhiteSpace(Soyadı)
              && !string.IsNullOrWhiteSpace(Address) && !string.IsNullOrWhiteSpace(selectedCity) && !string.IsNullOrWhiteSpace(Ilce))
                {

                    Dask dask = await daskPolicyService.DaskPolicy(productName, Tckimlikno, selectedDogumDate, Adı, Soyadı, tanzimTarih,
                        vadeBaslangic, vadeBitis, prim, Address, selectedCity, Ilce);


                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "All fields are required.", "Ok");

                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }

        }

  
    }
}
