using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.Models
{
    // https://developer.riotgames.com/apis#league-v4/GET_getLeagueEntriesForSummoner
    public class LeagueEntryDTO
    {
        public string QueueType { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Tier { get; set; }
    }
}
