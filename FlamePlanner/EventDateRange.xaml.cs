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
    /// Interaction logic for EventDateRange.xaml
    /// </summary>
    public partial class EventDateRange : Page
    {
        private MainWindow mw;
        public EventDateRange(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
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

        private void Boxing_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            {
                EventPopUpWindow epw = new EventPopUpWindow(mw)
                    .SetTitle("Boxing Bootcamp")
                    .SetImage(new BitmapImage(new Uri("BoxingEvent.jpg", UriKind.Relative)))
                    .SetTime("1:30 PM – 2:30 PM")
                    .SetDate("September 12, 2021")
                    .SetLocation("5149 Country Hills Boulevard Northwest #Unit 310 Calgary, AB T3A 5K8")
                    .SetDescription("Airswift is passionate about this cause and our goal is to promote cancer research and education and raise funds for various cancer societies around the world.\nThis year in Calgary, Airswift has partnered with Kimani and Martina of Rumble Boxing to host a boot-camp workout.")
                    .SetLinks("https://www.eventbrite.ca/e/airswift-rumble-boxing-bootcamp-for-the-canadian-cancer-society-tickets-194081983437?aff=ebdssbdestsearch");
                epw.ShowDialog();
            }
        }

        private void Calgary_Flames_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw)
                .SetTitle("Calgary Flames Game")
                .SetImage(new BitmapImage(new Uri("CalgaryFlamesEvent.jpg", UriKind.Relative)))
                .SetTime("7:00 PM - 10:00 PM")
                .SetDate("September 15, 2021")
                .SetLocation("Scotiabank Saddledome (555 Saddledome Rise SE, Calgary, AB T2G 2W1)")
                .SetDescription("For almost four decades, the Flames have been electrifying hockey fans in southern Alberta. In that time, not only has the team established itself as a successful NHL franchise, \nbut it has grown into a vital and integral part of our community.\nFrom their on - ice victories and awards to their off - ice charitable endeavours, the Flames have become one of the premier professional sports organizations in North America.")
                .SetLinks("https://www.nhl.com/flames");
            epw.ShowDialog();
        }

        private void Yonex_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw)
                .SetTitle("Yonex Canada Open")
                .SetImage(new BitmapImage(new Uri("YonexCanadaOpenEvent.jpg", UriKind.Relative)))
                .SetTime("4:30 PM – 6:30 PM")
                .SetDate("September 18, 2021")
                .SetLocation("Markin Macphail Centre at Canada Olympic Park")
                .SetDescription("Since 2015 the Yonex Canada Open has taken place in Calgary, bringing with it some of the top badminton players in the world. The 2019 event saw 260 competitors from 34 nations, including 5 former world #1 players. With a USD $75,000 prize purse it is the top badminton event in Canada and has found a home at the Markin Macphail Centre at Canada Olympic Park. The competition would not be possible without the people at Badminton Alberta who have made the event into what it is. ")
                .SetLinks("https://www.visitcalgary.com/sport-and-culture/success-stories/yonex-canada-open");
            epw.ShowDialog();
        }

        private void Yonex_Button_Click(object sender, RoutedEventArgs e)
        {
            EventObject eventObject = new EventObject();
            eventObject.eventName = "Yonex Canada Open";
            eventObject.eventDetails = "Since 2015 the Yonex Canada Open has taken place in Calgary, bringing with it some of the top badminton players in the world. The 2019 event saw 260 competitors from 34 nations, including 5 former world #1 players. With a USD $75,000 prize purse it is the top badminton event in Canada and has found a home at the Markin Macphail Centre at Canada Olympic Park. The competition would not be possible without the people at Badminton Alberta who have made the event into what it is.";
            eventObject.eventLocation = "Markin Macphail Centre at Canada Olympic Park";
            eventObject.startDate = new DateTime(2021, 09, 18);
            eventObject.startTime = 1630;
            eventObject.endTime = 1830;
        }

        private void Boxing_Button_Click(object sender, RoutedEventArgs e)
        {
            EventObject eventObject = new EventObject();
            eventObject.eventName = "Boxing Bootcamp";
            eventObject.eventDetails = "Airswift is passionate about this cause and our goal is to promote cancer research and education and raise funds for various cancer societies around the world.\nThis year in Calgary, Airswift has partnered with Kimani and Martina of Rumble Boxing to host a boot-camp workout.";
            eventObject.eventLocation = "5149 Country Hills Boulevard Northwest #Unit 310 Calgary, AB T3A 5K8";
            eventObject.startDate = new DateTime(2021, 09, 12);
            eventObject.startTime = 1330;
            eventObject.endTime = 1430;
        }

        private void Calgary_Flames_Button_Click(object sender, RoutedEventArgs e)
        {
            EventObject eventObject = new EventObject();
            eventObject.eventName = "Calgary Flames Game";
            eventObject.eventDetails = "For almost four decades, the Flames have been electrifying hockey fans in southern Alberta. In that time, not only has the team established itself as a successful NHL franchise, \nbut it has grown into a vital and integral part of our community.\nFrom their on - ice victories and awards to their off - ice charitable endeavours, the Flames have become one of the premier professional sports organizations in North America.";
            eventObject.eventLocation = "Scotiabank Saddledome (555 Saddledome Rise SE, Calgary, AB T2G 2W1)";
            eventObject.startDate = new DateTime(2021, 09, 15);
            eventObject.startTime = 1900;
            eventObject.endTime = 2200;
        }
    }
}
