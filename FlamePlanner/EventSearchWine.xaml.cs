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
    /// Interaction logic for EventSearchWine.xaml
    /// </summary>
    public partial class EventSearchWine : Page
    {
        private MainWindow mw;
        public EventSearchWine(MainWindow mw)
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
            EventScreen eventscreen = new EventScreen(mw);
            this.NavigationService.Navigate(eventscreen);
        }

        private void Event_Down_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreenSportsAndRecreation eventscreensportsandrecreation = new EventScreenSportsAndRecreation(mw);
            this.NavigationService.Navigate(eventscreensportsandrecreation);
        }

        private void Wine_Tasting_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw)
                .SetTitle("Wine Tasting Event")
                .SetImage(new BitmapImage(new Uri("WineTastingEvent.jpg", UriKind.Relative)))
                .SetTime("1:00 PM – 5:00 PM")
                .SetDate("October 1, 2021")
                .SetLocation("The Hudson (at The Guild) (200 8 Avenue Southwest Calgary, AB T2P 1B5)")
                .SetDescription("Join us for a walk-around showcase of the finest Italian wines in current release. This is Calgary's ultimate industry-only tasting.\n50 Italian wineries will be pouring their unique and delicious wines exclusively for members of the trade and media, with an emphasis on wines that combine affordability and excellence, making them ideal choices for by-the-glass programs in restaurants.")
                .SetLinks("https://www.eventbrite.ca/e/gambero-rosso-top-italian-wines-roadshow-calgary-2021-tickets-191839476037?aff=ebdssbdestsearch&keep_tld=1");
            epw.ShowDialog();
        }

        private void WineU_Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw)
                .SetTitle("Wine U: Premium Wines!")
                .SetImage(new BitmapImage(new Uri("WineUEvent.jpg", UriKind.Relative)))
                .SetTime("6:30 PM – 8:30 PM")
                .SetDate("September 9, 2021")
                .SetLocation("4109 University Avenue Northwest Calgary, AB T3B 6K3")
                .SetDescription("We are popping open premium wines tonight!\nIf you’re thinking about stocking your cellar or need an extra special gift, don’t miss out on this epic night! Join us for our Wine U series as we guide you through a selection of 6 different wines alongside cheese & charcuterie from Soffritto.")
                .SetLinks("https://www.eventbrite.ca/e/wine-u-premium-wines-tickets-211249782787?aff=ebdssbdestsearch");
            epw.ShowDialog();
        }
    }
}
