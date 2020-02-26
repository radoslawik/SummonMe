using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummonMe.Models;
using Newtonsoft.Json;

namespace SummonMe.API
{
    public class LeaderboardsHandler : ApiHandler
    {
        public LeaderboardsHandler(string region) : base(region)
        {
        }

        public async Task<List<LeagueEntryDTO>> GetChallengerRanking()
        {
            string path = "league-exp/v4/entries/RANKED_SOLO_5x5/CHALLENGER/I?page=1&";
            Console.WriteLine(GetURL(path));
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
