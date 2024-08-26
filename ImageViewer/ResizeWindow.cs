using ImageViewer;

public static class ResizeWindow {
    public static void Resize(MainWindow window, bool isUpscaling, int scaleFactor) {
        if (isUpscaling) {
            window.IMG.Width = (int)window.IMG.ActualWidth + scaleFactor;
            window.Top -= scaleFactor / 2;
            window.Left -= scaleFactor / 2;
        } else {
            if (scaleFactor * 2 > window.IMG.ActualHeight) return;
            if (scaleFactor * 2 > window.IMG.ActualWidth) return;
            window.IMG.Width = (int)window.IMG.ActualWidth - scaleFactor;
            window.Top += scaleFactor / 2;
            window.Left += scaleFactor / 2;
        }
    }
}
