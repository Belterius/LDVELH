using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


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
        Ennemy ennemy;
        Translator translator;
        bool ranAway = false;
        int roundRunAway=999;
        bool fightOver = false;
        int roundNumber = 0;
        int previousLifeHero, previousLifeEnnemy;
        public MessageBoxFight()
        {
            InitializeComponent();
        }
        public MessageBoxFight(Hero hero, Ennemy ennemy)
        {
            InitializeComponent();
            this.hero = hero;
            this.ennemy = ennemy;
            this.translator = new Translator();
            buttonRun.Visibility = Visibility.Hidden;
            setLife();
            setAgility();
            labelDammageTakenEnnemy.Content = "0";
            labelDammageTakenHero.Content = "0";
        }
        public MessageBoxFight(Hero hero, Ennemy ennemy, int ranTurn)
        {
            InitializeComponent();
            this.hero = hero;
            this.ennemy = ennemy;
            this.translator = new Translator();
            this.roundRunAway = ranTurn;
            buttonRun.Visibility = Visibility.Hidden;
            setLife();
            setAgility();
            labelDammageTakenEnnemy.Content = "0";
            labelDammageTakenHero.Content = "0";
        }

        private void buttonNextRound_Click(object sender, RoutedEventArgs e)
        {
            buttonNextRound.Content = translator.ProvideValue("NextRound");
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
                buttonNextRound.Content = translator.ProvideValue("Victory") +" !";
                labelRoundNumber.Content = translator.ProvideValue("Victory").ToUpper() + "!";
                setLife();
                setDamageTaken();
                buttonNextRound.Click -= buttonNextRound_Click;
                buttonNextRound.Click += buttonVictory_Click;
            }
            else
            {
                roundNumber++;
                labelRoundNumber.Content = translator.ProvideValue("RoundNumber") + " " +roundNumber;
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
            labelAgilityHero.Content = hero.getBonusAgility(ennemy) + hero.getBaseAgility();
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
