using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for Event_left.xaml
    /// </summary>
    public partial class Event_left : Page
    {
        private MainWindow mw;
        private string[] Time_Array = new string[24];   //This array contain all the hours of the day in the correct format. 

        public Event_left(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            InitialTimePopulator();
            Time_Array_populator();
        }

        private void InitialTimePopulator()
        {
            string[] Display_time_array = new string[6];
            for (int i = 1; i <= 6; i++)
            {
                Display_time_array[i - 1] = i + ":00" + "pm";
            }

            timerow1.Text = Display_time_array[0];
            timerow2.Text = Display_time_array[1];
            timerow3.Text = Display_time_array[2];
            timerow4.Text = Display_time_array[3];
            timerow5.Text = Display_time_array[4];
            timerow6.Text = Display_time_array[5];

        }
        private void Time_Array_populator()
        {

            Time_Array[0] = "12:00am";
            for (int i = 1; i < 12; i++)
            {
                Time_Array[i] = i + ":00" + "am";
            }
            Time_Array[12] = 12 + ":00" + "pm";

            for (int i = 1; i < 12; i++)
            {
                Time_Array[i + 12] = i + ":00" + "pm";
            }
        }
        private void Down_Click_time_Updator()
        {
            string firstRowTime = timerow1.Text;
            int i_num = Array.IndexOf(Time_Array, firstRowTime);

            timerow1.Text = Time_Array[(i_num + 1) % 24];
            timerow2.Text = Time_Array[(i_num + 2) % 24];
            timerow3.Text = Time_Array[(i_num + 3) % 24];
            timerow4.Text = Time_Array[(i_num + 4) % 24];
            timerow5.Text = Time_Array[(i_num + 5) % 24];
            timerow6.Text = Time_Array[(i_num + 6) % 24];

        }
        private void Up_Click_time_Updator()
        {
            string firstRowTime = timerow1.Text;
            int i_num = Array.IndexOf(Time_Array, firstRowTime);

            if (i_num > 0)
            {
                timerow1.Text = Time_Array[(i_num - 1)];
                timerow2.Text = Time_Array[(i_num)];
                timerow3.Text = Time_Array[(i_num + 1) % 24];
                timerow4.Text = Time_Array[(i_num + 2) % 24];
                timerow5.Text = Time_Array[(i_num + 3) % 24];
                timerow6.Text = Time_Array[(i_num + 4) % 24];
            }

            if (i_num == 0)
            {
                timerow1.Text = Time_Array[Time_Array.Length - 1];
                timerow2.Text = Time_Array[(i_num)];
                timerow3.Text = Time_Array[(i_num + 1) % 24];
                timerow4.Text = Time_Array[(i_num + 2) % 24];
                timerow5.Text = Time_Array[(i_num + 3) % 24];
                timerow6.Text = Time_Array[(i_num + 4) % 24];
            }

        }


        private void Button_Click_up(object sender, RoutedEventArgs e)
        {
            Up_Click_time_Updator();
        }

        private void Button_Click_down(object sender, RoutedEventArgs e)
        {
            Down_Click_time_Updator();
        }
    }
}
