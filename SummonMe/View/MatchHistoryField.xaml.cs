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
    /// Interaction logic for MatchHistoryField.xaml
    /// </summary>
    public partial class MatchHistoryField : Grid
    {
        public MatchHistoryField(string champName, string posName, string roleName,
            string mapName, string playedWhen, string gameDuration, string result, string playerStats)
        {
            InitializeComponent();
            tbChampName.Text = champName;

            string champImg = "http://ddragon.leagueoflegends.com/cdn/10.5.1/img/champion/" + champName + ".png";
            BitmapImage champImage = new BitmapImage(new Uri(champImg));
            ImageBrush champBackgroudImage = new ImageBrush(champImage);
            champBackgroudImage.Stretch = Stretch.UniformToFill;
            bChampIcon.Background = champBackgroudImage;
            string posImg = "";

            if (posName.Equals("BOTTOM"))
            {
                posImg = "pack://application:,,,/Assets/GamePositions/" + posName + "_" + roleName + ".png";
            }
            else
            {
                posImg = "pack://application:,,,/Assets/GamePositions/" + posName + ".png";
            }
            BitmapImage positionImage = new BitmapImage(new Uri(posImg));
            ImageBrush posImage = new ImageBrush(positionImage);
            posImage.Stretch = Stretch.UniformToFill;
            bPosIcon.Background = posImage;

            tbMapName.Text = mapName;
            tbPlayedWhen.Text = playedWhen;
            tbGameDuration.Text = gameDuration;
            tbResult.Text = result;
            if (result.Equals("WIN"))
            {
                bResult.Background = Brushes.ForestGreen;
                bResult.BorderBrush = Brushes.Green;
                tbResult.Foreground = Brushes.Green;
            }
            else
            {
                bResult.Background = Brushes.Red;
                bResult.BorderBrush = Brushes.DarkRed;
                tbResult.Foreground = Brushes.Red;
            }

            tbKDA.Text = playerStats;
            
        }
    }
}
