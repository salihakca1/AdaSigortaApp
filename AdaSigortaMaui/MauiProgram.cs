using AdaSigortaMaui.ViewModels;
using AdaSigortaMaui.Views;

namespace AdaSigortaMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

          
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();

            builder.Services.AddSingleton<PolicePage>();
            builder.Services.AddSingleton<PolicePageViewModel>();

            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageViewModel>();

            builder.Services.AddSingleton<DaskPageView>();
            builder.Services.AddSingleton<DaskPageViewModels>();

            builder.Services.AddSingleton<TrafficPage>();
            builder.Services.AddSingleton<TrafficPageViewModel>();

            builder.Services.AddSingleton<MyPoliciesPage>();
            builder.Services.AddSingleton<MyPoliciesPageViewModel>();

            return builder.Build();
        }
    }
}
