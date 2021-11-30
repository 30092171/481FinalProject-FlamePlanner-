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
    /// Interaction logic for EventItineraryBanner.xaml
    /// </summary>
    public partial class EventItineraryBanner : UserControl
    {
        private MainWindow mw;
        private Itinerarypage ItinPage;
        private Itinerary_leftpannel leftPanel;
        public EventObject eventO = null;
        public EventItineraryBanner(MainWindow mw,Itinerarypage ip, Itinerary_leftpannel Il, EventObject e)
        {
            this.mw = mw;
            this.ItinPage = ip;
            this.leftPanel = Il;
            this.eventO = e;
            InitializeComponent();

            if (e.isVisible)
            {
                selectBox.IsChecked = true;
            }
            else
            {
                selectBox.IsChecked = false;
            }

            titleBlock.Text = e.eventName;
            dateBlock.Text = e.startDate.ToShortDateString();
            //dateBlock.Text = String.Format("{D2}/{D2}{D4}",e.startDate.Day,e.startDate.Month,e.startDate.Year);

            int s_min = e.startTime % 100;
            int s_hour = (e.startTime - s_min) / 100;
            int e_min = e.endTime % 100;
            int e_hour = (e.endTime - e_min) / 100;

            if (e.startTime < 1300)
            {
                if (s_hour == 0)
                {
                    s_hour = 12;
                }

                if (e.endTime < 1300)
                {
                    if (e.startTime < 1200)
                    {
                        timeBlock.Text = s_hour + ":" + s_min.ToString("D2") + " am - " + e_hour + ":" + e_min.ToString("D2") + " am";
                    }
                    else
                    {
                        timeBlock.Text = s_hour + ":" + s_min.ToString("D2") + " pm - " + e_hour + ":" + e_min.ToString("D2") + " am";
                    }
                }
                else
                {
                    if (e.startTime < 1200)
                    {
                        timeBlock.Text = s_hour + ":" + s_min.ToString("D2") + " am - " + (e_hour % 12) + ":" + e_min.ToString("D2") + " pm";
                    }
                    else
                    {
                        timeBlock.Text = s_hour + ":" + s_min.ToString("D2") + " pm - " + (e_hour % 12) + ":" + e_min.ToString("D2") + " pm";
                    }

                }
            }
            else
            {
                //End time must be > 1300
                timeBlock.Text = (s_hour % 12) + ":" + s_min.ToString("D2") + " pm - " + (e_hour % 12) + ":" + e_min.ToString("D2") + " pm";
            }

        }

        public Boolean isChecked()
        {
            return this.selectBox.IsChecked.Value;
        }

        public void setCheck(Boolean b)
        {
            if (b)
            {
                selectBox.IsChecked = true;
            }
            else
            {
                selectBox.IsChecked = false;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Delete Event from itinerary
            mw.bufferItinerary.eventList.Remove(eventO);
            leftPanel.eventPanel.Children.Remove(this);
            ItinPage.displayEvents(); //Displays events again to reflect deletion
        }

        private void selectBox_Click(object sender, RoutedEventArgs e)
        {
            //This click should either select or unselect the checkbox
            if (isChecked())
            {
                eventO.isVisible = true;
                ItinPage.displayEvents(); //Displays events again to reflect new visible event
            }
            else
            {
                eventO.isVisible = false;
                ItinPage.displayEvents(); //Displays events again to reflect new visible event
            }
        }

        private void expandButton_Click(object sender, RoutedEventArgs e)
        {
            //Connect to window display
        }
    }
}
