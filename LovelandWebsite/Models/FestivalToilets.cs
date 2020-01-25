using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LovelandWebsite.Models
{
    public class FestivalToilets
    {
        protected string api = "https://localhost:7502/api/toilets";

        public string Get() {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {

                return reader.ReadToEnd();
            }
        }


        public IEnumerable<Toilet> JsonToObject(string json) {
            JsonSerializerSettings settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All
            };


            var obj = JsonConvert.DeserializeObject<IEnumerable<Toilet>>(json, settings);
            return obj;
        }
    }
}
