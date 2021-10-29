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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EventPopUpWindow : Window
    {
        public string EventName;
        private MainWindow mw;
        public EventPopUpWindow(MainWindow mw) //Later we will add more parameters so that construction is easier
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MapEvent me = new MapEvent(mw,this.EventName,this);
            me.ShowDialog();


        }
    }
}
