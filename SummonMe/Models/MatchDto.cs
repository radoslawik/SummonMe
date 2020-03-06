using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.Models
{
    public class MatchDto
    {
        public int QueueId { get; set; }
        public int Champion { get; set; }
        public List<TeamStatsDto> Teams{ get; set; }
        public List<ParticipantDto> Participants { get; set; }
        public long GameDuration { get; set; }
    }

    public class Queues
    {
        public int QueueId { get; set; }
        public string  Map { get; set; }
    }

    public class TeamStatsDto
    {
        public string Win { get; set; }
        public int TeamId { get; set; }
    }

    public class ParticipantDto
    {
        public int ChampionId { get; set; }
        public ParticipantStatsDto Stats { get; set; }
        public int TeamId { get; set; }

    }

    public class ParticipantStatsDto
    {
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Deaths { get; set; }
    }


}
