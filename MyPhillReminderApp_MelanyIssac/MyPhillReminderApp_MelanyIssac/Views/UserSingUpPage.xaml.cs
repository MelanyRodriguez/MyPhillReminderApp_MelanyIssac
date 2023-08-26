using MyPhillReminderApp_MelanyIssac.ViewModels;
using MyPhillReminderApp_MelanyIssac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPhillReminderApp_MelanyIssac.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserSingUpPage : ContentPage
	{
		UserViewModel viewModel;
		public UserSingUpPage ()
		{
			InitializeComponent ();

			BindingContext = viewModel = new UserViewModel();
			LoadUserRolAsync ();
		}
		//funcion que permite la carga de los roles de usuario
		public async void LoadUserRolAsync()
		{
			PkrUserRole.ItemsSource=await viewModel.GetUserRolesAsync();
		}

        private async void  BtnAdd_Clicked(object sender, EventArgs e)
        {
			//capturar el rol que se haya seleccionado en el picker
			UserRole SelectedUserRole = PkrUserRole.SelectedItem as UserRole;
			bool R= await viewModel.AddUserAsync(TxtEmail.Text.Trim(),
				                                 TxtPassword.Text.Trim(),
                                                 TxtName.Text.Trim(),
                                                 TxtBackUpEmail.Text.Trim(),
                                                 TxtPhoneNumber.Text.Trim(),
												 TxtAddress.Text.Trim(),
												 SelectedUserRole.UserRoleId);

            if (R)
            {
				await DisplayAlert(":)", "User created!", "OK");
				await Navigation.PopAsync();
            }
			else
			{
                await DisplayAlert(":(", "somethig went wrong...", "OK");
            }

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
			await Navigation.PopAsync();
        }
    }
}