using MyPhillReminderApp_MelanyIssac.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyPhillReminderApp_MelanyIssac.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}