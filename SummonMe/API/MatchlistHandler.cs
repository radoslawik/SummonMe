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
            string path = "match/v4/matchlists/by-account/" + encryptedId;

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
    }
}
