using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummonMe.Models;
using Newtonsoft.Json;

namespace SummonMe.API
{
    public class LeagueEntryHandler : ApiHandler
    {
        public LeagueEntryHandler(string region) : base(region)
        {
        }

        public async Task<List<LeagueEntryDTO>> GetLeagueEntry(string summonerId)
        {
            string path = "league/v4/entries/by-summoner/" + summonerId;
            string content = await GetData(GetURL(path));

            if (content != null)
            {
                return JsonConvert.DeserializeObject<List<LeagueEntryDTO>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
