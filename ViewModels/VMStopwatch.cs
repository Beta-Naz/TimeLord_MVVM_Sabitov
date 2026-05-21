using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using TimeLord_MVVM_Сабитов.Models;

namespace TimeLord_MVVM_Сабитов.ViewModels
{
    internal class VMStopwatch : INotifyPropertyChanged
    {
        public Stopwatch Stopwatch { get; set; }
        private DispatcherTimer _timer = new DispatcherTimer()
        {
            Interval = new System.TimeSpan(0, 0, 1),
        };
        public VMStopwatch()
        {
            Stopwatch = new Stopwatch()
            {
                Work = false,
                Time = 0
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (Stopwatch.Work)
            {
                Stopwatch.Time++;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        } 
    }
}
