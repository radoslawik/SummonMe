using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.API
{
    public class ApiHandler
    {
        private string Key { get; set; }
        private string Region { get; set; }

        public ApiHandler(string region)
        {
            Region = region;
            StreamReader read_key = new StreamReader("API/YourDeveloperKey.txt");
            Key = read_key.ReadToEnd();
            
        }

        protected HttpResponseMessage GetData(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }

        protected string GetURL(string path)
        {
            return "https://" + Region + ".api.riotgames.com/lol/" + path + "?api_key=" + Key;
        }

    }
}
