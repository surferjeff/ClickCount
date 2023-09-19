using System.ComponentModel;
using System.Windows;

namespace WpfCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClickCount clickCount = new ClickCount();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = clickCount;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // DataContext.clickCount += 1;
            // Why does the commented line above fail to compile with the error?
            // Error CS1061  'object' does not contain a definition for 'clickCount' and no accessible extension method 'clickCount' accepting a first argument of type 'object' could be found(are you missing a using directive or an assembly reference ?)
            clickCount.Count += 1;
        }
    }

    class ClickCount : INotifyPropertyChanged
    {
        int _count = 0;
        public int Count {
            get => _count;
            set {
                _count = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
