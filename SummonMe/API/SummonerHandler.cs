using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SummonMe.Models;

namespace SummonMe.API
{
    public class SummonerHandler : ApiHandler
    {
        public SummonerHandler(string region) : base(region)
        {
        }

        public SummonerDTO GetSummoner(string name)
        {
            string path = "summoner/v4/summoners/by-name/" + name;

            var response = GetData(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<SummonerDTO>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
