using AdaSigortaMaui.Views;
using AdaSigortaMaui.ViewModels;

namespace AdaSigortaMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(PolicePage), typeof(PolicePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(DaskPageView), typeof(DaskPageView));
            Routing.RegisterRoute(nameof(TrafficPage), typeof(TrafficPage));
            Routing.RegisterRoute(nameof(MyPoliciesPage), typeof(MyPoliciesPage));
        }


    }

}