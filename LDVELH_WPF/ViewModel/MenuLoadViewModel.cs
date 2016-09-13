using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF.ViewModel
{
    class MenuLoadViewModel : ViewModelBase
    {
        Hero _SelectedHero;
        public Hero SelectedHero
        {
            get
            {
                return _SelectedHero;
            }
            set
            {
                if (_SelectedHero != value)
                {
                    _SelectedHero = value;
                    RaisePropertyChanged("SelectedHero");
                }
            }
        }
        ObservableCollection<Hero> _ListHeroes;
        public ObservableCollection<Hero> ListHeroes
        {
            get
            {
                return _ListHeroes;
            }
            set
            {
                _ListHeroes = value;
            }
        }
        private void LoadHeroes()
        {
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    ListHeroes = new ObservableCollection<Hero>(databaseRequest.GetAllHeroes());
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
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    databaseRequest.DeleteHero((Hero)hero);
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
                MainWindow mainWindow = new MainWindow(true) { DataContext = new MainWindowViewModel((Hero)hero) };
                mainWindow.Show();
                CloseWindow();
        }

        private void NewGame(object random)
        {
            MenuCapacities MenuCapacities = new MenuCapacities { DataContext = new MenuCapacitiesViewModel( ShowMyDialogBox()) };
            MenuCapacities.Show();
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
                if (testDialog.getCharacterName != "")
                {
                    return testDialog.getCharacterName;
                }
                else
                {
                    return GlobalTranslator.Instance.translator.ProvideValue("NoName");
                }

            }
            else
            {
                return GlobalTranslator.Instance.translator.ProvideValue("NoName");
            }

        }
    }
}
