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
    /// Interaction logic for Itinerary_bottom.xaml
    /// </summary>
    public partial class Itinerary_bottom : Page
    {
        private MainWindow mw;
        private Itinerarypage ItinPage;
        public Itinerary_bottom(MainWindow mw,Itinerarypage ip)
        {
            this.mw = mw;
            this.ItinPage = ip;
            InitializeComponent();
            

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Date1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker dp = sender as DatePicker;
            DateTime dt = dp.SelectedDate.Value;
            int day = dt.Day;
            if (dt.Month == 09)
            {                
                if(day >= 5 && day <= 11)
                {
                    ItinPage.changeDateRange(0);
                }else if (day >= 12 && day <= 18)
                {
                    ItinPage.changeDateRange(1);
                }
                else if (day >= 19 && day <= 25)
                {
                    ItinPage.changeDateRange(2);
                }
                else if (day >= 26 && day <= 30)
                {
                    ItinPage.changeDateRange(3);
                }
            }
            else if (dt.Month == 10 && (day == 1 || day == 2))
            {
                ItinPage.changeDateRange(3);
            }

           
        }
    }
}
