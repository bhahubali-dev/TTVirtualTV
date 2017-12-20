using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PerpetualEngine.Storage;

namespace VirtualEvent.Droid.Helper
{
    public static class StorageUtils<T> where T : class
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
                Console.WriteLine("Error : VirtualEventPrefSet " + e.Message);
                return false;
            }
        }

		public static bool SavePreferences(string key, string data)
		{
			try
			{
				DefieStorage();
				SimpleStorage.EditGroup("VirtualEvent").Put<string>(key, data);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error : VirtualEventPrefSet " + e.Message);
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
                Console.WriteLine("Error : VirtualEventPrefGet " + e.Message);
                return null;
            }
        }


		public static string GetPreferencesValue(string key)
		{
			try
			{
			//	DefieStorage();
				string uData = SimpleStorage.EditGroup("VirtualEvent").Get<string>(key);
				return uData;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error : ValidateUser " + e.Message);
				return "";
			}
		} }
}