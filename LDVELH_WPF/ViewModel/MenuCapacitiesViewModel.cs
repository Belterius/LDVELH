using LDVELH_WPF.Helpers;
using System.Windows;

namespace LDVELH_WPF.ViewModel
{
    public class MenuCapacitiesViewModel : ViewModelBase
    {
        private string _heroName;
        public string HeroName
        {
            get
            {
                return _heroName;
            }
            set
            {
                if (_heroName != value)
                {
                    _heroName = value;
                    RaisePropertyChanged("HeroName");
                }
            }
        }
        public string CapacityTitle => $"{GlobalTranslator.Instance.Translator.ProvideValue("ListCapacities")} {Hero.Capacities.Count}/{Hero.MaxNumberOfCapacities}";

        private Hero _hero;
        public Hero Hero
        {
            get
            {
                return _hero;
            }
            set
            {
                if (_hero != value)
                {
                    _hero = value;
                    RaisePropertyChanged("Hero");
                }
            }
        }
        public MenuCapacitiesViewModel()
        {
            HeroName = "NoName";
            Initialize();
            
        }
        public MenuCapacitiesViewModel(string name)
        {
            HeroName = name;
            Initialize();
            Hero = new Hero(HeroName);
        }
        private void Initialize()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            AddCapacityCommand = new RelayCommand(AddCapacity);
            RemoveCapacityCommand = new RelayCommand(RemoveCapacity);
        }
        public RelayCommand ConfirmCommand { get; set; }
        public RelayCommand AddCapacityCommand { get; set; }
        public RelayCommand RemoveCapacityCommand { get; set; }

        private void Confirm(object random)
        {

            if (Hero.MaxNumberOfCapacities != Hero.Capacities.Count)
            {
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("YouMustSelect") + " " + Hero.MaxNumberOfCapacities + " " + GlobalTranslator.Instance.Translator.ProvideValue("Capacities") + " !");
                return;
            }
            MainWindow mainWindow = new MainWindow() { DataContext = new MainWindowViewModel(Hero, false) };
            mainWindow.Show();
            CloseWindow();

        }
        private void AddCapacity(object capacity)
        {
            try
            {
                Hero.AddCapacity((CapacityType)capacity);
                RaisePropertyChanged("CapacityTitle");

            }
            catch (MaxNumberOfCapacitiesReached ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void RemoveCapacity(object capacity)
        {
            Hero.RemoveCapacity((CapacityType)capacity);
            RaisePropertyChanged("CapacityTitle");
        }
    }
}
