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
        private void InitializeFields()
        {
            Title.Content = ev.eventName;
            EventImage.Source = new BitmapImage(ev.eventImage);
            string startampm = " AM";
            int startH = ev.startTime / 100;
            if (startH >= 12)
            {
                startH %= 12;
                startampm = " PM";
            }
            if (startH == 0) startH = 12;
            int startM = ev.startTime % 100;
            string startTime = startH + ":";
            if (startM < 10)
                startTime += "0";
            startTime += startM + startampm;
            string endampm = " AM";
            int endH = ev.endTime / 100;
            if (endH >= 12)
            {
                endH %= 12;
                endampm = " PM";
            }
            if (endH == 0) endH = 12;
            int endM = ev.endTime % 100;
            string endTime = endH + ":";
            if (endM < 10)
                endTime += "0";
            endTime += endM + endampm;
            Time.Text = startTime + " - " + endTime;

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
