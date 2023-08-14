using AdaSigortaMaui.FlyoutHeader;
using AdaSigortaMaui.Models;
using AdaSigortaMaui.ViewModels;
using AdaSigortaMaui.Views;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace AdaSigortaMaui
{
    public partial class App : Application
    {

        public static string Token;
        public static User user;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            _ = CheckUserAsync();
        }

        private async Task CheckUserAsync()
        {
            // Burada NewCheckUser() metodundaki kodları kullanın
            var tokenDetails = await SecureStorage.GetAsync(nameof(App.Token));

            if (!string.IsNullOrEmpty(tokenDetails))
            {
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jsonToken = handler.ReadToken(tokenDetails) as JwtSecurityToken;

                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    MainPage = new AppShell(); // Eğer token süresi geçmişse, AppShell açılacak
                }
                else
                {
                    App.Token = tokenDetails;
                    App.user = JsonSerializer.Deserialize<User>(Preferences.Get(nameof(App.user), string.Empty));
                    Shell.Current.FlyoutHeader = new FlyoutHeaderUser();
                    await Shell.Current.GoToAsync(nameof(PolicePage));
                }
            }
            else
            {
                MainPage = new AppShell(); // Eğer token yoksa, AppShell açılacak
            }
        }

    }
}