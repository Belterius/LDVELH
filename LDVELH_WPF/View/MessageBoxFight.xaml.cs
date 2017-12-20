using LDVELH_WPF.ViewModel;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;


namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for MessageBoxFight.xaml
    /// </summary>
    public partial class MessageBoxFight : Window
    {
        //DO NOT TOUTCH, IT'S BLACK MAGIC
        //It allows to make the exit button disappear from our window (as our user should NOT be able to escape a fight by closing the window ...)
        //cf http://stackoverflow.com/questions/743906/how-to-hide-close-button-in-wpf-window/867080 for more details
        private const int GwlStyle = -16;
        private const int WsSysmenu = 0x80000;

        public MessageBoxFight()
        {
            InitializeComponent();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            NativeMethods.SetWindowLong(hwnd, GwlStyle, NativeMethods.GetWindowLong(hwnd, GwlStyle) & ~WsSysmenu);
            ((FightViewModel)DataContext).FightEndedChanged += Vm_FightHasEnded;
        }
        private void Vm_FightHasEnded(object sender, EventArgs e)
        {
            DialogResult = true;
        }
    }
    internal static class NativeMethods
    {
        //DO NOT TOUTCH, IT'S BLACK MAGIC
        //It allows to make the exit button disappear from our window (as our user should NOT be able to escape a fight by closing the window ...)
        //cf http://stackoverflow.com/questions/743906/how-to-hide-close-button-in-wpf-window/867080 for more details
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }

}
