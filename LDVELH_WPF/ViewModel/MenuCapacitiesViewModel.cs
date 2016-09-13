using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF.ViewModel
{
    class MenuCapacitiesViewModel : ViewModelBase
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

        public MenuCapacitiesViewModel()
        {
            HeroName = "NoName";
            Initialize();
            
        }
        public MenuCapacitiesViewModel(string name)
        {
            HeroName = name;
            Initialize();
        }
        private void Initialize()
        {
            ConfirmCommand = new RelayCommand(Confirm);
        }
        public RelayCommand ConfirmCommand { get; set; }

        private void Confirm(object random)
        {

        }
    }
}
