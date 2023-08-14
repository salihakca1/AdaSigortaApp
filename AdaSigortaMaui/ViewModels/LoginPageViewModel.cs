    using AdaSigortaMaui.Models;
    using AdaSigortaMaui.Services;
    using AdaSigortaMaui.Views;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using System.Text.Json;
    using AdaSigortaMaui.FlyoutHeader;


namespace AdaSigortaMaui.ViewModels
    {
        public partial class LoginPageViewModel: ObservableObject
        {

            [ObservableProperty]
            private string _email;

            [ObservableProperty]
            private string _password;

            readonly ILoginRepository loginService = new LoginService(); 

        [RelayCommand]
        public async Task NewSignIn()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                {

                    var tokenResponse = await loginService.GetJwtToken(Email, Password);
                    
                    if (tokenResponse != null)
                    {

                        if(Preferences.ContainsKey(nameof(App.user)))
                        {
                            Preferences.Remove(nameof(App.user));
                        }

                        await SecureStorage.SetAsync(nameof(App.Token), tokenResponse.Token);

                        string userDetails = JsonSerializer.Serialize(tokenResponse.userDetail); 

                        Preferences.Set(nameof(App.user), userDetails);
                        App.user = tokenResponse.userDetail;
                       


                        Shell.Current.FlyoutHeader = new FlyoutHeaderUser();
                        await Shell.Current.GoToAsync(nameof(PolicePage));
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Email/Password is incorrect", "Ok");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "All Field Required", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
        }


        [RelayCommand]
            public async Task RegisterPage()
            {
                await Shell.Current.GoToAsync(nameof(RegisterPage)); 

            }
        }
    }
