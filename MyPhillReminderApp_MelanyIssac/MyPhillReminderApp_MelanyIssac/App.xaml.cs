using MyPhillReminderApp_MelanyIssac.Services;
using MyPhillReminderApp_MelanyIssac.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPhillReminderApp_MelanyIssac
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<MockDataStore>();
            //definimos la forma de aplicar paginas en la pantalla y cual ee
            //la primera pagina que mostraremos 

            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
