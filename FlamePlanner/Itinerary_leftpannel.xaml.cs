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
    /// Interaction logic for Itinerary_leftpannel.xaml
    /// </summary>
    public partial class Itinerary_leftpannel : Page
    {
        private MainWindow mw;
        public Itinerary_leftpannel(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
