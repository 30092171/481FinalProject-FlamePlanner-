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
    /// Interaction logic for EventScreenSpecialEvents.xaml
    /// </summary>
    public partial class EventScreenSpecialEvents : Page
    {
        private MainWindow mw;
        public EventScreenSpecialEvents(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //var tag = ((Button)sender).Tag; //allows for us to determine which of the events were clicked
            ////MessageBox.Show(tag.ToString()); //Displays tag content, for debugging
            //EventPopUpWindow epw = new EventPopUpWindow(mw);
            ////populate epw via getters and setters here?
            //epw.ShowDialog(); //Displays event info pop up and locks main window


        }

        private void Event_Up_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreen eventscreen = new EventScreen(mw);
            this.NavigationService.Navigate(eventscreen);
        }

        private void Event_Down_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreenSportsAndRecreation eventscreensportsandrecreation = new EventScreenSportsAndRecreation(mw);
            this.NavigationService.Navigate(eventscreensportsandrecreation);
        }

        private void Glass_Fusion_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //EventPopUpWindow epw = new EventPopUpWindow(mw)
            //    .SetTitle("Glass Fusion 101")
            //    .SetImage(new BitmapImage(new Uri("GlassFusionEvent.jpg", UriKind.Relative)))
            //    .SetTime("12:00 PM - 2:00 PM")
            //    .SetDate("October 3, 2021")
            //    .SetLocation("14 St NW, Calgary, AB T2N 1Z7")
            //    .SetDescription("Under the gaze of an expert, guests arrange colourful pieces of glass to be fused into bowls, candy dishes, plaques, or vases.\nTurn bits and strips of specialty glass into twinkling kiln-fired treasures! Nothing beats the sparkle of glass. We’ll show you how to create sparkling glass functional artwork! This art form is positively UNIQUE and comes with guaranteed bragging rights! The results are dazzling, and the fun is addictive!")
            //    .SetLinks("https://allevents.in/calgary/glass-fusion-101-nov-15th/200021694739624");
            
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.GlassFusion);
            epw.ShowDialog();
        }

        private void Job_Fair_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //EventPopUpWindow epw = new EventPopUpWindow(mw)
            //    .SetTitle("Startup Job Fair Online")
            //    .SetImage(new BitmapImage(new Uri("JobFairEvent.jpg", UriKind.Relative)))
            //    .SetTime("10:00 AM - 11:00 AM")
            //    .SetDate("September 20, 2021")
            //    .SetLocation("Online")
            //    .SetDescription("Exploring new job opportunities? Looking to join a high-growth company? Join our Job Fair Online.\nChat with an actual recruiter or hiring manager. This is not an applicant tracking system. We have representatives from companies that are directly hiring.")
            //    .SetLinks("https://allevents.in/calgary/startup-job-fair-online-connect-with-the-fastest-growing-companies/10000185369504177");
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.JobFair);
            epw.ShowDialog();
        }

        private void Tim_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //EventPopUpWindow epw = new EventPopUpWindow(mw)
            //    .SetTitle("Tim & The Glory Boys")
            //    .SetImage(new BitmapImage(new Uri("TimAndTheGloryBoysEvent.jpg", UriKind.Relative)))
            //    .SetTime("7:00 PM - 9:30 PM")
            //    .SetDate("September 28, 2021")
            //    .SetLocation("First Alliance Church Calgary (FAC Deerfoot), 12345 40 Street Southeast, Calgary, Canada")
            //    .SetDescription("Been missing Live music? Tim & The Glory Boys bring you a Barn Burnin' Banjo Bash! Don't miss it!\nWith a whole new batch of songs, they are as eager as Canadian beavers to visit your neck o’ the woods. Don’t miss a rare night of live music and fun in your own backyard!")
            //    .SetLinks("https://allevents.in/calgary/tim-and-the-glory-boys-the-home-town-hoedown-tour-calgary-ab/10000165490218699");
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.TimAndTheGloryBoys);
            epw.ShowDialog();
        }

        private void Glass_Fusion_Button_Click(object sender, RoutedEventArgs ea)
        {
            //EventObject eventObject = new EventObject();
            //eventObject.eventName = "Glass Fusion 101";
            //eventObject.eventDetails = "Under the gaze of an expert, guests arrange colourful pieces of glass to be fused into bowls, candy dishes, plaques, or vases.\nTurn bits and strips of specialty glass into twinkling kiln-fired treasures! Nothing beats the sparkle of glass. We’ll show you how to create sparkling glass functional artwork! This art form is positively UNIQUE and comes with guaranteed bragging rights! The results are dazzling, and the fun is addictive!";
            //eventObject.eventLocation = "14 St NW, Calgary, AB T2N 1Z7";
            //eventObject.startDate = new DateTime(2021, 10, 03);
            //eventObject.startTime = 1200;
            //eventObject.endTime = 1400;
            EventObject eventObject = AllEvents.GlassFusion;

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

        private void Job_Fair_Button_Click(object sender, RoutedEventArgs ea)
        {
            //EventObject eventObject = new EventObject();
            //eventObject.eventName = "Startup Job Fair Online";
            //eventObject.eventDetails = "Exploring new job opportunities? Looking to join a high-growth company? Join our Job Fair Online.\nChat with an actual recruiter or hiring manager. This is not an applicant tracking system. We have representatives from companies that are directly hiring.";
            //eventObject.eventLocation = "Online";
            //eventObject.startDate = new DateTime(2021, 09, 20);
            //eventObject.startTime = 1000;
            //eventObject.endTime = 1100;
            EventObject eventObject = AllEvents.JobFair;

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

        private void Tims_Button_Click(object sender, RoutedEventArgs ea)
        {
            //EventObject eventObject = new EventObject();
            //eventObject.eventName = "Tim & The Glory Boys";
            //eventObject.eventDetails = "Been missing Live music? Tim & The Glory Boys bring you a Barn Burnin' Banjo Bash! Don't miss it!\nWith a whole new batch of songs, they are as eager as Canadian beavers to visit your neck o’ the woods. Don’t miss a rare night of live music and fun in your own backyard!";
            //eventObject.eventLocation = "First Alliance Church Calgary (FAC Deerfoot), 12345 40 Street Southeast, Calgary, Canada";
            //eventObject.startDate = new DateTime(2021, 09, 28);
            //eventObject.startTime = 1900;
            //eventObject.endTime = 2130;
            EventObject eventObject = AllEvents.TimAndTheGloryBoys;

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
    }
}
