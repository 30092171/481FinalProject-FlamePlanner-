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
    /// Interaction logic for Event_left.xaml
    /// </summary>
    public partial class Event_left : Page
    {
        private MainWindow mw;
        public Event_left(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void createNewItineraryButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
