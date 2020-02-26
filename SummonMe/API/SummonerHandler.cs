using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SummonMe.Models;

namespace SummonMe.API
{
    // SUMMONER_V4 API
    public class SummonerHandler : ApiHandler
    {
        public SummonerHandler(string region) : base(region)
        {
        }

        public async Task<SummonerDTO> GetSummoner(string name)
        {
            string path = "summoner/v4/summoners/by-name/" + name + "?";

            string content = await GetData(GetURL(path));

            if (content != null)
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
