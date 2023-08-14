using AdaSigortaMaui.FlyoutHeader;
using AdaSigortaMaui.Models;
using AdaSigortaMaui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;


    namespace AdaSigortaMaui.ViewModels
    {
        public partial class PolicePageViewModel : ObservableObject
        {

            [RelayCommand]
            public async Task GoToDaskPage()
            {
                await Shell.Current.GoToAsync(nameof(DaskPageView)); 

            }

            [RelayCommand]
            public async Task GoToTrafficPage()
            {
                await Shell.Current.GoToAsync(nameof(TrafficPage));

            }

            [RelayCommand]
            public async Task GoToMyPoliciesPage()
            {
                await Shell.Current.GoToAsync(nameof(MyPoliciesPage));

            }

            public PolicePageViewModel()
            {
                _ = NewCheckUser();
            }
        /*
        private async Task CheckUser()
        {
            string userDetails = Preferences.Get(nameof(App.user), "");



             
            if (string.IsNullOrWhiteSpace(userDetails))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {

                var tokenDetails = await SecureStorage.GetAsync(nameof(App.Token));

                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jsonToken = handler.ReadToken(tokenDetails) as JwtSecurityToken;
                
                if(jsonToken.ValidTo < DateTime.UtcNow)
                {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

                }
                else
                {

                    var userInfo = JsonSerializer.Deserialize<User>(userDetails);
                    App.user = userInfo;
                    App.Token = tokenDetails;
                }

            }
        }
        */

        public async Task NewCheckUser()
        {
            var tokenDetails = await SecureStorage.GetAsync(nameof(App.Token));

            if (!string.IsNullOrEmpty(tokenDetails))
            {
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jsonToken = handler.ReadToken(tokenDetails) as JwtSecurityToken;

                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                else
                {
                    App.Token = tokenDetails;
                    App.user = JsonSerializer.Deserialize<User>(Preferences.Get(nameof(App.user), string.Empty));
                    Shell.Current.FlyoutHeader = new FlyoutHeaderUser();

                }
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }





        
    }
}
