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

            DialogResult = true;
            Close();
        }
    }
}
