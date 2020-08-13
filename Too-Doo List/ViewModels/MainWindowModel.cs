using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Too_Doo_List.ViewModels
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        object currentContentVM;
        private readonly DispatcherTimer _timer;
        public static DateTime CurrentTime { get { return DateTime.Now; } }

        public MainWindowModel()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Start();
            _timer.Tick += (o, e) => OnPropertyChanged("CurrentTime");
        }


        public object CurrentContentVM
        {
            get => currentContentVM;
            set
            {
                currentContentVM = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
