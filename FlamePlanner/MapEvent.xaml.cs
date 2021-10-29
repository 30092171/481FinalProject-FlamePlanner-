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
        public MapEvent()
        {
            InitializeComponent();
        }
        public MapEvent(string eventName)
        {
            InitializeComponent();
            event_label.Content = eventName;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
