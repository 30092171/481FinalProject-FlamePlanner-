using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;

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
        private Itinerary itin;

        public Event_left(MainWindow mw)
        {
            this.mw = mw;
            this.itin = mw.bufferItinerary;
            InitializeComponent();
            
            InitialTimePopulator();
            Time_Array_populator();
            DateTime startDate = new DateTime(2021, 9, 5);
            currentDate = new DateTime(2021, 09, 05); //= new DateTime(year,month,day)
            Date_Array_populator(startDate);
            //itin.eventList.Add(new EventObject("apple", "", "", new DateTime(2021, 9, 5), 600, 2145));
            //itin.eventList.Add(new EventObject("Banana", "", "", new DateTime(2021, 10, 2), 1000, 1330));
            displayEvents();

            if (mw.loggedIn)
            {
                accountBanner.Text = "Username: " + mw.currentAcount;
                accountBanner.Background = Brushes.LightBlue;
            }
            else
            {
                accountBanner.Text = "Not Logged In";
                accountBanner.Background = Brushes.LightYellow;
            }
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
                displayEvents();
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
            displayEvents();
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
            Boolean[] b = new Boolean[6]; //row major. Each row repersents a time slot

            //removes all children from a grid column
            for (int i = 1; i <= 6; i++)
            {
                UIElement a = getChildFromCoordinate(i, 1);
                if (a != null)
                {
                    mainGrid.Children.Remove(a);
                }
                b[i - 1] = false;
            }

            foreach (EventObject e in itin.eventList)
            {

                if (e.isVisible == true)
                {
                    if (e.startTime >= e.endTime)
                    {
                        continue; //prevents crashing
                    }

                    if (e.startDate.Day == currentDate.Day)
                    {
                        Boolean crossOver = false;
                        if (e.endTime > startTime && e.startTime < startTime)
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
                            int e_hour = (e.endTime - e_min) / 100;

                            int row = s_hour - (startTime - startTime % 100) / 100 + 1;
                            int col = 1;

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

                            t.FontSize = 15;
                            t.TextWrapping = TextWrapping.WrapWithOverflow;

                            TextBlock t2 = new TextBlock();
                            if (e.startTime < 1300)
                            {
                                if (display_s_hour == 0)
                                {
                                    display_s_hour = 12;
                                }

                                if (e.endTime < 1300)
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

                            if (e.endTime - e.startTime < 100)
                            {
                                //Title only view due to reduced space
                                t.FontSize = 8;
                                sp.Children.Add(t);

                            }
                            else
                            {
                                sp.Children.Add(t);
                                sp.Children.Add(t2);
                            }


                            newGrid.Children.Add(sp);


                            double ds_min = s_min;
                            double de_min = e_min;

                            //Figure out intertime margin
                            margin.Left = 2;
                            margin.Top = (ds_min / 60 * 52) + 2;
                            margin.Right = 2;
                            if (row + span > 7)
                            {
                                margin.Bottom = 0; //runs off grid
                                span = 7 - row;
                            }
                            else
                            {
                                if (e_min == 0)
                                {
                                    if (span > 1)
                                    {
                                        span = span - 1; //This way you don't have a 0 span
                                    }
                                    margin.Bottom = 0;
                                }
                                else
                                {
                                    margin.Bottom = ((60 - de_min) / 60) * 52 + 2;
                                }
                            }

                            


                            Boolean conflict = false;

                            for(int i = 0; i < span; i++)
                            {
                                
                                if (i+row-1<6 && b[i + row - 1] == true)
                                {
                                    conflict = true;
                                    break;
                                }
                            }

                            if (conflict)
                            {
                                e.isVisible = false;
                                //Don't need to say anything as they will see it is unchecked on the itinerary page
                            }
                            else
                            {

                                Border border = new Border();
                                border.BorderBrush = Brushes.Black;
                                border.BorderThickness = new Thickness(0, 2, 0, 2);
                                border.Child = newGrid;
                                border.Margin = margin;

                                mainGrid.Children.Add(border);
                                Grid.SetRow(border, row);
                                Grid.SetColumn(border, col);
                                Grid.SetRowSpan(border, span);

                                
                                for (int i = 0; i < span; i++)
                                {
                                    
                                    if (i + row - 1 < 6)
                                    {
                                        b[i + row - 1] = true;
                                    }
                                }

                                //Currently does not account for day overflow
                            }
                        }
                    }
                }
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
