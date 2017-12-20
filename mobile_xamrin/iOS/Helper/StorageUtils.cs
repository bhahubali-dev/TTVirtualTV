using System;
using Newtonsoft.Json;
using PerpetualEngine.Storage;

namespace VirtualEvent.iOS
{
    public class StorageUtils<T> where T : class
    {
        public static void DefieStorage()
        {
            SimpleStorage.EditGroup("VirtualEvent");
        }

        public static bool SavePreferences(string key, T data)
        {
            try
            {
                DefieStorage();
                SimpleStorage.EditGroup("VirtualEvent").Put<string>(key, JsonConvert.SerializeObject(data));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : ValidateUser " + e.Message);
                return false;
            }
        }
        public static T GetPreferences(string key)
        {
            try
            {
                DefieStorage();
                var uData = SimpleStorage.EditGroup("VirtualEvent").Get<string>(key);
                return JsonConvert.DeserializeObject<T>(uData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : ValidateUser " + e.Message);
                return null;
            }
        }
    }
}
