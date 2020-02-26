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
    /// Interaction logic for ChampionMastery.xaml
    /// </summary>
    public partial class ChampionMastery : Page
    {
        public ChampionMastery(ViewManager viewManager)
        {

            InitializeComponent();
            this.DataContext = viewManager;
            BestChamps.Children.Add(new ChampMasteryField(viewManager.ChampNames[0],
                viewManager.ChampionMasteryEntry[0].ChampionPoints,
                viewManager.ChampionMasteryEntry[0].ChampionLevel));
            BestChamps.Children.Add(new ChampMasteryField(viewManager.ChampNames[1],
                viewManager.ChampionMasteryEntry[1].ChampionPoints,
                viewManager.ChampionMasteryEntry[1].ChampionLevel));
            BestChamps.Children.Add(new ChampMasteryField(viewManager.ChampNames[2],
                viewManager.ChampionMasteryEntry[2].ChampionPoints,
                viewManager.ChampionMasteryEntry[2].ChampionLevel));
        }
    }
}
