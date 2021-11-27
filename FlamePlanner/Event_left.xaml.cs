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
        private static int no_of_days = 28; //Conatins the size of the arrays and the number of days we consider in our program. to increase or decrease days simply increase this number. 
        private string[] Time_Array = new string[24];   //This array contain all the hours of the day in the correct format. 
        private DateTime[] Date_Array = new DateTime[no_of_days];   //Contains all the dates from september 5 2021 to october 2 2021.
        private string[] Date_string_Array = new string[no_of_days];    //Contains all the dates in Date_Array in string format. ddd d, mmm
        public int startTime;
        public int endTime;
        public DateTime currentDate;

        public Event_left(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            InitialTimePopulator();
            Time_Array_populator();
            DateTime startDate = new DateTime(2021, 9, 5);
            currentDate = new DateTime(2021, 09, 05); //= new DateTime(year,month,day)
            Date_Array_populator(startDate);
        }

        private void InitialTimePopulator()
        {
            startTime = 600;
            endTime = 1100;
            string[] Display_time_array = new string[6];
            for (int i = 1; i <= 6; i++)
            {
                Display_time_array[i - 1] = (i + 5) + ":00" + "am";
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

        private void Date_Array_populator(DateTime start_date)
        {
            int i = 0;
            DateTime date = start_date;
            while (i < Date_Array.Length)
            {
                Date_Array[i] = date.AddDays(i);
                Date_string_Array[i] = Date_Array[i].ToString("ddd") + " " + Date_Array[i].Day.ToString() + ", " + Date_Array[i].ToString("MMM");
                i++;
            }

        }

        private void Down_Click_time_Updator()
        {
            string firstRowTime = timerow1.Text;
            int i_num = Array.IndexOf(Time_Array, firstRowTime);

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

            if (i_num > 0 && startTime > 0)
            {
                timerow1.Text = Time_Array[(i_num - 3)];
                timerow2.Text = Time_Array[(i_num - 2)];
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
            if (i_num == Date_string_Array.Length -1)
            {
                return;
            }

            if (currentDate.Day == 30)
            {
                currentDate = new DateTime(2021, 10, 1);
            }
            else {
                currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day + 1);
             }
            
            DateCol1.Text = Date_Array[(i_num + 1) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num + 1) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num + 1) % no_of_days].ToString("MMM");
            
        }

        private void Left_Click_date_Updator()
        {
            string firstColTime = DateCol1.Text;
            int i_num = Array.IndexOf(Date_string_Array, firstColTime);
            if (i_num == 0)
            {
                return;
            }

            if (i_num > 0)
            {
                if(currentDate.Day == 1)
                {
                    currentDate = new DateTime(2021, 09, 30);
                }
                else
                {
                    currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day - 1);
                }
                DateCol1.Text = Date_Array[(i_num - 1) % no_of_days].ToString("ddd") + " " + Date_Array[(i_num - 1) % no_of_days].Day.ToString() + ", " + Date_Array[(i_num - 1) % no_of_days].ToString("MMM");
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

        private void rightDateButton_Click(object sender, RoutedEventArgs e)
        {
            Right_Click_date_Updator();
        }

        private void leftDateButton_Click(object sender, RoutedEventArgs e)
        {
            Left_Click_date_Updator();
        }
    }
}
