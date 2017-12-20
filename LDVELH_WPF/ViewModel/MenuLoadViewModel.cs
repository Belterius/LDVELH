using LDVELH_WPF.Helpers;
using System;
using System.Collections.ObjectModel;

namespace LDVELH_WPF.ViewModel
{
    public class MenuLoadViewModel : ViewModelBase
    {
        private Hero _selectedHero;
        public Hero SelectedHero
        {
            get
            {
                return _selectedHero;
            }
            set
            {
                if (_selectedHero != value)
                {
                    _selectedHero = value;
                    RaisePropertyChanged("SelectedHero");
                }
            }
        }

        public ObservableCollection<Hero> ListHeroes { get; set; }

        private void LoadHeroes()
        {
            try
            {
                using (SqLiteDatabaseFunction databaseRequest = new SqLiteDatabaseFunction())
                {
                    ListHeroes = new ObservableCollection<Hero>(SqLiteDatabaseFunction.GetAllHeroes());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when loading all heroes data : " + ex);
                //buttonLoad.Visibility = Visibility.Hidden;
            }
        }
        public MenuLoadViewModel()
        {
            DeleteHeroCommand = new RelayCommand(DeleteHero);
            LoadHeroCommand = new RelayCommand(LoadHero);
            NewGameCommand = new RelayCommand(NewGame);
            SettingsCommand = new RelayCommand(Settings);
            LoadHeroes();
        }
        public RelayCommand DeleteHeroCommand { get; set; }
        public RelayCommand LoadHeroCommand { get; set; }
        public RelayCommand NewGameCommand { get; set; }
        public RelayCommand SettingsCommand { get; set; }

        private void DeleteHero(object hero)
        {
            if (hero == null) return;
            try
            {
                using (SqLiteDatabaseFunction databaseRequest = new SqLiteDatabaseFunction())
                {
                    SqLiteDatabaseFunction.DeleteHero((Hero)hero);
                }
                ListHeroes.Remove((Hero)hero);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when loading hero data : " + ex);
            }
        }
        private void LoadHero(object hero)
        {
                if (hero == null) return;
                MainWindow mainWindow = new MainWindow() { DataContext = new MainWindowViewModel((Hero)hero, true) };
                mainWindow.Show();
                CloseWindow();
        }

        private void NewGame(object random)
        {
            MenuCapacities menuCapacities = new MenuCapacities { DataContext = new MenuCapacitiesViewModel( ShowMyDialogBox()) };
            menuCapacities.Show();
            CloseWindow();
        }
        private void Settings(object random)
        {
            MenuSettings menuSetting = new MenuSettings { DataContext = new MenuSettingsViewModel() };
            menuSetting.Show();
            CloseWindow();
        }
        private string ShowMyDialogBox()
        {
            MessageBoxInput testDialog = new MessageBoxInput();

            if (testDialog.ShowDialog() == true)
            {
                if (testDialog.GetCharacterName != "")
                {
                    return testDialog.GetCharacterName;
                }
                else
                {
                    return GlobalTranslator.Instance.Translator.ProvideValue("NoName");
                }

            }
            else
            {
                return GlobalTranslator.Instance.Translator.ProvideValue("NoName");
            }

        }
    }
}
