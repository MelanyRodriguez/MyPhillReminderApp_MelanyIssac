using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyPhillReminderApp_MelanyIssac.ViewModels;
using System.ComponentModel.Design;
using Acr.UserDialogs;

namespace MyPhillReminderApp_MelanyIssac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
        
    {
        //se realiza el anclaje entre la vista y el vm que le da la funcionalidad
        UserViewModel viewModel;
        public AppLoginPage()
        {
            InitializeComponent();
            //este vincula la v con el vm y ademas crea la instancia del objeto
            this.BindingContext = viewModel= new UserViewModel();

        }

        private void SwshowPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwshowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword= true;
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //validacion del ingreso del usuario a la app
            if (TxtUserName.Text!= null && !string.IsNullOrEmpty(TxtUserName.Text.Trim()) &&
               TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                //si hay info en los cuadros de texto de email y pass se procede
                try
                {
                    //crear la animacion de espera
                    UserDialogs.Instance.ShowLoading("Checking user access...");
                    await Task.Delay(2000);

                    string username = TxtUserName.Text.Trim();
                    string password = TxtPassword.Text.Trim();
                    bool R= await viewModel.UserAccessValidation(username, password);


                    if (R)
                    {
                        //si la validacion es correcta se permite el ingreso al sistema
                        GlobalObjects.MyLocalUser = await viewModel.GetUserDataAsync(TxtUserName.Text.Trim());
                        await Navigation.PushAsync(new StartPage());


                    }
                    else
                    {
                        //algo salio mal
                        await DisplayAlert("User Access Denied", "username or password are incorrect", "OK");
                        return;

                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
                finally 
                {
                    //apagamos la animacion de carga
                    UserDialogs.Instance.HideLoading();
                }

            }
            else
            {
                // si no digito datos indicarle al usuario del requerimiento
                await DisplayAlert("Data Required", "username and password are required...", "OK");
                return;
            }

        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSingUpPage());
        }
    }
}