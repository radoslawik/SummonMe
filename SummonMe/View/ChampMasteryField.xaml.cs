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
    /// Interaction logic for ChampMasteryField.xaml
    /// </summary>
    public partial class ChampMasteryField : Grid
    {
        public ChampMasteryField(string champName, int champPoints, int champLevel)
        {
            InitializeComponent();
            championLevelText.Text = champLevel.ToString();
            championNameText.Text = champName;
            championPointsText.Text = champPoints.ToString();

            string masteryLevelIcon = "pack://application:,,,/Assets/ChampionMastery/Champion_Mastery_Level_" + champLevel + "_Flair.png";
            BitmapImage masteryEmblem = new BitmapImage(new Uri(masteryLevelIcon));
            levelMasteryImage.Source = masteryEmblem;

            string masteryChampImg = "http://ddragon.leagueoflegends.com/cdn/img/champion/splash/" + champName + "_0.jpg";
            BitmapImage champImage = new BitmapImage(new Uri(masteryChampImg));
            ImageBrush champBackgroudImage = new ImageBrush(champImage);
            champBackgroudImage.Stretch = Stretch.UniformToFill;
            masteryField.Background = champBackgroudImage;
        }
    }
};
