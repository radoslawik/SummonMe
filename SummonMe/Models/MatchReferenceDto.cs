using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.Models
{
    public class MatchReferenceDto
    {
        public string Lane { get; set;}
        public long GameId { get; set;}
        public int Champion { get; set;}
        public string PlatformID { get; set;}
        public int Season { get; set; }
        public int Queue { get; set; }
        public string Role { get; set; }
        public long Timestamp { get; set; }
    }
}
