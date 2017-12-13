using LDVELH_WPF.Helpers;
using System;
using System.Collections.ObjectModel;

namespace LDVELH_WPF.ViewModel
{
    public class MenuLoadViewModel : ViewModelBase
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
                using (SqLiteDatabaseFunction DatabaseRequest = new SqLiteDatabaseFunction())
                {
                    ListHeroes = new ObservableCollection<Hero>(DatabaseRequest.GetAllHeroes());
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
                using (SqLiteDatabaseFunction DatabaseRequest = new SqLiteDatabaseFunction())
                {
                    DatabaseRequest.DeleteHero((Hero)hero);
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
            MenuCapacities MenuCapacities = new MenuCapacities { DataContext = new MenuCapacitiesViewModel( ShowMyDialogBox()) };
            MenuCapacities.Show();
            CloseWindow();
        }
        private void Settings(object random)
        {
            MenuSettings MenuSetting = new MenuSettings { DataContext = new MenuSettingsViewModel() };
            MenuSetting.Show();
            CloseWindow();
        }
        private string ShowMyDialogBox()
        {
            MessageBoxInput TestDialog = new MessageBoxInput();

            if (TestDialog.ShowDialog() == true)
            {
                if (TestDialog.GetCharacterName != "")
                {
                    return TestDialog.GetCharacterName;
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
