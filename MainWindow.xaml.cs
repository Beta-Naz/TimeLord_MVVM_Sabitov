using System.Windows;

namespace TimeLord_MVVM_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Views.Main());
        }
    }
}
