using AdaSigortaMaui.ViewModels;

namespace AdaSigortaMaui.Views;
public partial class PolicePage : ContentPage
{

	public PolicePage(PolicePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
   }

    protected override bool OnBackButtonPressed()
    {
        // Geri tuþuna basýlýnca yapýlacak iþlemler (örneðin geri dönmeyi engellemek)
        return true; // true döndürerek geri dönmeyi engelleyin
    }
}
