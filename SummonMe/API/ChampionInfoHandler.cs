using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummonMe.Models;

namespace SummonMe.API
{
    public class ChampionInfoHandler : ApiHandler
    {
        public ChampionInfoHandler() : base()
        {
        }
        public async Task<ChampionInfo> GetChampionData()
        {
            string path = "http://ddragon.leagueoflegends.com/cdn/10.4.1/data/en_US/champion.json";
            string content = await GetData(path);

            if (content != null)
            {
                return JsonConvert.DeserializeObject<ChampionInfo>(content);
            }
            else
            {
                return null;
            }
        }

        public Dictionary<string,string> ParseChampionData(Dictionary<string, Champion> data)
        {
            Dictionary<string, string> champNames = new Dictionary<string, string>();

            if (data != null)
            {
                foreach (KeyValuePair<string, Champion> kvp in data)
                {
                    champNames.Add(kvp.Value.Key, kvp.Value.Id);
                }
            }
            return champNames;
        }
    }
}
