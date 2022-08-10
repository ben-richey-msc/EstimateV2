using System.Windows;

namespace EstimateV2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SettingsWindow settingsWindow = new SettingsWindow();  

        }
    }
}
