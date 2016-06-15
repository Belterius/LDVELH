﻿using System;
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
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        Hero hero;
        Ennemy ennemy;
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
            setLife();
            setAgility();
            labelDammageTakenEnnemy.Content = "none";
            labelDammageTakenHero.Content = "none";
        }

        private void buttonNextRound_Click(object sender, RoutedEventArgs e)
        {
            buttonNextRound.Content = "Next Round";
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
                buttonNextRound.Content = "Victory !";
                labelRoundNumber.Content = "VICTORY";
                setLife();
                setDamageTaken();
                buttonNextRound.Click -= buttonNextRound_Click;
                buttonNextRound.Click += buttonVictory_Click;
            }
            else
            {
                roundNumber++;
                labelRoundNumber.Content = "Round number " + roundNumber;
                setLife();
                setDamageTaken();
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
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
