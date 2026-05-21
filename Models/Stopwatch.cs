using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimeLord_MVVM_Сабитов.ViewModels;

namespace TimeLord_MVVM_Сабитов.Models
{
    public class Stopwatch : INotifyPropertyChanged
    {
        public bool Work;
        private int _time;
        public int Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged("Timer");
            }
        }
        private RelayCommand _startTimer;
        public RelayCommand StartTimer
        {
            get
            {
                return _startTimer ??
                    (_startTimer = new RelayCommand(obj =>
                    {
                        if (!Work)
                        {
                            Interval.Clear();
                            Time = 0;
                            Work = true;
                            TextButton = "Стоп";
                        }
                        else
                        {
                            Work = false;
                            TextButton = "Начать";
                        }
                    }));
            }
        }
        private RelayCommand _intervalTimer;
        public RelayCommand IntervalTimer
        {
            get
            {
                return _intervalTimer ??
                    (_intervalTimer = new RelayCommand(obj =>
                    {
                        if (Work)
                        {
                            Interval.Insert(0,Timer);
                        }
                    }));
            }
        }
        private RelayCommand _goToTimer;
        public RelayCommand GoToTimer
        {
            get
            {
                return _goToTimer ??
                    (_goToTimer = new RelayCommand(obj =>
                    {
                        MainWindow.Instance.OpenPage(new Views.Timer());
                    }));
            }
        }
        public ObservableCollection<string> Interval {get; set;}
        public Stopwatch()
        {
            Interval = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public string Timer
        {
            get
            {
                float hour = Time / 3600f;
                float minute = Time / 60f - (int)hour * 60f;
                float second = Time - (int)hour * 360f - (int)minute * 60f;
                string sHour = ((int)hour).ToString();
                string sMinute = ((int)minute).ToString();
                string sSecond = ((int)second).ToString();
                if(hour < 10) sHour = "0" + sHour;
                if (minute < 10) sMinute = "0" + sMinute;
                if (second < 10) sSecond = "0" + sSecond;
                return $"{sHour}:{sMinute}:{sSecond}";
            }
        }
        private string _textButton = "Начать";
        public string TextButton
        {
            get => _textButton;
            set
            {
                _textButton = value;
                OnPropertyChanged("TextButton");
            }
            
        }
    }
}
