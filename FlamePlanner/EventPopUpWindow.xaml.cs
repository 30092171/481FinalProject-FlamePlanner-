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

        public EventPopUpWindow SetTitle(string title)
        {
            Title.Content = title;
            return this;
        }
        public EventPopUpWindow SetImage(ImageSource image)
        {
            EventImage.Source = image;
            return this;
        }
        public EventPopUpWindow SetTime(string time)
        {
            Time.Text = time;
            return this;
        }
        public EventPopUpWindow SetDate(string date)
        {
            Date.Text = date;
            return this;
        }
        public EventPopUpWindow SetLocation(string location)
        {
            Location.Text = location;
            return this;
        }
        public EventPopUpWindow SetDescription(string description)
        {
            Description.Text = description;
            return this;
        }
        public EventPopUpWindow SetLinks(params string[] links)
        {
            Links.Inlines.Clear();
            foreach(string s in links)
            {
                Hyperlink l = new Hyperlink();
                l.Inlines.Add(s);
                l.NavigateUri = new Uri(s);
                Links.Inlines.Add(l);
            }
            return this;
        }
    }
}
