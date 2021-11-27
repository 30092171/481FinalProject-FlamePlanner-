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
        private Itinerary itin;


        public Itinerarypage(MainWindow mw)
        {
            this.mw = mw;
            this.itin = mw.bufferItinerary;
            InitializeComponent();
            
            
            Time_Array_populator();
            InitialTimePopulator();

            DateTime startDate = new DateTime(2021,9,5);
            dateWeek = 0;
            Date_Array_populator(startDate);
            changeDateDisplay(dateWeek);
            //itin.eventList.Add(new EventObject("apple", "", "", new DateTime(2021, 9, 5), 600, 2145));
            //itin.eventList.Add(new EventObject("apple", "", "", new DateTime(2021, 10, 2), 2100, 2230));
            displayEvents();
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
                displayEvents();
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
                displayEvents();
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

        private void Right_Click_date_Updator(Boolean b = true)
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
            if (b)
            {
                displayEvents();
            }
        }

        private void Left_Click_date_Updatoe(Boolean b = true)
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
                if (b)
                {
                    displayEvents();
                }
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
                    Left_Click_date_Updatoe(false);
                }

                while (week > dateWeek)
                {
                    Right_Click_date_Updator(false);
                }

                displayEvents();
            }
            
        }

        private UIElement getChildFromCoordinate(int row, int column)
        {
            UIElement a = null;
            try
            {
                a = mainGrid.Children
                    .Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);

                return a;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }

        }

        public void displayEvents()
        {
            Boolean[,] b = new Boolean[6, 7]; //row major. Row=time col=day

            //removes all children from a grid range
            for (int i = 2; i <= 7; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    UIElement a = getChildFromCoordinate(i, j);
                    if (a != null)
                    {
                        mainGrid.Children.Remove(a);
                    }
                    b[i - 2, j - 1] = false;
                }
            }

            

            foreach (EventObject e in itin.eventList)
            {
                
                if(e.isVisible == true)
                {
                    
                    int week = getDateWeekFromDate(e.startDate);
                    if (week == dateWeek)
                    {
                        Boolean crossOver = false;
                        if (e.endTime >= startTime && e.startTime < startTime)
                        {
                            crossOver = true;
                        }

                        if (crossOver || (e.startTime >= startTime && e.startTime <= endTime))
                        {
                            int s_min, display_s_min;
                            int s_hour, display_s_hour;
                            if (crossOver)
                            { //sets start time to earliest time slot since the event was started earlier
                                s_min = startTime % 100;
                                s_hour = (startTime) / 100;
                                display_s_min = e.startTime % 100;
                                display_s_hour = (e.startTime - s_min) / 100;
                            }
                            else
                            {
                                s_min = e.startTime % 100;
                                s_hour = (e.startTime - s_min) / 100;
                                display_s_min = s_min;
                                display_s_hour = s_hour;
                            }

                            int e_min = e.endTime % 100;
                            int e_hour = (e.endTime - e_min)/100;

                            int row = s_hour-(startTime-startTime%100)/100 + 2;
                            int col = getDayIndex(e.startDate) + 1;

                            int span = e_hour - s_hour + 1;

                            Brush eventColor = (Brush)(new BrushConverter().ConvertFrom("#FF5BEED3"));

                            Grid newGrid = new Grid();
                            newGrid.Background = eventColor;

                            StackPanel sp = new StackPanel();
                            sp.Orientation = Orientation.Vertical;
                            sp.VerticalAlignment = VerticalAlignment.Center;
                            sp.HorizontalAlignment = HorizontalAlignment.Center;

                            TextBlock t = new TextBlock();
                            t.Text = e.eventName;
                            //t.Background = Brushes.LightGray;
                            t.HorizontalAlignment = HorizontalAlignment.Center;
                            t.VerticalAlignment = VerticalAlignment.Center;

                            Thickness margin = new Thickness();
                            margin.Top = 5;
                            margin.Left = 0;
                            margin.Right = 0;
                            margin.Bottom = 0;
                            t.Margin = margin;

                            t.FontSize=15;

                            TextBlock t2 = new TextBlock();
                            if(e.startTime < 1300)
                            {
                                if(e.endTime < 1300)
                                {
                                    if (e.startTime < 1200)
                                    {
                                        t2.Text = display_s_hour + ":" + display_s_min.ToString("D2") + " am - " + e_hour + ":" + e_min.ToString("D2") + " am";
                                    }
                                    else
                                    {
                                        t2.Text = display_s_hour + ":" + display_s_min.ToString("D2") + " pm - " + e_hour + ":" + e_min.ToString("D2") + " am";
                                    }
                                }                               
                                else
                                {
                                    if (e.startTime < 1200)
                                    {
                                        t2.Text = display_s_hour + ":" + display_s_min.ToString("D2") + " am - " + (e_hour % 12) + ":" + e_min.ToString("D2") + " pm";
                                    }
                                    else
                                    {
                                        t2.Text = display_s_hour + ":" + display_s_min.ToString("D2") + " pm - " + (e_hour % 12) + ":" + e_min.ToString("D2") + " pm";
                                    }
                                    
                                }
                            }
                            else
                            {
                                //End time must be > 1300
                                t2.Text = (display_s_hour % 12) + ":" + display_s_min.ToString("D2") + " pm - " + (e_hour % 12) + ":" + e_min.ToString("D2") + " pm";
                            }

                            t2.HorizontalAlignment = HorizontalAlignment.Center;
                            t2.VerticalAlignment = VerticalAlignment.Center;
                            t2.Margin = margin;

                            sp.Children.Add(t);
                            sp.Children.Add(t2);


                            newGrid.Children.Add(sp);


                            double ds_min = s_min;
                            double de_min = e_min;

                            //Figure out intertime margin
                            margin.Left = 2;
                            margin.Top = (ds_min / 60 * 49) + 2;
                            margin.Right = 2;
                            if (row + span > 8)
                            {
                                margin.Bottom = 0; //runs off grid
                                span = 8 - row;
                            }
                            else {
                                margin.Bottom = ((60 - de_min) / 60) * 49 + 2;
                            }
                            
                            newGrid.Margin = margin;

                            Boolean conflict = false;

                            for (int i = 0; i < span; i++)
                            {
                                if (i+row-2 < 6 && b[i+row-2,col-1]==true) //checks for conflict
                                {
                                    conflict = true;
                                    break;
                                }
                            }

                            if (conflict)
                            {
                                e.isVisible = false;
                                //Redo checks in eventPanel of left panel
                                Itinerary_leftpannel lp = (mw.mainFrame.Content as threeFramePage).leftFrame.Content as Itinerary_leftpannel;
                                lp.redoCheckboxSelections();
                                MessageBox.Show("The event \""+e.eventName+"\" conflicts with another event.\nIt is unable to be displayed on the current itineary configuration.");
                            }
                            else //no conflict
                            {


                                for (int i = 0; i < span; i++)
                                {
                                    if (i < 6) //just in case, should always be true
                                    {
                                        b[i+row-2, col - 1] = true;
                                    }
                                }

                                mainGrid.Children.Add(newGrid);
                                Grid.SetRow(newGrid, row);
                                Grid.SetColumn(newGrid, col);
                                Grid.SetRowSpan(newGrid, span);

                                //Currently does not account for day overflow
                            }




                        }
                    }
                }
            }
        }

        /// <summary>
        /// Pass in a dateTime object, returns week index in display
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>-1 if not in range or 0-3 if in range</returns>
        public int getDateWeekFromDate(DateTime dt)
        {
            int day = dt.Day;
            if (dt.Month == 09)
            {
                if (day >= 5 && day <= 11)
                {
                    return 0;
                }
                else if (day >= 12 && day <= 18)
                {
                    return 1;
                }
                else if (day >= 19 && day <= 25)
                {
                    return 2;
                }
                else if (day >= 26 && day <= 30)
                {
                    return 3;
                }
            }
            else if (dt.Month == 10 && (day == 1 || day == 2))
            {
                return 3;
            }

            return -1;
        }

        public int getDayIndex(DateTime dt)
        {
            DayOfWeek dw = dt.DayOfWeek;
            if (dw.Equals(DayOfWeek.Sunday)){
                return 0;
            }else if (dw.Equals(DayOfWeek.Monday)){
                return 1;
            }else if (dw.Equals(DayOfWeek.Tuesday))
            {
                return 2;
            }
            else if (dw.Equals(DayOfWeek.Wednesday))
            {
                return 3;
            }
            else if (dw.Equals(DayOfWeek.Thursday))
            {
                return 4;
            }
            else if (dw.Equals(DayOfWeek.Friday))
            {
                return 5;
            }
            else //Saturday
            {
                return 6;
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