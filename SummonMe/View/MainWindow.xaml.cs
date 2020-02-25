using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        ViewManager viewProfile;
        public MainWindow()
        {

            viewProfile = new ViewManager();
            InitializeComponent();

            this.DataContext = viewProfile;
            Main.Content = new InfoError("Hello! Use the panel above to search for the summoner");

            MenuBar.Visibility = Visibility.Hidden;

            GeneralButton.Foreground = Brushes.Purple;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(viewProfile.SummonerName) || string.IsNullOrEmpty(viewProfile.Region))
            {
                viewProfile.LeagueEntry = null;
                Show_Notification("Please provide correct summoner name and/or region");
                Console.WriteLine("Provide correct summoner name and/or region");
                return;
            }
            Show_Notification("Loading...");

            SummonerHandler summoner_handler = new SummonerHandler(viewProfile.Region);
            SummonerDTO summoner = await summoner_handler.GetSummoner(viewProfile.SummonerName);
            if(summoner == null)
            {
                Console.WriteLine("Summoner was null...");
                Show_Notification(summoner_handler.ErrorMsg);
                return;
            }
            viewProfile.SummonerEntry = summoner;
            viewProfile.ProfileIconPath = "http://ddragon.leagueoflegends.com/cdn/10.4.1/img/profileicon/" + (summoner.ProfileIconId).ToString() + ".png";

            LeagueEntryHandler league_entry_handler = new LeagueEntryHandler(viewProfile.Region);
            List<LeagueEntryDTO> league_entries = await league_entry_handler.GetLeagueEntry(summoner.Id);
            if (league_entries == null)
            {
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
            

            Console.WriteLine("Ranked winrate");
            Console.WriteLine(viewProfile.Winrate);

            MatchlistHandler matchlist_handler = new MatchlistHandler(viewProfile.Region);
            MatchlistDto matchlist_entry = await matchlist_handler.GetMatchlist(summoner.AccountId);

            if (matchlist_entry == null)
            {
                Show_Notification("No match history to display");
                return;
            }
            //Console.WriteLine(matchlist_entry.TotalGames);

            viewProfile.MatchlistEntry = matchlist_entry;

            CurrentGameInfoHandler current_game_handler = new CurrentGameInfoHandler(viewProfile.Region);
            CurrentGameInfo current_game_entry = await current_game_handler.GetCurrentGame(summoner.Id);

            //Console.WriteLine("Test For currentGame Handler");
            //Console.WriteLine(current_game_entry.GameId);
            

            viewProfile.CurrentGameEntry = current_game_entry;

            ChampionMasteryHandler champ_mastery_handler = new ChampionMasteryHandler(viewProfile.Region);
            List<ChampionMasteryDTO> champ_masteries = await champ_mastery_handler.GetChampionMasteries(summoner.Id);
            if (champ_masteries == null)
            {
                return;
            }
            ChampionMasteryDTO most_points_champ = champ_masteries.First();
            viewProfile.ChampionMasteryEntry = most_points_champ;
            // viewProfile.ChampIconPath = "http://ddragon.leagueoflegends.com/cdn/10.3.1/img/champion/" + most_points_champ.ChampionId + ".png";
            // championID is a number, we need string, API is not useful here :(
            // viewProfile.ChampIconPath = "http://ddragon.leagueoflegends.com/cdn/10.3.1/img/champion/" + "Nidalee" + ".png";


            Console.WriteLine("summoner name, region");
            Console.WriteLine(viewProfile.SummonerName);
            Console.WriteLine(viewProfile.Region);
            
            Console.WriteLine("name, level, revisiondate(seconds), special id");
            Console.WriteLine(summoner.Name);
            Console.WriteLine(summoner.SummonerLevel);
            Console.WriteLine(summoner.RevisionDate);
            Console.WriteLine(summoner.Puuid);
            Console.WriteLine(summoner.Id);


            Console.WriteLine("champion mastery dto");
            Console.WriteLine(most_points_champ.ChampionId);
            Console.WriteLine(most_points_champ.ChampionLevel);

            MenuBar.Visibility = Visibility.Visible;
            Main.Content = new General(viewProfile);


        }

        private void General_Click(object sender, RoutedEventArgs e)
        {
            ChampionButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.MediumPurple;
            GeneralButton.Foreground = Brushes.Purple;
            LiveButton.Foreground = Brushes.MediumPurple;
            Main.Content = new General(viewProfile);
        }
        private void Match_Click(object sender, RoutedEventArgs e)
        {
            GeneralButton.Foreground = Brushes.MediumPurple;
            ChampionButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.Purple;
            LiveButton.Foreground = Brushes.MediumPurple;
            Main.Content = new MatchHistory(viewProfile);
        }
        private void Champion_Click(object sender, RoutedEventArgs e)
        {
            GeneralButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.MediumPurple;
            ChampionButton.Foreground = Brushes.Purple;
            LiveButton.Foreground = Brushes.MediumPurple;
            Main.Content = new ChampionMastery(viewProfile);
        }

        private void Live_Click(object sender, RoutedEventArgs e)
        {
            GeneralButton.Foreground = Brushes.MediumPurple;
            MatchButton.Foreground = Brushes.MediumPurple;
            ChampionButton.Foreground = Brushes.MediumPurple;
            LiveButton.Foreground = Brushes.Purple;

            if (viewProfile.CurrentGameEntry == null)
            {
                Show_Notification("No current game to display", false);
                return;
            }
            else
            {
                Main.Content = new CurrentGame(viewProfile);
            }

        }

        private void Show_Notification(string err_msg, bool hide = true)
        {
            Main.Content = new InfoError(err_msg);
            if(hide) MenuBar.Visibility = Visibility.Hidden;
        }
    }
}
