using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
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
        Weapon _SelectedWeapon;
        public Weapon SelectedWeapon
        {
            get
            {
                return _SelectedWeapon;
            }
            set
            {
                if (_SelectedWeapon != value)
                {
                    _SelectedWeapon = value;
                    RaisePropertyChanged("SelectedWeapon");
                }
            }
        }

        Item _SelectedItem;
        public Item SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }
        public MainWindowViewModel()
        {
            InitHero();
            ThrowLootCommand = new RelayCommand(ThrowLoot);
            UseItemCommand = new RelayCommand(UseItem);
        }
        private void InitHero()
        {
            Hero = new Hero("ViewModel");
            Hero.addLoot(CreateLoot.CreateWeapon.Glaive());
            Hero.addLoot(CreateLoot.CreateWeapon.Baton());
            Hero.addLoot(CreateLoot.CreateConsummable.potionDeLampsur());
            Hero.addLoot(CreateLoot.CreateConsummable.potionDeLampsur());
            Hero.addCapacity(CapacityType.Healing);
            Hero.addCapacity(CapacityType.Hiding);
            Hero.takeDamage(5);
        }

        public RelayCommand ThrowLootCommand { get; set; }
        public RelayCommand UseItemCommand { get; set; }

        private void ThrowLoot(object item)
        {
            //Item itemToThrow = (Item)sender;
            if (item != null)
            {
                Hero.removeLoot((Loot)item);
            }
        }

        private void UseItem(object itemToUse)
        {

            if (itemToUse != null)
            {
                try
                {
                    Hero.useItem((Item)itemToUse);
                }
                catch (CantEatException)
                {
                   // MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("CantEat"));

                }
                catch (CannotUseItemException ex)
                {
                   // MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
