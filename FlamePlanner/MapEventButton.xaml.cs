using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for MapEventButton.xaml
    /// </summary>
    public partial class MapEventButton : UserControl
    {
        public static readonly DependencyProperty TextDependency = DependencyProperty.Register("Text", typeof(string), typeof(MapEventButton),
            new PropertyMetadata("Placeholder", new PropertyChangedCallback(ChangedText)));
        public static readonly DependencyProperty SourceDependency = DependencyProperty.Register("Source", typeof(ImageSource), typeof(MapEventButton),
            new PropertyMetadata(null, new PropertyChangedCallback(ChangedSource)));
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MapEventButton));
        public ImageSource Source
        {
            get => GetValue(SourceDependency) as ImageSource;
            set => SetValue(SourceDependency, value);
        }
        public string Text
        {
            get => GetValue(TextDependency) as string;
            set => SetValue(TextDependency, value);
        }
        public event RoutedEventHandler Click
        {
            add => AddHandler(ClickEvent, value);
            remove => RemoveHandler(ClickEvent, value);
        }
        public MapEventButton()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
            => RaiseEvent(new RoutedEventArgs(ClickEvent));

        private static void ChangedText(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => (d as MapEventButton).label.Content = e.NewValue;
        private static void ChangedSource(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => (d as MapEventButton).marker.Source = e.NewValue as ImageSource;
    }
}
