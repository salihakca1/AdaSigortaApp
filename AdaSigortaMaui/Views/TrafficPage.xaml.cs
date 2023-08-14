using AdaSigortaMaui.ViewModels;

namespace AdaSigortaMaui.Views;

public partial class TrafficPage : ContentPage
{
	public TrafficPage(TrafficPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;

    }
}