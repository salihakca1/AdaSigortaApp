	using AdaSigortaMaui.ViewModels;
	using AdaSigortaMaui.Views;

	namespace AdaSigortaMaui;

	public partial class LoginPage : ContentPage
	{

		public LoginPage(LoginPageViewModel vm)
		{

			InitializeComponent();
			BindingContext = vm;
		}
	}
