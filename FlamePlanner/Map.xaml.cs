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

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Page
    {
        public Map()
        {
            InitializeComponent();
        }
        private void poi1_Click(object sender, RoutedEventArgs e)
        {
            MapEvent me = new MapEvent("6 Street SW");
            me.ShowDialog();
        }
        private void poi2_Click(object sender, RoutedEventArgs e)
        {
            MapEvent me = new MapEvent("Stampede");
            me.ShowDialog();
        }
        private void poi3_Click(object sender, RoutedEventArgs e)
        {
            MapEvent me = new MapEvent("Prince Island Park");
            me.ShowDialog();
        }
    }
}
