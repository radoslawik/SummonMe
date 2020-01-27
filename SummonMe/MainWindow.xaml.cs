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
        Profile viewProfile;
        public MainWindow()
        {
            
            viewProfile = new Profile();
            InitializeComponent();

            this.DataContext = viewProfile;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SummonerHandler summoner_handler = new SummonerHandler("EUN1");
            var summoner = summoner_handler.GetSummoner("mitr0vav0");

            Console.WriteLine("name, level, revisiondate(seconds), special id");
            Console.WriteLine(summoner.Name);
            Console.WriteLine(summoner.SummonerLevel);
            Console.WriteLine(summoner.RevisionDate);
            Console.WriteLine(summoner.Puuid);
        }
    }
}
