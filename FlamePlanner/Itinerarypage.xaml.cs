using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Itinerarypage.xaml
    /// </summary>
    public partial class Itinerarypage : Page
    {
        private MainWindow mw;
        private string[] Time_Array = new string[24];   //This array contain all the hours of the day in the correct format. 
        
        public Itinerarypage(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            Time_Array_populator();
            InitialTimePopulator();
        }

        private void InitialTimePopulator()
        {
            string[] Display_time_array = new string[6];
            for (int i = 1; i <= 6; i++)
            {
                Display_time_array[i-1] = i + ":00" + "pm";
            }

            timerow1.Text = Display_time_array[0];
            timerow2.Text = Display_time_array[1];
            timerow3.Text = Display_time_array[2];
            timerow4.Text = Display_time_array[3];
            timerow5.Text = Display_time_array[4];
            timerow6.Text = Display_time_array[5];

        }

        private void Down_Click_time_Updator()
        {
            string firstRowTime = timerow1.Text;
            int i_num = Array.IndexOf(Time_Array,firstRowTime);

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
            int change_num = i_num;

            if(change_num > 0)
            {
                timerow1.Text = Time_Array[(change_num - 1)];
                timerow2.Text = Time_Array[(change_num)];
                timerow3.Text = Time_Array[(change_num + 1) % 24];
                timerow4.Text = Time_Array[(change_num + 2) % 24];
                timerow5.Text = Time_Array[(change_num + 3) % 24];
                timerow6.Text = Time_Array[(change_num + 4) % 24];
            }
            
            if (change_num == 0)
            {
                timerow1.Text = Time_Array[Time_Array.Length - 1];
                timerow2.Text = Time_Array[(change_num)];
                timerow3.Text = Time_Array[(change_num + 1) % 24];
                timerow4.Text = Time_Array[(change_num + 2) % 24];
                timerow5.Text = Time_Array[(change_num + 3) % 24];
                timerow6.Text = Time_Array[(change_num + 4) % 24];
            }

        }

        /*
         * Populating the time array with the times of the day. 
         */
        private void Time_Array_populator()
        {
            
            Time_Array[0] = "12:00am";
            for (int i = 1; i < 12; i++)
            {
                Time_Array[i] = i + ":00" + "am";
            }
            Time_Array[12]= 12 + ":00" + "pm";

            for (int i = 1; i < 12; i++)
            {
                Time_Array[i + 12] = i + ":00" + "pm";
            }
        }

        private void customEventButton_Click(object sender, RoutedEventArgs e)
        {
            customEventInputWindow ceiw = new customEventInputWindow(mw);
            ceiw.ShowDialog();
        }

        private void TimeUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown_TopArrow(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Clicked Top arrow button");
            Up_Click_time_Updator();
        }

        private void Image_MouseLeftButtonDown_DownArrow(object sender, MouseButtonEventArgs e)
        {
            Down_Click_time_Updator();
        }

        private void Image_MouseLeftButtonDown_LeftArrow(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Clicked Left arrow button");
        }

        private void Image_MouseLeftButtonDown_RightArrow(object sender, MouseButtonEventArgs e)
        {   
            Trace.WriteLine("Clicked Right arrow button");

            for (int i = 0; i < Time_Array.Length; i++)
            {
                Trace.WriteLine(Time_Array[i]);
            }
        }
    }
}