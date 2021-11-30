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
    /// Interaction logic for MapEvent.xaml
    /// </summary>
    public partial class MapEvent : Window
    {
        private MainWindow mw;
        private EventObject ev;
        public MapEvent(MainWindow mw, EventObject ev)
        {
            this.mw = mw;
            this.ev = ev;
            InitializeComponent();
            InitializeComboBox();
            event_label.Content = ev.eventName;
            datePicker.SelectedDate = ev.startDate;
            timeRestrictBlock.Text = To12(ev.startTime) + " to " + To12(ev.endTime);
            DateTime restrict = ev.startDate;
            string days = "";
            days += (Month)restrict.Month + " " + restrict.Day;
            dateRestrictBlock.Text = days;
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

        private void InitializeComboBox()
        {
            ComboBoxItem t1 = new(), t2 = new();
            t1.Content = t2.Content = "12";
            startHour.Items.Add(t1);
            endHour.Items.Add(t2);
            for (int i = 1; i <= 11; i++)
            {
                ComboBoxItem i1 = new(), i2 = new();
                if (i < 10)
                    i1.Content = i2.Content = " " + i;
                else
                    i1.Content = i2.Content = i;
                startHour.Items.Add(i1);
                endHour.Items.Add(i2);
            }
            for (int i = 0; i <= 59; i++)
            {
                ComboBoxItem i1 = new(), i2 = new();
                if (i < 10)
                    i1.Content = i2.Content = "0" + i;
                else
                    i1.Content = i2.Content = i;
                startMinute.Items.Add(i1);
                endMinute.Items.Add(i2);
            }
            startHour.SelectedIndex = ev.startTime / 100 % 12;
            endHour.SelectedIndex = ev.endTime / 100 % 12;
            startMinute.SelectedIndex = ev.startTime % 100;
            endMinute.SelectedIndex = ev.endTime % 100;
        }

        private void okbutton_Click(object sender, RoutedEventArgs e)
        {
            int starth = int.Parse((startHour.SelectedItem as ComboBoxItem).Content as string);
            int startm = int.Parse((startMinute.SelectedItem as ComboBoxItem).Content as string);
            int endh = int.Parse((endHour.SelectedItem as ComboBoxItem).Content as string);
            int endm = int.Parse((endMinute.SelectedItem as ComboBoxItem).Content as string);
            if (amPm.SelectedIndex == 1 && starth < 12) starth += 12;
            else if (amPm.SelectedIndex == 0 && starth == 12) starth = 0;
            if (amPm2.SelectedIndex == 1 && endh < 12) endh += 12;
            else if (amPm2.SelectedIndex == 0 && endh == 12) endh = 0;
            int start24 = starth * 100 + startm;
            int end24 = endh * 100 + endm;
            EventObject eventObject = ev.Copy() // heres the event object
                .SetStartTime(start24)
                .SetEndTime(end24);
            if (datePicker.SelectedDate.HasValue)
                eventObject.SetStartDate(datePicker.SelectedDate.Value);
            DialogResult = true;
            Close();
        }
    }
    public enum Month
    {
        NONE, January, February, March, April, May, June, July, August, September, October, November, December
    }
}
