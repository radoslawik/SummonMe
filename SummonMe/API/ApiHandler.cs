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
        public string ErrorMsg = "";

        public ApiHandler(string region)
        {
            Region = region;
            StreamReader read_key = new StreamReader("API/YourDeveloperKey.txt");
            Key = read_key.ReadToEnd();
            
        }

        public async Task<string> GetData(string URL)
        {
            string responseBody = "";
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(response.StatusCode);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                ErrorMsg = e.Message;
            }
            return responseBody;
        }

        protected string GetURL(string path)
        {
            return "https://" + Region + ".api.riotgames.com/lol/" + path + "?api_key=" + Key;
        }

    }
}
