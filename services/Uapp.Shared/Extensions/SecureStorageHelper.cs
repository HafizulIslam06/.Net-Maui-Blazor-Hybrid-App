using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Shared.Extensions
{
    public static class SecureStorageHelper
    {
        public static async Task<bool> SetObjectAsync<T>(string key, T obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                await SecureStorage.Default.SetAsync(key, json);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., SecureStorageException, serialization errors)
                return false;
            }
        }
        public static void RemoveObjectAsync(string key)
        {
            SecureStorage.Default.Remove(key);

        }

        public static async Task<T> GetObjectAsync<T>(string key)
        {
            try
            {
                string json = await SecureStorage.Default.GetAsync(key);
                if (json != null)
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
