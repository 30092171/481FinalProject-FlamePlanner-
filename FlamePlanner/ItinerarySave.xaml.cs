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
    /// Interaction logic for ItinerarySave.xaml
    /// </summary>
    public partial class ItinerarySave : Window
    {
        private MainWindow mw;
        public ItinerarySave(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;

        }

        private void saveItineraryButton_Click(object sender, RoutedEventArgs e)
        {
            string itinName = itineraryNameField.Text;
            //Ensure field (itinerart name) has been populated by user (maybe suggest default)
            if (itinName != "")
            {
                itinerarySavePrompt ispw = new itinerarySavePrompt(mw);

                //Save itinerary in mw under name somehow

                this.Close();
                ispw.ShowDialog();
            }
        }
    }
}
