using AdaSigortaMaui.Models;
using AdaSigortaMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AdaSigortaMaui.ViewModels
{
    public partial class RegisterPageViewModel: ObservableObject
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _password;

        readonly IRegisterRepository registerService = new RegisterService(); 
        
        [RelayCommand]
        public async Task RegisterIn()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                {

                    User user = await registerService.Register(Email, Name, Password);
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
