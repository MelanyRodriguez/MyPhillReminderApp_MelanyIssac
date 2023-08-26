using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyPhillReminderApp_MelanyIssac.Models
{
    public class PhillReminder
    {
        public PhillReminder()
        {
            
        }
        [JsonIgnore]
        
        public RestRequest Request { get; set; }



        public int ReminderId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Alarm { get; set; }
        public bool AlarmActive { get; set; }
        public bool AlarmJustinWeekDays { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public int ReminderCategory { get; set; }


        public virtual ICollection<ReminderSteps>? ReminderStepReminderSteps { get; set; }


        public async Task<ObservableCollection<PhillReminder>> GetpillreminderListByUserID()
        {
            try
            {



                string RouteSufix = string.Format("PhillReminder/GetpillreminderListByUser?id={0}", this.UserId);
                //armamos la ruta completa al endpoint en el api



                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;



                RestClient client = new RestClient(URL);



                Request = new RestRequest(URL, Method.Get);



                //agregamos el mecanismo de seguridad, en este caso api key 
                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);



                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                //ejecutamos la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);



                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;



                if (statusCode == HttpStatusCode.OK)
                {




                    var list = JsonConvert.DeserializeObject<ObservableCollection<PhillReminder>>(response.Content);




                    return list;
                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }



        }

        
    }
}
