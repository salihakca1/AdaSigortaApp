using AdaSigortaMaui.ViewModels;

namespace AdaSigortaMaui.Views;

public partial class MyPoliciesPage : ContentPage
{
	public MyPoliciesPage(MyPoliciesPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
      
    }
}
