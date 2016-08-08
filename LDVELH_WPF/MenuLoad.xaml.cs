﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for LoadMenu.xaml
    /// </summary>
    public partial class MenuLoad : Window
    {
        List<Hero> listHeroes;
        public MenuLoad()
        {
            InitializeComponent();
            TranslateLabel();
        }
        private void TranslateLabel()
        {
            this.Title = GlobalTranslator.Instance.translator.ProvideValue("LoadMenu");
            buttonLoad.Content = GlobalTranslator.Instance.translator.ProvideValue("Load");
            buttonNew.Content = GlobalTranslator.Instance.translator.ProvideValue("NewGame");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    listHeroes = databaseRequest.GetAllHeroes();
                }
                listBoxHeroes.ItemsSource = listHeroes;
                listBoxHeroes.DisplayMemberPath = "getResume";
                listBoxHeroes.SelectedValuePath = "CharacterID";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when loading all heroes data : " + ex);
                buttonLoad.Visibility = Visibility.Hidden;
            }
           
        }

        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hero heroSelected;
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    heroSelected = databaseRequest.SelectHeroFromID((int)listBoxHeroes.SelectedValue);
                }
                MainWindow mainWindow = new MainWindow(heroSelected);
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when loading hero data : " + ex);
            }
            
        }
    }
}
