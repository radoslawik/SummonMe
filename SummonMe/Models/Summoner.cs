using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.Models
{
    // https://developer.riotgames.com/apis#summoner-v4/GET_getBySummonerName more info here
    public class SummonerDTO
    {
        public int ProfileIconId { get; set; }
        public string Name { get; set; }
        public string Puuid { get; set; }
        public long SummonerLevel { get; set; }
        public long RevisionDate { get; set; }

    }
}
