using AdaSigortaMaui.ViewModels;

namespace AdaSigortaMaui.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;

    }
}

