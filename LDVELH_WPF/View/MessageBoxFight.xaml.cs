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
        


        Hero Hero;
        Enemy Ennemy;
        bool RanAway = false;
        int RoundRunAway=999;
        bool FightOver = false;
        int RoundNumber = 0;
        int PreviousLifeHero, PreviousLifeEnnemy;
        public MessageBoxFight()
        {
            InitializeComponent();
            TranslateLabel();
        }
        private void TranslateLabel()
        {
            this.Title = GlobalTranslator.Instance.Translator.ProvideValue("Battling");
            buttonNextRound.Content = GlobalTranslator.Instance.Translator.ProvideValue("StartFight");
            groupBoxYourHero.Header = GlobalTranslator.Instance.Translator.ProvideValue("YourHero");
            labelHeroHP.Content = GlobalTranslator.Instance.Translator.ProvideValue("Life");
            labelHeroAgility.Content = GlobalTranslator.Instance.Translator.ProvideValue("Agility");
            labelHeroDamageTaken.Content = GlobalTranslator.Instance.Translator.ProvideValue("DamageTaken");
            GroupBoxYourEnemy.Header = GlobalTranslator.Instance.Translator.ProvideValue("YourEnemy");
            labelEnemyAgility.Content = GlobalTranslator.Instance.Translator.ProvideValue("Agility");
            labelEnemyLife.Content = GlobalTranslator.Instance.Translator.ProvideValue("Life");
            labelEnemyDamageTaken.Content = GlobalTranslator.Instance.Translator.ProvideValue("DamageTaken");
            labelRoundNumber.Content = GlobalTranslator.Instance.Translator.ProvideValue("YouMustFight");
            buttonRun.Content = GlobalTranslator.Instance.Translator.ProvideValue("Escape");
        }
        public MessageBoxFight(Hero hero, Enemy ennemy)
        {
            InitializeComponent();
            TranslateLabel();
            this.Hero = hero;
            this.Ennemy = ennemy;
            buttonRun.Visibility = Visibility.Hidden;
            SetLife();
            SetAgility();
            labelDammageTakenEnnemy.Content = "0";
            labelDammageTakenHero.Content = "0";
        }
        public MessageBoxFight(Hero hero, Enemy ennemy, int ranTurn)
        {
            InitializeComponent();
            this.Hero = hero;
            this.Ennemy = ennemy;
            this.RoundRunAway = ranTurn;
            buttonRun.Visibility = Visibility.Hidden;
            SetLife();
            SetAgility();
            labelDammageTakenEnnemy.Content = "0";
            labelDammageTakenHero.Content = "0";
        }

        private void buttonNextRound_Click(object sender, RoutedEventArgs e)
        {
            buttonNextRound.Content = GlobalTranslator.Instance.Translator.ProvideValue("NextRound");
            PreviousLifeHero = Hero.ActualHitPoint;
            PreviousLifeEnnemy = Ennemy.ActualHitPoint;
            try
            {
                FightOver = Hero.Fight(Ennemy);
            }
            catch(YouAreDeadException){
                DialogResult = true;
                throw;
            }
            if (FightOver)
            {
                buttonNextRound.Content = GlobalTranslator.Instance.Translator.ProvideValue("Victory") + " !";
                labelRoundNumber.Content = GlobalTranslator.Instance.Translator.ProvideValue("Victory").ToUpper() + "!";
                SetLife();
                SetDamageTaken();
                buttonNextRound.Click -= buttonNextRound_Click;
                buttonNextRound.Click += buttonVictory_Click;
            }
            else
            {
                RoundNumber++;
                labelRoundNumber.Content = GlobalTranslator.Instance.Translator.ProvideValue("RoundNumber") + " " + RoundNumber;
                SetLife();
                SetDamageTaken();
            }
            if(RoundNumber >= RoundRunAway)
            {
                buttonRun.Visibility = Visibility.Visible;
            }
        }
        private void buttonVictory_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void SetLife()
        {
            labelLifeEnnemy.Content = Ennemy.ActualHitPoint;
            labelLifeHero.Content = Hero.ActualHitPoint;
        }
        private void SetAgility()
        {
            labelAgilityEnnemy.Content = Ennemy.BaseAgility;
            labelAgilityHero.Content = Hero.GetHeroAgilityInBattle(Ennemy);
        }
        private void SetDamageTaken()
        {
            labelDammageTakenEnnemy.Content = PreviousLifeEnnemy - Ennemy.ActualHitPoint;
            labelDammageTakenHero.Content = PreviousLifeHero - Hero.ActualHitPoint;
        }

        private void buttonRun_Click(object sender, RoutedEventArgs e)
        {
            RanAway = true;
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            NativeMethods.SetWindowLong(hwnd, GWL_STYLE, NativeMethods.GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        public bool DidRanAway
        {
            get { return RanAway; }
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
