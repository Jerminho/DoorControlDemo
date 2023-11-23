using DoorControlDemo.ViewModels;
using System.Windows;

namespace DoorControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; } = new(); 
        public MainWindow()
        {
            DataContext = MainViewModel;
            InitializeComponent();
        }
    }
}
