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
        // Geri tu�una bas�l�nca yap�lacak i�lemler (�rne�in geri d�nmeyi engellemek)
        return true; // true d�nd�rerek geri d�nmeyi engelleyin
    }
}
