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
    /// Interaction logic for EventScreenFoodAndDrink.xaml
    /// </summary>
    public partial class EventScreenFoodAndDrink : Page
    {
        private MainWindow mw;
        public EventScreenFoodAndDrink(MainWindow mw)
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
            EventScreenSportsAndRecreation eventscreensportsandrecreation = new EventScreenSportsAndRecreation(mw);
            this.NavigationService.Navigate(eventscreensportsandrecreation);
        }

        private void Event_Down_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreen eventscreen = new EventScreen(mw);
            this.NavigationService.Navigate(eventscreen);
        }

        private void Wine_Tasting_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //EventPopUpWindow epw = new EventPopUpWindow(mw)
            //    .SetTitle("Wine Tasting Event")
            //    .SetImage(new BitmapImage(new Uri("WineTastingEvent.jpg", UriKind.Relative)))
            //    .SetTime("1:00 PM – 5:00 PM")
            //    .SetDate("October 1, 2021")
            //    .SetLocation("The Hudson (at The Guild) (200 8 Avenue Southwest Calgary, AB T2P 1B5)")
            //    .SetDescription("Join us for a walk-around showcase of the finest Italian wines in current release. This is Calgary's ultimate industry-only tasting.\n50 Italian wineries will be pouring their unique and delicious wines exclusively for members of the trade and media, with an emphasis on wines that combine affordability and excellence, making them ideal choices for by-the-glass programs in restaurants.")
            //    .SetLinks("https://www.eventbrite.ca/e/gambero-rosso-top-italian-wines-roadshow-calgary-2021-tickets-191839476037?aff=ebdssbdestsearch&keep_tld=1");

            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.WineTasting);
            epw.ShowDialog();
        }

        private void Cocktail_Class_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //EventPopUpWindow epw = new EventPopUpWindow(mw)
            //    .SetTitle("Cocktail Class")
            //    .SetImage(new BitmapImage(new Uri("CocktailClassEvent.jpg", UriKind.Relative)))
            //    .SetTime("5:00 PM – 8:00 PM")
            //    .SetDate("September 29, 2021")
            //    .SetLocation("Confluence Distilling (507 36 Avenue Southeast Calgary, AB T2G 1W5)")
            //    .SetDescription("A cocktail class that goes above and beyond! Tour the distillery, access premium spirits, drink cocktails and gain life-long skills!\nIf you haven't been to Confluence Distilling, this is the ideal way to experience this inner-city craft distillery. Learn from the 10+ years of our cocktail professionals and be immersed in the whole process from conception of the spirit to the tingle of your taste buds.")
            //    .SetLinks("https://www.eventbrite.com/e/cocktail-class-at-the-distillery-dec-edition-tickets-193807071167?aff=ebdssbdestsearch");
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.Cocktail);
            epw.ShowDialog();
        }

        private void Chefs_Table_Dinner_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            //EventPopUpWindow epw = new EventPopUpWindow(mw)
            //    .SetTitle("Chef's Table Dinner")
            //    .SetImage(new BitmapImage(new Uri("ChefsTableDinnerEvent.jpg", UriKind.Relative)))
            //    .SetTime("7:30 PM – 10:00 PM")
            //    .SetDate("September 30, 2021")
            //    .SetLocation("5108 Elbow Drive Southwest Calgary, AB")
            //    .SetDescription("Executive chef Christopher Hyde first Chef's Table Dinner at Lina's Italian Mercato. The only, true Italian dinner in Calgary.\nIt's all about the experience. And at Lina's Italian Mercato, you'll feel like you're having dinner in Italy.\nWhen Chef Hyde starts to cook, magic happens. His dishes and recipes are full of flavor and show what true love for cooking really is.")
            //    .SetLinks("https://www.eventbrite.com/e/cocktail-class-at-the-distillery-dec-edition-tickets-193807071167?aff=ebdssbdestsearch");
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.ChefsTableDinner);
            epw.ShowDialog();
        }

        private void Wine_Tasting_Button_Click(object sender, RoutedEventArgs ea)
        {
            //EventObject eventObject = new EventObject();
            //eventObject.eventName = "Wine Tasting Event";
            //eventObject.eventDetails = "Join us for a walk-around showcase of the finest Italian wines in current release. This is Calgary's ultimate industry-only tasting.\n50 Italian wineries will be pouring their unique and delicious wines exclusively for members of the trade and media, with an emphasis on wines that combine affordability and excellence, making them ideal choices for by-the-glass programs in restaurants.";
            //eventObject.eventLocation = "The Hudson (at The Guild) (200 8 Avenue Southwest Calgary, AB T2P 1B5)";
            //eventObject.startDate = new DateTime(2021, 10, 01);
            //eventObject.startTime = 1300;
            //eventObject.endTime = 1700;
            EventObject eventObject = AllEvents.WineTasting;

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

        private void Cocktail_Button_Click(object sender, RoutedEventArgs ea)
        {
            //EventObject eventObject = new EventObject();
            //eventObject.eventName = "Cocktail Class";
            //eventObject.eventDetails = "A cocktail class that goes above and beyond! Tour the distillery, access premium spirits, drink cocktails and gain life-long skills!\nIf you haven't been to Confluence Distilling, this is the ideal way to experience this inner-city craft distillery. Learn from the 10+ years of our cocktail professionals and be immersed in the whole process from conception of the spirit to the tingle of your taste buds.";
            //eventObject.eventLocation = "Confluence Distilling (507 36 Avenue Southeast Calgary, AB T2G 1W5)";
            //eventObject.startDate = new DateTime(2021, 09, 29);
            //eventObject.startTime = 1700;
            //eventObject.endTime = 2000;
            EventObject eventObject = AllEvents.Cocktail;


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

        private void Chefs_Table_Dinner_Button_Click(object sender, RoutedEventArgs ea)
        {
            //EventObject eventObject = new EventObject();
            //eventObject.eventName = "Chef's Table Dinner";
            //eventObject.eventDetails = "Executive chef Christopher Hyde first Chef's Table Dinner at Lina's Italian Mercato. The only, true Italian dinner in Calgary.\nIt's all about the experience. And at Lina's Italian Mercato, you'll feel like you're having dinner in Italy.\nWhen Chef Hyde starts to cook, magic happens. His dishes and recipes are full of flavor and show what true love for cooking really is.";
            //eventObject.eventLocation = "5108 Elbow Drive Southwest Calgary, AB";
            //eventObject.startDate = new DateTime(2021, 09, 30);
            //eventObject.startTime = 1930;
            //eventObject.endTime = 2200;
            EventObject eventObject = AllEvents.ChefsTableDinner;

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
