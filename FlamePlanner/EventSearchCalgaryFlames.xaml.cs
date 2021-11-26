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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Event_Display_Button_Click(object sender, RoutedEventArgs e)
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
