using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonMe.Models
{
    public class ChampionInfo
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
    }

    public class Champion
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
