using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using static ResizeWindow;


namespace ImageViewer {
    public partial class MainWindow : Window, INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _IMGsource;
        public string imgSource {
            get { return _IMGsource; }
            set { 
                _IMGsource = value;
                OnPropertyChanged();
            }
        }

        private string _winName;
        public string WinName {
            get { return _winName; }
            set { _winName = value; }
        }

        public MainWindow(string[] _args) {
            if (_args.Length < 1) { 
                Environment.Exit(0);
                Close(); 
            }
            InitializeComponent();
            //Startup();
            DataContext = this;

            string[] _fileName = _args[0].Split(@"\");
            string[] _ext = _fileName.Last().Split(".");

            List<string> supported_ext = new() {
                "png", "bmp", "jpg"
            };

            if (!supported_ext.Contains(_ext.Last())) { Close(); }
            WinName = _fileName.Last();
            imgSource = _args[0];
        }

        private void Startup() {
            string pName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == pName) > 1) {
                Process[] proc = Process.GetProcessesByName(pName);
                proc[0].Kill();
            }
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
            if (e.ChangedButton == MouseButton.Right) {
                Environment.Exit(0);
                Close();
            }
        }

        readonly int ScreenW = (int)SystemParameters.PrimaryScreenWidth;
        readonly int ScreenH = (int)SystemParameters.PrimaryScreenHeight;
        private void IMG_MouseWheel(object sender, MouseWheelEventArgs e) {
            int ScaleFactor = 150;
            if (e.Delta > 0) {
                if (IMG.ActualWidth >= ScreenW / 100 * 95) return;
                Resize(this, true, ScaleFactor);
            } else {
                if (IMG.ActualWidth <= ScreenW / 100 * 6) return;
                Resize(this, false, ScaleFactor);
            }
        }
    }
}