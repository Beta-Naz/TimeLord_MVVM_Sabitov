using System.Windows.Controls;
using TimeLord_MVVM_Сабитов.ViewModels;

namespace TimeLord_MVVM_Сабитов.Views
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        public Timer()
        {
            InitializeComponent();
            DataContext = new VMTimer();
        }
    }
}
