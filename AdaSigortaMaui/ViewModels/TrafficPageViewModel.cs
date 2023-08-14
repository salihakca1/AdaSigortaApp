using AdaSigortaMaui.Models;
using AdaSigortaMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AdaSigortaMaui.ViewModels
{
    public partial class TrafficPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private string _tckimlikno;

        [ObservableProperty]
        private string _adı;

        [ObservableProperty]
        private string _soyadı;


        [ObservableProperty]
        private string _plakaKodu;

        [ObservableProperty]
        private DateTime selectedDate;

        [ObservableProperty]
        private List<string> _plakaIlKodu;

        readonly ITrafficPolicyRepository trafficPolicyService = new TrafficService();


        public TrafficPageViewModel()
        {
            _plakaIlKodu = new List<string>
            {
                "01", "01", "02", "03","04","05","06","07","08","09","10","11","12","13",
                "14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30",
                "31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49",
                "50","51","52","53","54","55","56","57","58","59","60","61","62","63","64","65","66","67","68","69",
                "70","71","72","73","74","75","76","77","78","79","80","81"
            };

        }

        private string _selectedPlakaIlKodu;
        public string SelectedPlakaIlKodu
        {
            get => _selectedPlakaIlKodu;
            set => SetProperty(ref _selectedPlakaIlKodu, value);
        }

        [RelayCommand]
        public async Task CreateTrafficPolicy()
        {
            try
            {
                string productName = "Trafik";
                string selectedPlakaIlKodu = SelectedPlakaIlKodu;

                DateTime selectedDogumDate = selectedDate.Date ;

                DateTime tanzimTarih = DateTime.Now.Date.ToUniversalTime();
                DateTime vadeBaslangic = DateTime.Now.Date.ToUniversalTime();
                DateTime vadeBitis = vadeBaslangic.AddYears(1);
                double prim = new Random().Next(1000, 10000);



                if(!string.IsNullOrWhiteSpace(Tckimlikno) && !string.IsNullOrWhiteSpace(Adı) && !string.IsNullOrWhiteSpace(Soyadı)
                    && !string.IsNullOrWhiteSpace(PlakaKodu) && !string.IsNullOrWhiteSpace(selectedPlakaIlKodu)   ) 
                {

                    Traffic traffic = await trafficPolicyService.TrafficPolicy(productName,Tckimlikno, selectedDogumDate, Adı, Soyadı,tanzimTarih, 
                        vadeBaslangic, vadeBitis,prim, selectedPlakaIlKodu, PlakaKodu);

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
