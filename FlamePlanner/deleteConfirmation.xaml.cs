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
using System.Windows.Shapes;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for deleteConfirmation.xaml
    /// </summary>
    public partial class deleteConfirmation : Window
    {
        private MainWindow mw;
        public deleteConfirmation(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Delete Itinerary From MainWind
            this.Close();
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            //Go back
            this.Close();
        }
    }
}
