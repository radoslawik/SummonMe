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
    /// Interaction logic for CurrentGame.xaml
    /// </summary>
    public partial class CurrentGame : Page
    {
        public CurrentGame(ViewManager viewManager)
        {
            InitializeComponent();
            this.DataContext = viewManager;
        }
    }
}
