using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummonMe.Models;

namespace SummonMe.View
{
    public class ViewManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
  
        }

        string region;
        public string Region
        {
            get { return region; }
            set { region = value; NotifyPropertyChanged("Region"); }
        }

        string summonerName;
        public string SummonerName
        {
            get { return summonerName; }
            set { summonerName = value; NotifyPropertyChanged("SummonerName"); }
        }

        private LeagueEntryDTO leagueEntry;
        public LeagueEntryDTO LeagueEntry
        {
            get { return leagueEntry; }
            set { leagueEntry = value; NotifyPropertyChanged("LeagueEntry"); }
        }

        private MatchlistDto matchlistEntry;
        public MatchlistDto MatchlistEntry
        {
            get { return matchlistEntry; }
            set { matchlistEntry = value; NotifyPropertyChanged("MatchlistEntry"); }
        }

        private SummonerDTO summonerEntry;
        public SummonerDTO SummonerEntry
        {
            get { return summonerEntry; }
            set { summonerEntry = value; NotifyPropertyChanged("SummonerEntry"); }
        }

        private CurrentGameInfo currentGameEntry;

        public CurrentGameInfo CurrentGameEntry 
        {
            get { return currentGameEntry; }
            set { currentGameEntry = value; NotifyPropertyChanged("CurrentGameInfo"); }
        }

        private List<ChampionMasteryDTO> championMasteryEntry;
        public List<ChampionMasteryDTO> ChampionMasteryEntry
        {
            get { return championMasteryEntry; }
            set { championMasteryEntry = value; NotifyPropertyChanged("ChampionMasteryEntry"); }
        }

        private List<string> champNames;
        public List<string> ChampNames
        {
            get { return champNames; }
            set { champNames = value; NotifyPropertyChanged("ChampNames"); }
        }

        private string emblemPath;
        public string EmblemPath
        {
            get { return emblemPath; }
            set { emblemPath = value; NotifyPropertyChanged("EmblemPath"); }
        }

        private string champIconPath;
        public string ChampIconPath
        {
            get { return champIconPath; }
            set { champIconPath = value; NotifyPropertyChanged("ChampIconPath"); }
        }

        private string profileIconPath;
        public string ProfileIconPath
        {
            get { return profileIconPath; }
            set { profileIconPath = value; NotifyPropertyChanged("ProfileIconPath"); }
        }

        private string winrate;
        public string Winrate
        {
            get { return winrate; }
            set { winrate = value; NotifyPropertyChanged("Winrate"); }

        }

    }

}
