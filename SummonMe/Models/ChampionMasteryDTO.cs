using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.Models
{
    public class ChampionMasteryDTO
    {
        public bool ChestGranted { get; set; }
        public int ChampionLevel { get; set; }
        public int ChampionPoints { get; set; }
        public long ChampionId { get; set; }
        public long ChampionPointsUntilNextLevel { get; set; }
        public long LastPlayTime { get; set; }
        public int TokensEarned { get; set; }
        public long ChampionPointsSinceLastLevel { get; set; }
        public string SummonerId { get; set; }

}
}
