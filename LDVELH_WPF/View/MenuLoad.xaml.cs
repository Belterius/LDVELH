using System;
using System.Collections.Generic;
using System.Windows;

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
                MainWindow mainWindow = new MainWindow((Hero)listBoxHeroes.SelectedItem);
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when loading hero data : " + ex);
            }
            
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            MenuSettings menuSetting = new MenuSettings();
            menuSetting.Show();
            this.Close();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    databaseRequest.DeleteHero((Hero)listBoxHeroes.SelectedItem);
                }
                listHeroes.Remove((Hero)listBoxHeroes.SelectedItem);
                listBoxHeroes.Items.Refresh();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when loading hero data : " + ex);
            }
        }
    }
}
