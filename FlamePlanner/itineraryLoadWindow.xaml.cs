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
    /// Interaction logic for itineraryLoadWindow.xaml
    /// </summary>
    public partial class itineraryLoadWindow : Window
    {
        private MainWindow mw;
        public itineraryLoadWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void loadItinerary_Click(object sender, RoutedEventArgs e)
        {
            if (itineraryList.SelectedItem != null)
            {
                string selectedName = itineraryList.SelectedItem.ToString();
                //Communicate to mw here somehow to load itinerary
                this.Close();
            }
        }

        private void itineraryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Load preview frame here
            string selection = itineraryList.SelectedItem.ToString();

            //Somehow indicate to the main window which itinerary should be loaded

            Itinerarypage ip = new Itinerarypage(mw);
            ip.customEventButton.Visibility = Visibility.Collapsed; //Hides + button as it is a preview
            this.previewFrame.Content = ip;

        }
    }
}
