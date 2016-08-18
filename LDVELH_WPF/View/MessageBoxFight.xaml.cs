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
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        Hero hero;
        Enemy ennemy;
        bool ranAway = false;
        int roundRunAway=999;
        bool fightOver = false;
        int roundNumber = 0;
        int previousLifeHero, previousLifeEnnemy;
        public MessageBoxFight()
        {
            InitializeComponent();
            TranslateLabel();
        }
        private void TranslateLabel()
        {
            this.Title = GlobalTranslator.Instance.translator.ProvideValue("Battling");
            buttonNextRound.Content = GlobalTranslator.Instance.translator.ProvideValue("StartFight");
            groupBoxYourHero.Header = GlobalTranslator.Instance.translator.ProvideValue("YourHero");
            labelHeroHP.Content = GlobalTranslator.Instance.translator.ProvideValue("Life");
            labelHeroAgility.Content = GlobalTranslator.Instance.translator.ProvideValue("Agility");
            labelHeroDamageTaken.Content = GlobalTranslator.Instance.translator.ProvideValue("DamageTaken");
            GroupBoxYourEnemy.Header = GlobalTranslator.Instance.translator.ProvideValue("YourEnemy");
            labelEnemyAgility.Content = GlobalTranslator.Instance.translator.ProvideValue("Agility");
            labelEnemyLife.Content = GlobalTranslator.Instance.translator.ProvideValue("Life");
            labelEnemyDamageTaken.Content = GlobalTranslator.Instance.translator.ProvideValue("DamageTaken");
            labelRoundNumber.Content = GlobalTranslator.Instance.translator.ProvideValue("YouMustFight");
            buttonRun.Content = GlobalTranslator.Instance.translator.ProvideValue("Escape");
        }
        public MessageBoxFight(Hero hero, Enemy ennemy)
        {
            InitializeComponent();
            TranslateLabel();
            this.hero = hero;
            this.ennemy = ennemy;
            buttonRun.Visibility = Visibility.Hidden;
            setLife();
            setAgility();
            labelDammageTakenEnnemy.Content = "0";
            labelDammageTakenHero.Content = "0";
        }
        public MessageBoxFight(Hero hero, Enemy ennemy, int ranTurn)
        {
            InitializeComponent();
            this.hero = hero;
            this.ennemy = ennemy;
            this.roundRunAway = ranTurn;
            buttonRun.Visibility = Visibility.Hidden;
            setLife();
            setAgility();
            labelDammageTakenEnnemy.Content = "0";
            labelDammageTakenHero.Content = "0";
        }

        private void buttonNextRound_Click(object sender, RoutedEventArgs e)
        {
            buttonNextRound.Content = GlobalTranslator.Instance.translator.ProvideValue("NextRound");
            previousLifeHero = hero.getActualHitPoint();
            previousLifeEnnemy = ennemy.getActualHitPoint();
            try
            {
                fightOver = hero.Fight(ennemy);
            }
            catch(YouAreDeadException){
                DialogResult = true;
                throw;
            }
            if (fightOver)
            {
                buttonNextRound.Content = GlobalTranslator.Instance.translator.ProvideValue("Victory") + " !";
                labelRoundNumber.Content = GlobalTranslator.Instance.translator.ProvideValue("Victory").ToUpper() + "!";
                setLife();
                setDamageTaken();
                buttonNextRound.Click -= buttonNextRound_Click;
                buttonNextRound.Click += buttonVictory_Click;
            }
            else
            {
                roundNumber++;
                labelRoundNumber.Content = GlobalTranslator.Instance.translator.ProvideValue("RoundNumber") + " " + roundNumber;
                setLife();
                setDamageTaken();
            }
            if(roundNumber >= roundRunAway)
            {
                buttonRun.Visibility = Visibility.Visible;
            }
        }
        private void buttonVictory_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void setLife()
        {
            labelLifeEnnemy.Content = ennemy.getActualHitPoint();
            labelLifeHero.Content = hero.getActualHitPoint();
        }
        private void setAgility()
        {
            labelAgilityEnnemy.Content = ennemy.getBaseAgility();
            labelAgilityHero.Content = hero.getHeroAgilityInBattle(ennemy);
        }
        private void setDamageTaken()
        {
            labelDammageTakenEnnemy.Content = previousLifeEnnemy - ennemy.getActualHitPoint();
            labelDammageTakenHero.Content = previousLifeHero - hero.getActualHitPoint();
        }

        private void buttonRun_Click(object sender, RoutedEventArgs e)
        {
            ranAway = true;
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        public bool DidRanAway
        {
            get { return ranAway; }
        }
    }
}
