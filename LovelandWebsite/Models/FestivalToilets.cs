using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FestivalToiletsApi.Models;

namespace LovelandWebsite.Models
{
    public class FestivalToilets
    {
        protected string api = "http://localhost:7502/api/toilets";

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


        public IEnumerable<Toilet> XmlToObject(string xml) {

            if (!string.IsNullOrEmpty(xml))
            {
                var ser = new XmlSerializer(typeof(IEnumerable<Toilet>));

                var obj = (IEnumerable<Toilet>)ser.Deserialize(new StringReader(xml));
                return obj;
            }
            return null;
        }

    }
}
