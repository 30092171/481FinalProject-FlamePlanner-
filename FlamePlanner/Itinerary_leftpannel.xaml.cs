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
        private Itinerarypage ItinPage;
        public Itinerary_leftpannel(MainWindow mw, Itinerarypage ip)
        {
            this.mw = mw;
            this.ItinPage = ip;
            InitializeComponent();
            populateEventPanel();
        }

        private void populateEventPanel()
        {
            foreach (EventObject e in mw.bufferItinerary.eventList)
            {
                EventItineraryBanner eib = new EventItineraryBanner(mw, ItinPage, this, e);
                eventPanel.Children.Add(eib);
            }
        }

        /// <summary>
        /// This function ensures checks match the visibility of each event, Could occur when a conflict is detected
        /// </summary>
        public void redoCheckboxSelections()
        {
            foreach (object o in eventPanel.Children)
            {
                if (o != null && o.GetType() == typeof(EventItineraryBanner))
                {
                    EventItineraryBanner e = o as EventItineraryBanner;
                    e.setCheck(e.eventO.isVisible); //sets check to reflect whether it should be visible or not
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            deleteConfirmation dc = new deleteConfirmation(mw);
            dc.ShowDialog();
        }
    }
}
