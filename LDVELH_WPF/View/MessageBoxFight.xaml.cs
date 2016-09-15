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
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        


        public MessageBoxFight()
        {
            InitializeComponent();
            TranslateLabel();

        }
        private void TranslateLabel()
        {
            this.Title = GlobalTranslator.Instance.Translator.ProvideValue("Battling");
            groupBoxYourHero.Header = GlobalTranslator.Instance.Translator.ProvideValue("YourHero");
            labelHeroHP.Content = GlobalTranslator.Instance.Translator.ProvideValue("Life");
            labelHeroAgility.Content = GlobalTranslator.Instance.Translator.ProvideValue("Agility");
            labelHeroDamageTaken.Content = GlobalTranslator.Instance.Translator.ProvideValue("DamageTaken");
            GroupBoxYourEnemy.Header = GlobalTranslator.Instance.Translator.ProvideValue("YourEnemy");
            labelEnemyAgility.Content = GlobalTranslator.Instance.Translator.ProvideValue("Agility");
            labelEnemyLife.Content = GlobalTranslator.Instance.Translator.ProvideValue("Life");
            labelEnemyDamageTaken.Content = GlobalTranslator.Instance.Translator.ProvideValue("DamageTaken");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            NativeMethods.SetWindowLong(hwnd, GWL_STYLE, NativeMethods.GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
            ((FightViewModel)DataContext).FightEndedChanged += Vm_FightHasEnded;
        }
        private void Vm_FightHasEnded()
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
