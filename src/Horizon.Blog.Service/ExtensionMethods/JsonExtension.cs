using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Horizon.Blog.Service.ExtensionMethods
{
    public static class JsonExtension
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
        public static T ToObject<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return default(T);
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
