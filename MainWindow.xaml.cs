using System.Windows;
using System.Windows.Controls;

namespace TimeLord_MVVM_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            OpenPage(new Views.Main());
        }
        public void OpenPage(Page page)
        {
            frame.Navigate(page);
        }
    }
}
