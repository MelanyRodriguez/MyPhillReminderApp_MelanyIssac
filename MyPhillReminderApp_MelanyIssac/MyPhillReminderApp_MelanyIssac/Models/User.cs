using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace MyPhillReminderApp_MelanyIssac.Models
{
   public class User
    {
        //es mala idea tener un solo objeto de comunicacion RestRequest contra el API 
        //es recomendable tener uno por cada clase que se comunica con el API
        [JsonIgnore]
     public RestRequest Request { get; set; }


        //aca se usara los mismos atributos que el API mas adelante se usata un DTO 
        //del usuario para simplificar el json que se envia y se recibe delde el API

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public bool Active { get; set; }
        public bool IsBlocked { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole? UserRole { get; set; } = null!;

        public User()
        {
          Active= true;
            IsBlocked= false;
        }

        //Funciones de la llamada a end points del API

        //funcion que permite validar que los datos digitados en la pagina de appLogin
        //sean correctos
        public async Task<bool> ValidateUserLogin()
        {
          try
            {
                //usaremos el prefijo de la ruta URL del API que se indica en la 
                //API Conection para agregar el sufijo y lograr la ruta completa
                //de consumo del end point que se quiere usar

                string RouteSufix= string.Format("Users/ValidateLogin?username={0}&password={1}",
                                                                    this.Email, this.Password);

                //armamos la ruta completa al endpoint en el API

                string URL =Services.APIConection.ProductionPrefixURL + RouteSufix;
                //http://192.168.100.146:45455/api/Users/ValidateLogin?username=issac%40gmail.com&password=123

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);

                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }

        public async Task<bool> AddUserAsnc()
        {
            try
            {

                string RouteSufix = string.Format("Users");

                //armamos la ruta completa al endpoint en el API

                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;
                //http://192.168.100.146:45455/api/Users/ValidateLogin?username=issac%40gmail.com&password=123

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                //en el caso de una operacion post debemos serializar el objeto para
                //usarlo como json al API
                string SerializedModelOject = JsonConvert.SerializeObject(this);
                //agregamos el objeto serializado en el cuerpo del request
               Request.AddBody(SerializedModelOject, GlobalObjects.MimeType);
                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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


