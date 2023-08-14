using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AdaSigortaMaui.ViewModels
{
    public partial class AppShellViewModel: ObservableObject
    {
        [RelayCommand]
        async void LogOutUser()
        {
            if (Preferences.ContainsKey(nameof(App.user)))
            {
                Preferences.Remove(nameof(App.user));
                
                    await Shell.Current.GoToAsync("///LoginPage");
                
            }
        }

    }
}
