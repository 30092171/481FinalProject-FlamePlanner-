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
            if(ev.reoccurring)
            {
                dateRestrictBlock.Text = "Monday, Wednesday, Friday";
                datePicker.IsEnabled = true;
            } else
            {
                DateTime restrict = ev.startDate;
                string days = "";
                days += (Month)restrict.Month + " " + restrict.Day;
                dateRestrictBlock.Text = days;
            }
            
        }

        private static string To12(int time24)
        {
            int hour = time24 / 100;
            int min = time24 % 100;
            string ampm = (hour >= 12) ? "PM" : "AM";
            hour %= 12;
            if (hour == 0) hour = 12;
            return string.Format("{0}:{1:D2} {2}", hour, min, ampm);
        }

        private void InitializeComboBox()
        {
            for (int i = 1; i <= 12; i++)
            {
                ComboBoxItem i1 = new(), i2 = new();
                if (i < 10)
                    i1.Content = i2.Content = " " + i;
                else
                    i1.Content = i2.Content = i + "";
                startHour.Items.Add(i1);
                endHour.Items.Add(i2);
            }
            for (int i = 0; i <= 59; i++)
            {
                ComboBoxItem i1 = new(), i2 = new();
                if (i < 10)
                    i1.Content = i2.Content = "0" + i;
                else
                    i1.Content = i2.Content = i + "";
                startMinute.Items.Add(i1);
                endMinute.Items.Add(i2);
            }
            int starth = (ev.startTime / 100) - 1;
            if (starth == -1) starth = 11;
            if (starth > 11) starth -= 12;
            startHour.SelectedIndex = starth;
            int endh = (ev.endTime / 100) - 1;
            if (endh == -1) endh = 11;
            if (endh > 11) endh -= 12;
            endHour.SelectedIndex = endh;
            startMinute.SelectedIndex = ev.startTime % 100;
            endMinute.SelectedIndex = ev.endTime % 100;
            amPm.SelectedIndex = (ev.startTime / 100 > 11) ? 1 : 0;
            amPm2.SelectedIndex = (ev.endTime / 100 > 11) ? 1 : 0;
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
            
            bool validday = false;
            if (ev.reoccurring)
            {
                foreach(DayOfWeek d in ev.reoccurringdays)
                {
                    if (d == datePicker.SelectedDate.Value.DayOfWeek)
                        validday = true;
                }
            } else
            {
                validday = true;
            }
            if (start24 >= ev.startTime && end24 <= ev.endTime && start24 < end24 && validday)
            {
                EventObject eventObject = ev.Copy() // heres the event object
                .SetStartTime(start24)
                .SetEndTime(end24);
                if (datePicker.SelectedDate.HasValue)
                    eventObject.SetStartDate(datePicker.SelectedDate.Value);
                mw.bufferItinerary.eventList.Add(eventObject);
                Event_left el = new Event_left(mw);
                (mw.mainFrame.Content as threeFramePage).leftFrame.Content = el;
                DialogResult = true;
                Close();
            } else
            {
                string errors = "";
                if (start24 < ev.startTime) errors += "Start time must be on or after " + To12(ev.startTime) + "\n";
                if (end24 > ev.endTime) errors += "End time must be on or before " + To12(ev.endTime) + "\n";
                if (start24 >= end24) errors += "Start time must not be on or after End time.\n";
                if (!validday) errors += "Date must be on one of the restricted days.\n";
                errorBlock.Text = errors;
                errorBlock.Visibility = Visibility.Visible;
            }
        }
    }
    public enum Month
    {
        NONE, January, February, March, April, May, June, July, August, September, October, November, December
    }
}
