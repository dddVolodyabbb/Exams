﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DownloaderHTTP.Helpers
{
    public class JsonSerializeHelper
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings =
            new()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSerializerSettings);
        }

        public static TKey Deserialize<TKey>(string obj)
        {
            return JsonConvert.DeserializeObject<TKey>(obj);
        }

        public static bool TryDeserialize<TKey>(string obj, out TKey result)
        {
            try
            {
                result = JsonConvert.DeserializeObject<TKey>(obj);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}
