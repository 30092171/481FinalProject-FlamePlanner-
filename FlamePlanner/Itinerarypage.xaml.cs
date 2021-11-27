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
        private static int no_of_days = 28; //Conatins the size of the arrays and the number of days we consider in our program. to increase or decrease days simply increase this number. 
        private string[] Time_Array = new string[24];   //This array contain all the hours of the day in the correct format. 
        private DateTime[] Date_Array = new DateTime[no_of_days];   //Contains all the dates from september 5 2021 to october 2 2021.
        private string[] Date_string_Array = new string[no_of_days];    //Contains all the dates in Date_Array in string format. ddd d, mmm
        public int startTime;
        public int endTime;
        public int dateWeek; //0 is week of 5 sep, 3 is week of 29 Sep


        public Itinerarypage(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            Time_Array_populator();
            InitialTimePopulator();

            DateTime startDate = new DateTime(2021,9,5);
            dateWeek = 0;
            Date_Array_populator(startDate);
            changeDateDisplay(dateWeek);
        }

        private void InitialTimePopulator()
        {
            startTime = 600;
            endTime = 1100;
            string[] Display_time_array = new string[6];
            for (int i = 1; i <= 6; i++)
            {
                Display_time_array[i-1] = (i+5) + ":00" + "am";
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

            if (endTime < 2300)
            {

                timerow1.Text = Time_Array[(i_num + 3) % 24];
                timerow2.Text = Time_Array[(i_num + 4) % 24];
                timerow3.Text = Time_Array[(i_num + 5) % 24];
                timerow4.Text = Time_Array[(i_num + 6) % 24];
                timerow5.Text = Time_Array[(i_num + 7) % 24];
                timerow6.Text = Time_Array[(i_num + 8) % 24];
                startTime += 300;
                endTime += 300;
            }
        }

        private void Up_Click_time_Updator()
        {
            string firstRowTime = timerow1.Text;
            int i_num = Array.IndexOf(Time_Array, firstRowTime);

            if(i_num > 0 && startTime > 0)
            {
                timerow1.Text = Time_Array[(i_num - 3)];
                timerow2.Text = Time_Array[(i_num-2)];
                timerow3.Text = Time_Array[(i_num - 1) % 24];
                timerow4.Text = Time_Array[(i_num) % 24];
                timerow5.Text = Time_Array[(i_num + 1) % 24];
                timerow6.Text = Time_Array[(i_num + 2) % 24];
                startTime -= 300;
                endTime -= 300;
            }
            
            if (i_num == 0)
            {
                //timerow1.Text = Time_Array[Time_Array.Length - 1];
                //timerow2.Text = Time_Array[(i_num)];
                //timerow3.Text = Time_Array[(i_num + 1) % 24];
                //timerow4.Text = Time_Array[(i_num + 2) % 24];
                //timerow5.Text = Time_Array[(i_num + 3) % 24];
                //timerow6.Text = Time_Array[(i_num + 4) % 24];
            }

        }

        private void Right_Click_date_Updator()
        {
            string firstColTime = DateCol1.Text;
            Trace.WriteLine(DateCol1.Text);
            Trace.WriteLine(Date_string_Array[1]);
            int i_num = Array.IndexOf(Date_string_Array, firstColTime);

            if(i_num == Date_string_Array.Length - 7)
            {
                return;
            }
            dateWeek += 1;
            changeDateDisplay(dateWeek);
            DateCol1.Text = Date_Array[(i_num + 1 + 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 1 + 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 1 + 6) % no_of_days].ToString("MMM");
            DateCol2.Text = Date_Array[(i_num + 2 + 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 2 + 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 2 + 6) % no_of_days].ToString("MMM");
            DateCol3.Text = Date_Array[(i_num + 3 + 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 3 + 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 3 + 6) % no_of_days].ToString("MMM");
            DateCol4.Text = Date_Array[(i_num + 4 + 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 4 + 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 4 + 6) % no_of_days].ToString("MMM");
            DateCol5.Text = Date_Array[(i_num + 5 + 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 5 + 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 5 + 6) % no_of_days].ToString("MMM");
            DateCol6.Text = Date_Array[(i_num + 6 + 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 6 + 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 6 + 6) % no_of_days].ToString("MMM");
            DateCol7.Text = Date_Array[(i_num + 7 + 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 7 + 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 7 + 6) % no_of_days].ToString("MMM");
        }

        private void Left_Click_date_Updatoe()
        {
            string firstColTime = DateCol1.Text;
            int i_num = Array.IndexOf(Date_string_Array, firstColTime);
            if (i_num == 0)
            {
                return;
            }

            if (i_num > 0)
            {
                dateWeek -= 1;
                changeDateDisplay(dateWeek);
                DateCol1.Text = Date_Array[(i_num - 1 - 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num - 1 - 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num - 1 - 6) % no_of_days].ToString("MMM");
                DateCol2.Text = Date_Array[(i_num - 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num - 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num - 6) % no_of_days].ToString("MMM");
                DateCol3.Text = Date_Array[(i_num + 1 - 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 1 - 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 1 - 6) % no_of_days].ToString("MMM");
                DateCol4.Text = Date_Array[(i_num + 2 - 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 2 - 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 2 - 6) % no_of_days].ToString("MMM");
                DateCol5.Text = Date_Array[(i_num + 3 - 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 3 - 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 3 - 6) % no_of_days].ToString("MMM");
                DateCol6.Text = Date_Array[(i_num + 4 - 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 4 - 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 4 - 6) % no_of_days].ToString("MMM");
                DateCol7.Text = Date_Array[(i_num + 5 - 6) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 5 - 6) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 5 - 6) % no_of_days].ToString("MMM");
            }
        }

        private void Date_Array_populator(DateTime start_date)
        {
            int i = 0;
            DateTime date = start_date;
            while( i < Date_Array.Length)
            {
                Date_Array[i] = date.AddDays(i);
                Date_string_Array[i] = Date_Array[i].ToString("ddd") + " " + Date_Array[i].Day.ToString() + ", " + Date_Array[i].ToString("MMM");
                i++;
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

        private void changeDateDisplay(int week)
        {
            if(week<0 || week > 3)
            {
                week = 0;
            }

            switch(week){
                case 0:
                    WeekDisplay.Text = "Sunday 05 Sep. 2021 - Saturday 11 Sep. 2021";
                    break;
                case 1:
                    WeekDisplay.Text = "Sunday 12 Sep. 2021 - Saturday 18 Sep. 2021";
                    break;
                case 2:
                    WeekDisplay.Text = "Sunday 19 Sep. 2021 - Saturday 25 Sep. 2021";
                    break;
                case 3:
                    WeekDisplay.Text = "Sunday 26 Sep. 2021 - Saturday 02 Oct. 2021";
                    break;
             
            }
        }

        private void customEventButton_Click(object sender, RoutedEventArgs e)
        {
            customEventInputWindow ceiw = new customEventInputWindow(mw);
            ceiw.ShowDialog();
        }

        public void changeDateRange(int week)
        {
            if (week >= 0 && week <= 3)
            {
                while (week < dateWeek)
                {
                    Left_Click_date_Updatoe();
                }

                while (week > dateWeek)
                {
                    Right_Click_date_Updator();
                }
            }
            
        }

        private void DateLeftButton_Click(object sender, RoutedEventArgs e)
        {
            Left_Click_date_Updatoe();
        }

        private void DateRightButton_Click(object sender, RoutedEventArgs e)
        {
            Right_Click_date_Updator();
        }

        private void TimeDownButton_Click(object sender, RoutedEventArgs e)
        {
            Down_Click_time_Updator();
        }

        private void TimeUpButton_Click(object sender, RoutedEventArgs e)
        {
            Up_Click_time_Updator();
        }
    }
}