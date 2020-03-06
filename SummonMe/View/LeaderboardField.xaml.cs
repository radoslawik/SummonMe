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

namespace SummonMe.View
{
    /// <summary>
    /// Interaction logic for LeaderboardField.xaml
    /// </summary>
    public partial class LeaderboardField : Grid
    {
        public LeaderboardField(string playerName, int wins, int loses, int lp, int rank)
        {
            InitializeComponent();
            if(rank % 2 == 0)
            {
                gMain.Margin = new Thickness(40, 0, 0, 0);
            }
            else
            {
                gMain.Margin = new Thickness(-40, 0, 0, 0);
            }

            tbRank.Text = rank.ToString();
            tbName.Text = playerName;
            tbWins.Text = "WINS: " + wins.ToString();
            tbLosses.Text = "LOSSES: " + loses.ToString();
            tbPoints.Text = "LEAGUE POINTS: " + lp.ToString();
            
        }
    }
}
