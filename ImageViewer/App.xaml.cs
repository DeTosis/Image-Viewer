using System.Diagnostics;
using System.Windows;

namespace ImageViewer {
    public partial class App : Application {
        void App_Startup(object sender, StartupEventArgs e) {
            MainWindow mainWindow = new MainWindow(e.Args);
            mainWindow.Show();
        }
    }

}
