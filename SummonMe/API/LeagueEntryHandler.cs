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

        public List<LeagueEntryDTO> GetLeagueEntry(string summonerId)
        {
            string path = "league/v4/entries/by-summoner/" + summonerId;
            var response = GetData(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
