using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.Models
{
    public class CurrentGameInfo
    {
        public long GameId { get; set; }
        public long GameStartTime { get; set; }
        public string PlatformId { get; set; }
        public string GameMode { get; set; }
        public long MapId { get; set; }
        public string GameType { get; set; }
        public long gameLength { get; set; }
        public long GameQueueConfigId { get; set; }
    }
}
