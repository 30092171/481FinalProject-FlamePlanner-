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
    /// Interaction logic for EventSearchCalgaryFlames.xaml
    /// </summary>
    public partial class EventSearchCalgaryFlames : Page
    {
        private MainWindow mw;
        public EventSearchCalgaryFlames(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs ea)
        {
            //EventObject eventObject = new EventObject();
            //eventObject.eventName = "Calgary Flames Game";
            //eventObject.eventDetails = "For almost four decades, the Flames have been electrifying hockey fans in southern Alberta. In that time, not only has the team established itself as a successful NHL franchise, \nbut it has grown into a vital and integral part of our community.\nFrom their on - ice victories and awards to their off - ice charitable endeavours, the Flames have become one of the premier professional sports organizations in North America.";
            //eventObject.eventLocation = "Scotiabank Saddledome (555 Saddledome Rise SE, Calgary, AB T2G 2W1)";
            //eventObject.startDate = new DateTime(2021,09,15);
            //eventObject.startTime = 1900;
            //eventObject.endTime = 2200;
            EventObject eventObject = AllEvents.CalgaryFlames;

            foreach (EventObject e in mw.bufferItinerary.eventList)
            {
                if (e.eventName == eventObject.eventName && e.eventDetails == eventObject.eventDetails && e.eventLocation == eventObject.eventLocation && e.filterID == eventObject.filterID)
                {
                    return;
                }
            }

            mw.bufferItinerary.eventList.Add(eventObject);

            if (mw.mainFrame.Content.GetType() == typeof(threeFramePage))
            {
                if ((mw.mainFrame.Content as threeFramePage).leftFrame.Content.GetType() == typeof(Event_left))
                {
                    Event_left el = new Event_left(mw); //This reloads the single day itinerary off the new buffer
                    (mw.mainFrame.Content as threeFramePage).leftFrame.Content = el;
                }
            }
        }

        private void Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //EventPopUpWindow epw = new EventPopUpWindow(mw)
            //    .SetTitle("Calgary Flames Game")
            //    .SetImage(new BitmapImage(new Uri("CalgaryFlamesEvent.jpg", UriKind.Relative)))
            //    .SetTime("7:00 PM - 10:00 PM")
            //    .SetDate("September 15, 2021")
            //    .SetLocation("Scotiabank Saddledome (555 Saddledome Rise SE, Calgary, AB T2G 2W1)")
            //    .SetDescription("For almost four decades, the Flames have been electrifying hockey fans in southern Alberta. In that time, not only has the team established itself as a successful NHL franchise, \nbut it has grown into a vital and integral part of our community.\nFrom their on - ice victories and awards to their off - ice charitable endeavours, the Flames have become one of the premier professional sports organizations in North America.")
            //    .SetLinks("https://www.nhl.com/flames");
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.CalgaryFlames);
            epw.ShowDialog();
        }

        private void Event_Up_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreenFoodAndDrink eventscreenfoodanddrink = new EventScreenFoodAndDrink(mw);
            this.NavigationService.Navigate(eventscreenfoodanddrink);
        }

        private void Event_Down_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreenSpecialEvents eventscreenspecialevents = new EventScreenSpecialEvents(mw);
            this.NavigationService.Navigate(eventscreenspecialevents);
        }
    }
}
