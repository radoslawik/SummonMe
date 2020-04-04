using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SummonMe.API;
using SummonMe.Models;
using SummonMe.View;

namespace SummonMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseModelView viewProfile;
        SummonerHandler summoner_handler;
        LeagueEntryHandler league_entry_handler;
        ChampionMasteryHandler champ_mastery_handler;
        ChampionInfoHandler champion_data_handler;
        MatchlistHandler matchlist_handler;
        LeaderboardsHandler lb_handler;

        public MainWindow()
        {

            viewProfile = new BaseModelView();
            InitializeComponent();

            this.DataContext = viewProfile;
            Main.Content = new InfoError("Hello! Use the panel above to search for the summoner");

            MenuBar.Visibility = Visibility.Hidden;
            GeneralButton.Foreground = Brushes.Purple;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(viewProfile.SummonerName) || string.IsNullOrEmpty(viewProfile.Region))
            {
                viewProfile.LeagueEntry = null;
                Show_Notification("Please provide correct summoner name and/or region");
                return;
            }

            Show_Notification("Loading...");
            General_Click(sender, e);
        }

        private async void General_Click(object sender, RoutedEventArgs e)
        {
            ChampionButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.MediumPurple;
            GeneralButton.Foreground = Brushes.Purple;
            LiveButton.Foreground = Brushes.MediumPurple;

            summoner_handler = new SummonerHandler(viewProfile.Region);
            SummonerDTO summoner = await summoner_handler.GetSummoner(viewProfile.SummonerName);
            if (summoner == null)
            {
                Console.WriteLine("Summoner was null...");
                Show_Notification(summoner_handler.ErrorMsg);
                return;
            }
            viewProfile.SummonerEntry = summoner;
            viewProfile.ProfileIconPath = "http://ddragon.leagueoflegends.com/cdn/10.4.1/img/profileicon/" + (summoner.ProfileIconId).ToString() + ".png";

            league_entry_handler = new LeagueEntryHandler(viewProfile.Region);
            List<LeagueEntryDTO> league_entries = await league_entry_handler.GetLeagueEntry(summoner.Id);
            if (league_entry_handler.ErrorMsg != "")
            {
                Show_Notification(league_entry_handler.ErrorMsg);
                return;
            }
            if (league_entries == null)
            {
                Show_Notification("No league data to display");
                return;
            }
            LeagueEntryDTO league_entry = league_entries.Where(p => p.QueueType.Equals("RANKED_SOLO_5x5")).FirstOrDefault();
            if (league_entry == null)
            {
                league_entry = new LeagueEntryDTO();
                league_entry.MiniSeries = null;
                league_entry.HotStreak = false;
                league_entry.FreshBlood = false;
                league_entry.Veteran = false;
                league_entry.Wins = 0;
                league_entry.Losses = 0;
                league_entry.Rank = "";
                league_entry.Tier = "Unranked";
                league_entry.LeaguePoints = 0;
                viewProfile.Winrate = "0";
            }
            else
            {
                viewProfile.Winrate = (100 * league_entry.Wins / (league_entry.Losses + league_entry.Wins)).ToString();
            }

            viewProfile.LeagueEntry = league_entry;
            viewProfile.EmblemPath = "pack://application:,,,/Assets/Emblem/Emblem_" + league_entry.Tier + ".png";

            champion_data_handler = new ChampionInfoHandler();
            ChampionInfo champData = await champion_data_handler.GetChampionData();
            viewProfile.FullChampionNames = champion_data_handler.ParseChampionData(champData.Data);

            MenuBar.Visibility = Visibility.Visible;
            Main.Content = new General(viewProfile);
        }
        private async void Match_Click(object sender, RoutedEventArgs e)
        {
            GeneralButton.Foreground = Brushes.MediumPurple;
            ChampionButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.Purple;
            LiveButton.Foreground = Brushes.MediumPurple;
            Show_Notification("Loading...", false);

            matchlist_handler = new MatchlistHandler(viewProfile.Region);
            MatchlistDto matchlist_entry = await matchlist_handler.GetMatchlist(viewProfile.SummonerEntry.AccountId);
            List<MatchDto> matchData = new List<MatchDto>();
            if (matchlist_entry.Matches.Count >= 7)
            {
                for (int i = 0; i < 7; i++)
                {
                    long gameId = matchlist_entry.Matches[i].GameId;
                    MatchDto match_entry = await matchlist_handler.GetMatch(gameId.ToString());
                    matchData.Add(match_entry);
                }
            }
            else if (matchlist_entry.Matches.Count > 0)
            {
                for (int i = 0; i < matchlist_entry.Matches.Count; i++)
                {
                    long gameId = matchlist_entry.Matches[i].GameId;
                    MatchDto match_entry = await matchlist_handler.GetMatch(gameId.ToString());
                    matchData.Add(match_entry);
                }
            }

            List<Queues> queueData = await matchlist_handler.GetQueues();


            if (matchlist_handler.ErrorMsg != "")
            {
                Show_Notification(matchlist_handler.ErrorMsg);
                return;
            }

            viewProfile.MatchlistEntry = matchlist_entry;
            viewProfile.MatchEntries = matchData;
            viewProfile.AllQueuesList = queueData;

            if (viewProfile.MatchEntries.Count > 0)
            {
                Main.Content = new MatchHistory(viewProfile);
            }
            else
            {
                Show_Notification("No match history to display", false);
            }
            
        }
        private async void Champion_Click(object sender, RoutedEventArgs e)
        {
            GeneralButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.MediumPurple;
            ChampionButton.Foreground = Brushes.Purple;
            LiveButton.Foreground = Brushes.MediumPurple;
            Show_Notification("Loading...", false);

            champ_mastery_handler = new ChampionMasteryHandler(viewProfile.Region);
            List<ChampionMasteryDTO> champ_masteries = await champ_mastery_handler.GetChampionMasteries(viewProfile.SummonerEntry.Id);
            List<ChampionMasteryDTO> most_points_champ = new List<ChampionMasteryDTO>();
            if (champ_masteries.Count < 3)
            {
                Console.WriteLine(champ_masteries.Count);
                most_points_champ = champ_masteries;
            }
            else
            {
                most_points_champ = champ_masteries.GetRange(0, 3);
            }
            viewProfile.ChampionMasteryEntry = most_points_champ;

            List<string> championNames = new List<string>();
            for (int i = 0; i < most_points_champ.Count; i++)
            {
                championNames.Add(viewProfile.FullChampionNames[most_points_champ[i].ChampionId.ToString()]);
            }
            viewProfile.ChampNames = championNames;

            if (viewProfile.ChampionMasteryEntry.Count > 0)
            {
                Main.Content = new ChampionMastery(viewProfile);
            }
            else
            {
                Show_Notification("Not enough champion mastery data to display", false);
            }
            
        }

        private async void Live_Click(object sender, RoutedEventArgs e)
        {
            GeneralButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.MediumPurple;
            ChampionButton.Foreground = Brushes.MediumPurple;
            LiveButton.Foreground = Brushes.Purple;
            Show_Notification("Loading...", false);

            lb_handler = new LeaderboardsHandler(viewProfile.Region);
            List<LeagueEntryDTO> lb = await lb_handler.GetChallengerRanking();
            if (lb == null)
            {
                Show_Notification("Problem with challenger ranking");
                return;
            }

            viewProfile.ChallengerRanking = lb;

            Main.Content = new Leaderboard(viewProfile);
        }

        private void Show_Notification(string err_msg, bool hide = true)
        {
            Main.Content = new InfoError(err_msg);
            if(hide) MenuBar.Visibility = Visibility.Hidden;
        }
    }
}
