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
    /// Interaction logic for CalgaryFlamesPopUpWindow.xaml
    /// </summary>
    public partial class CalgaryFlamesPopUpWindow : Window
    {
        public string EventName;
        private MainWindow mw;
        public CalgaryFlamesPopUpWindow(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //MapEvent me = new MapEvent(mw, this.EventName, this);
            //me.ShowDialog();


        }
    }
}
