using System.Windows.Controls;
using TimeLord_MVVM_Сабитов.ViewModels;

namespace TimeLord_MVVM_Сабитов.Views
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            DataContext = new VMStopwatch();
        }
    }
}
