using MyPhillReminderApp_MelanyIssac.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MyPhillReminderApp_MelanyIssac.ViewModels
{
    public class ReminderViewModel: BaseViewModel
    {
        public PhillReminder MyPhillReminder { get; set; }
        public ReminderViewModel()
        {
           MyPhillReminder = new PhillReminder();
        }
        public  async Task<ObservableCollection<PhillReminder>> GetPhillReminderAsync(int pUserID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {



                ObservableCollection<PhillReminder> phillReminders = new ObservableCollection<PhillReminder>();
                MyPhillReminder.UserId = pUserID;
                phillReminders = await MyPhillReminder.GetpillreminderListByUserID();



                if (phillReminders == null)
                {
                    return null;
                }
                return phillReminders;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    
    }
}
