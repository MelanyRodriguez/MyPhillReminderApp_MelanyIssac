using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyPhillReminderApp_MelanyIssac.Models
{
    public class UserDTO
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }
        public int UsuarioID { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string RespaldoCorreo { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool Activado { get; set; }
        public bool EstaBloqueado { get; set; }
        public int RolUsuarioID { get; set; }
        public string DescripcionRol { get; set; } = null!;

        //FUNCIONES
        public async Task<UserDTO> GetUserInfo(string PEmail)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUserInfoByEmail?Pemail={0}");

                //armamos la ruta completa al endpoint en el API

                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;
                //http://192.168.100.146:45455/api/Users/ValidateLogin?username=issac%40gmail.com&password=123

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    // en el API diseñamos el end point de forma que retorne un list <UserDTO>
                    //pero esta funcion retorna solo un objeto del UserDTO por lo tanto debemos
                    //seleccionar de lsa lista el item con index 0

                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);
                    var item =list[0];
                    return item;
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

        public async Task<bool> UPdateUserAsync()
        {
            try
            {

                string RouteSufix = string.Format("Users/{0}", this.UsuarioID);
                //armamos la ruta completa al endpoint en el api



                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;



                RestClient client = new RestClient(URL);



                Request = new RestRequest(URL, Method.Put);



                //agregamos el mecanismo de seguridad, en este caso api key 
                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);



                //en el caso de una operacion post debemos serializar el objeto para pasarlo como
                //json al api



                string SerealizedModelObject = JsonConvert.SerializeObject(this);
                //Agregamos el objeto serializado en el cuerpo del request
                Request.AddBody(SerealizedModelObject, GlobalObjects.MimeType);





                //ejecutamos la llamada al api
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
    }

}
