using MyPhillReminderApp_MelanyIssac.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPhillReminderApp_MelanyIssac
{
    public static class GlobalObjects
    {
     //definimos las propiedades de codificacion de los json que usaremos en los modelos

        public static string MimeType="application/json";

        public static string ContentType = "Content-Type";

        //crear el objeto local (global) usuario
        public static UserDTO MyLocalUser = new UserDTO();


    }
}
