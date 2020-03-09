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
    /// Interaction logic for General.xaml
    /// </summary>
    public partial class General : Page
    {
        public General(ViewManager viewManager)
        {

            InitializeComponent();
            this.DataContext = viewManager;

            if (viewManager.LeagueEntry.FreshBlood)
                Badges.Children.Add(new Badge("FRESHMAN", MaterialDesignThemes.Wpf.PackIconKind.NewBox));
            if (viewManager.LeagueEntry.Veteran)
                Badges.Children.Add(new Badge("VETERAN", MaterialDesignThemes.Wpf.PackIconKind.ShieldStar));
            if (viewManager.LeagueEntry.HotStreak)
                Badges.Children.Add(new Badge("WINSTREAK", MaterialDesignThemes.Wpf.PackIconKind.Fire));
            if (viewManager.LeagueEntry.MiniSeries != null)
                Badges.Children.Add(new Badge("SERIES", MaterialDesignThemes.Wpf.PackIconKind.SmileyCool));
            if (viewManager.LeagueEntry.Tier.Equals("Unranked"))
                if (viewManager.SummonerEntry.SummonerLevel < 30)
                    Badges.Children.Add(new Badge("AMATEUR", MaterialDesignThemes.Wpf.PackIconKind.BookOpenPageVariant));
                else
                    Badges.Children.Add(new Badge("NEWBIE", MaterialDesignThemes.Wpf.PackIconKind.BookOpenPageVariant));
        }

    }
}
