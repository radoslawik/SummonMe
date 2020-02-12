using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummonMe.Models;
using Newtonsoft.Json;

namespace SummonMe.API
{
    public class ChampionMasteryHandler : ApiHandler
    {
        public ChampionMasteryHandler(string region) : base(region)
        {
        }
        public async Task<List<ChampionMasteryDTO>> GetChampionMasteries(string summonerId)
        {
            string path = "champion-mastery/v4/champion-masteries/by-summoner/" + summonerId;
            string content = await GetData(GetURL(path));

            if (content != null)
            {
                return JsonConvert.DeserializeObject<List<ChampionMasteryDTO>>(content);
            }
            else
            {
                return null;
            }
        }

        public ChampionMasteryDTO GetMostMasteryChamp(List<ChampionMasteryDTO> list)
        {
            int max_points = 0;
            ChampionMasteryDTO retval = null;

            foreach (var champMast in list)
            {
                if(champMast.ChampionPoints > max_points)
                {
                    max_points = champMast.ChampionPoints;
                    retval = champMast;
                }
            }

            return retval;

        }
    }
}
