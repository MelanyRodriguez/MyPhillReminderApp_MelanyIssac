using MyPhillReminderApp_MelanyIssac.ViewModels;
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
    public partial class RemindersListPage : ContentPage
    {
        ReminderViewModel ReminderViewModel;
        public RemindersListPage()
        {
            InitializeComponent();

            BindingContext = ReminderViewModel = new ReminderViewModel();
            LoadReminderList();
        }
        private async void LoadReminderList()
        {
            LvList.ItemsSource = await ReminderViewModel.GetPhillReminderAsync(GlobalObjects.MyLocalUser.UsuarioID);



        }
    }
}