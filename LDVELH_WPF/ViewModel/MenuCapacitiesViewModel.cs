using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LDVELH_WPF.ViewModel
{
    public class MenuCapacitiesViewModel : ViewModelBase
    {
        string _HeroName;
        public string HeroName
        {
            get
            {
                return _HeroName;
            }
            set
            {
                if (_HeroName != value)
                {
                    _HeroName = value;
                    RaisePropertyChanged("HeroName");
                }
            }
        }
        Hero _Hero;
        public Hero Hero
        {
            get
            {
                return _Hero;
            }
            set
            {
                if (_Hero != value)
                {
                    _Hero = value;
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
            MainWindow MainWindow = new MainWindow() { DataContext = new MainWindowViewModel(Hero, false) };
            MainWindow.Show();
            CloseWindow();

        }
        private void AddCapacity(object capacity)
        {
            try
            {
                Hero.AddCapacity((CapacityType)capacity);

            }
            catch (MaxNumberOfCapacitiesReached ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void RemoveCapacity(object capacity)
        {
                Hero.RemoveCapacity((CapacityType)capacity);
        }
    }
}
