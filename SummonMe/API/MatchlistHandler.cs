using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SummonMe.Models;

namespace SummonMe.API
{
    public class MatchlistHandler : ApiHandler
    {
        public MatchlistHandler(string region):base(region)
        {
        }
        public async Task<MatchlistDto> GetMatchlist(string encryptedId)
        {
            string path = "match/v4/matchlists/by-account/" + encryptedId + "?";

            string content = await GetData(GetURL(path));

            if (content != null)
            {
                return JsonConvert.DeserializeObject<MatchlistDto>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<MatchDto> GetMatch(string matchId)
        {
            string path = "match/v4/matches/" + matchId + "?";

            string content = await GetData(GetURL(path));

            if (content != null)
            {
                return JsonConvert.DeserializeObject<MatchDto>(content);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Queues>> GetQueues()
        {
            string content = await GetData("http://static.developer.riotgames.com/docs/lol/queues.json");

            if (content != null)
            {
                return JsonConvert.DeserializeObject<List<Queues>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
