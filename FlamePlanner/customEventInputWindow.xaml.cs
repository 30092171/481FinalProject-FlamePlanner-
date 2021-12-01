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
    /// Interaction logic for customEventInputWindow.xaml
    /// </summary>
    public partial class customEventInputWindow : Window
    {
        private MainWindow mw;
        public customEventInputWindow(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
            populateTimeRanges();
            datePicker.SelectedDate = new DateTime(2021, 9, 5);
        }

        private void populateTimeRanges()
        {
            hour1.Items.Clear();
            hour2.Items.Clear();
            minute1.Items.Clear();
            minute2.Items.Clear();
            for(int i = 1; i <= 12; i++)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = i.ToString();
                hour1.Items.Add(cbi);
                ComboBoxItem cbi2 = new ComboBoxItem();
                cbi2.Content = i.ToString();
                hour2.Items.Add(cbi2);
            }

            for(int i = 0; i <= 59; i++)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = i.ToString("D2");
                minute1.Items.Add(cbi);

                ComboBoxItem cbi2 = new ComboBoxItem();
                cbi2.Content = i.ToString("D2");
                minute2.Items.Add(cbi2);
            }

            hour1.SelectedIndex = 0;
            hour2.SelectedIndex = 1;
            minute1.SelectedIndex = 0;
            minute2.SelectedIndex = 0;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameInput.Text;

            if (name == "")
            {
                MessageBox.Show("You Need to Enter a Name For the Custom Event");
                return;
            }

            string location = locationInput.Text; //optional, can be empty
            string description = descriptionInput.Text; //optional, can be empty

            DateTime dt = datePicker.SelectedDate.Value;

            int startHour = hour1.SelectedIndex + 1;
            int startMinute = minute1.SelectedIndex;

            if(amPm1.SelectedIndex == 1) //PM
            {
                startHour += 12;
            }else if (amPm1.SelectedIndex == 0 && hour1.SelectedIndex ==11)//12am
            {
                startHour = 0; //midnight
            }

            int startTime = startHour * 100 + startMinute;

            int endHour = hour2.SelectedIndex + 1;
            int endMinute = minute2.SelectedIndex;

            if (amPm2.SelectedIndex == 1) //PM
            {
                endHour += 12;
            }
            else if (amPm2.SelectedIndex == 0 && hour2.SelectedIndex == 11)//12am
            {
                endHour = 0; //midnight
            }

            int endTime = endHour * 100 + endMinute;

            if(endTime <= startTime)
            {
                MessageBox.Show("Invalid Time Combination.\nYour Start Time must be before your End Time.");
                return;
            }


            //If not returned by now everything checks out
            EventObject eo = new EventObject(name,description,location,dt,startTime,endTime);
            //eo.filterID = 0; //Custom events don't have filter criteria and are always displayed
            mw.bufferItinerary.eventList.Add(eo);
            this.Close();
        }
    }
}
