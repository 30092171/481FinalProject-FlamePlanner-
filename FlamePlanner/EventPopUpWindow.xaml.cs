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
using System.Windows.Shapes;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EventPopUpWindow : Window
    {
        private EventObject ev;
        private MainWindow mw;
        public EventPopUpWindow(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }
        public EventPopUpWindow(MainWindow mw, EventObject ev) : this(mw)
        {
            this.ev = ev;
            InitializeFields();
        }

        private static string To12(int time24)
        {
            int hour = time24 / 100;
            int min = time24 % 100;
            string ampm = (hour <= 12) ? "AM" : "PM";
            hour %= 12;
            if (hour == 0) hour = 12;
            return string.Format("{0}:{1:D2} {2}", hour, min, ampm);
        }

        private void InitializeFields()
        {
            Title.Content = ev.eventName;
            EventImage.Source = new BitmapImage(ev.eventImage);
            Time.Text = To12(ev.startTime) + " - " + To12(ev.endTime);

            string sd = ev.startDate.ToString();
            Date.Text = sd.Substring(0, sd.IndexOf(' '));
            Location.Text = ev.eventLocation;
            Description.Text = ev.eventDetails;
            Links.Inlines.Clear();
            foreach (string s in ev.eventLinks)
            {
                Hyperlink l = new Hyperlink();
                l.Inlines.Add(s);
                l.NavigateUri = new Uri(s);
                Links.Inlines.Add(l);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MapEvent me = new MapEvent(mw, ev);
            bool? result = me.ShowDialog();
            if (result.Value)
            {
                // Booking code here
                BookedLabel.Text = "YES";
            }
        }
    }
}
