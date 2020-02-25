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
        public bool HotStreak { get; set; }
        public bool Veteran { get; set; }
        public string Rank { get; set; }
        public int LeaguePoints { get; set; }
        public string SummonerId { get; set; }
        public bool Inactive { get; set; }
        public bool FreshBlood { get; set; }
        public MiniSeriesDTO MiniSeries { get; set; }
    }
}
