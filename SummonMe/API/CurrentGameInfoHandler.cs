using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SummonMe.Models;

namespace SummonMe.API
{
    public class CurrentGameInfoHandler : ApiHandler
    {
        public CurrentGameInfoHandler(string region) : base(region)
        {
        }
        public async Task<CurrentGameInfo> GetCurrentGame(string summonerId)
        {
            string path = "spectator/v4/active-games/by-summoner/" + summonerId + "?";

            string content = await GetData(GetURL(path));

            if (content != null)
            {
                return JsonConvert.DeserializeObject<CurrentGameInfo>(content);
            }
            else
            {
                return null;
            }
        }

    }
}
