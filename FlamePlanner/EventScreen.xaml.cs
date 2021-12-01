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
    /// Interaction logic for EventScreen.xaml
    /// </summary>
    public partial class EventScreen : Page
    {
        private MainWindow mw;

        public EventScreen(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Tag; //allows for us to determine which of the events were clicked
            //MessageBox.Show(tag.ToString()); //Displays tag content, for debugging
            EventPopUpWindow epw = new EventPopUpWindow(mw);
            //populate epw via getters and setters here?
            epw.ShowDialog(); //Displays event info pop up and locks main window


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

        private void Eric_Nam_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw)
                .SetTitle("Eric Nam Before We Begin World Tour")
                .SetTime("8:00 PM - 11:00 PM")
                .SetDate("September 5, 2021");
            epw.ShowDialog();
        }

        private void Thriller_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw)
                .SetTitle("Halloween Thriller")
                .SetImage(new BitmapImage(new Uri("HalloweenEvent.jpg", UriKind.Relative)))
                .SetTime("9:00 PM - 2:00 AM")
                .SetDate("October 4 2021")
                .SetLocation("Chakalaka (1410 17 Ave SW, Calgary, AB T2T 5S8)")
                .SetDescription("CALGARY'S OFFICIAL HALLOWEEN MEGA PARTY !\n★ CALGARY HALLOWEEN THRILLER 2021 ★\n@ Chakalaka Bar - Sunday October 31st (18+) \nTHE BIGGEST HALLOWEEN PARTY IN CALGARY !\nOFFICIAL MEGA PARTY // SOLD OUT YEARLY\nPRIZES FOR BEST MALE & FEMALE COSTUMES !\nEVERYONE IS WELCOMED ! \n● LIMITED $10.00 TICKETS ARE AVAILABLE\nCLUB ANTHEMS / TOP 40 / HIP HOP / HOUSE / MASHUPS\nProfessional Photographer / Videographer in Attendance\n*** PURCHASE ADVANCE TICKETS FOR GUARANTEED ENTRY ! ***\nPROOF OF VACCINATION NEEDED\n1410 17 AVE SW")
                .SetLinks("https://www.eventbrite.ca/e/calgary-halloween-thriller-2021-sun-oct-31-official-mega-party-tickets-177438101137");
            epw.ShowDialog();
        }

        private void Eric_Nam_Button_Click(object sender, RoutedEventArgs e)
        {
            EventObject eventObject = new EventObject();
            eventObject.eventName = "Eric Nam Before We Begin World Tour";
            eventObject.eventDetails = "A regular in Korea's music scene, Eric has promoted two mini albums and multiple singles in Korea.\nHe has charted at #1 on several occasions and held shows in the U.A.E., Australia, Canada, Malaysia, Morocco, and the United States.";
            eventObject.eventLocation = "MacEwan Hall (402 Collegiate Blvd NW, Calgary, AB T2N 1N4)";
            eventObject.startDate = new DateTime(2021, 09, 05);
            eventObject.startTime = 2000;
            eventObject.endTime = 2300;
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

        private void Thriller_Button_Click(object sender, RoutedEventArgs e)
        {
            EventObject eventObject = new EventObject();
            eventObject.eventName = "Halloween Thriller";
            eventObject.eventDetails = "CALGARY'S OFFICIAL HALLOWEEN MEGA PARTY !\n★ CALGARY HALLOWEEN THRILLER 2021 ★\n@ Chakalaka Bar - Sunday October 31st (18+) \nTHE BIGGEST HALLOWEEN PARTY IN CALGARY !\nOFFICIAL MEGA PARTY // SOLD OUT YEARLY\nPRIZES FOR BEST MALE & FEMALE COSTUMES !\nEVERYONE IS WELCOMED ! \n● LIMITED $10.00 TICKETS ARE AVAILABLE\nCLUB ANTHEMS / TOP 40 / HIP HOP / HOUSE / MASHUPS\nProfessional Photographer / Videographer in Attendance\n*** PURCHASE ADVANCE TICKETS FOR GUARANTEED ENTRY ! ***\nPROOF OF VACCINATION NEEDED\n1410 17 AVE SW";
            eventObject.eventLocation = "Chakalaka (1410 17 Ave SW, Calgary, AB T2T 5S8)";
            eventObject.startDate = new DateTime(2021, 10, 04);
            eventObject.startTime = 2100;
            eventObject.endTime = 200;
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
    }
}
