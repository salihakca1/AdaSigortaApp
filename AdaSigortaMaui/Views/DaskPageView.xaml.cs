using AdaSigortaMaui.ViewModels;

namespace AdaSigortaMaui.Views;


public partial class DaskPageView : ContentPage
{
	public DaskPageView(DaskPageViewModels vm)
	{
		InitializeComponent();
        BindingContext = vm;

    }
}