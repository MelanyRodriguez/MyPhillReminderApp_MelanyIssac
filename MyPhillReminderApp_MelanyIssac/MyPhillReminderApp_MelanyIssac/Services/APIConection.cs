using System;
using System.Collections.Generic;
using System.Text;

namespace MyPhillReminderApp_MelanyIssac.Services
{
    public static class APIConection
    {
        //aca definimos la direccion URL (ya sea una IP o un nombre de dominio)
        //a la que el App debe apuntar por comodidad la ruta URL completa para consumir los 
        //recursos del API

        public static string ProductionPrefixURL = "http://192.168.100.146:45455/api/";

        public static string TestingPrefixURL = "http://192.168.100.146:45455/api/";

        public static string ApiKeyName = "Progra6ApiKey";

        public static string ApiKeyValue = "MelanyIssacProgra6AsdZxcl12345";
    }
}
