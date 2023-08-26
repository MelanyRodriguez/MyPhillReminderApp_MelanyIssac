using MyPhillReminderApp_MelanyIssac.ViewModels;
using MyPhillReminderApp_MelanyIssac.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyPhillReminderApp_MelanyIssac
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
