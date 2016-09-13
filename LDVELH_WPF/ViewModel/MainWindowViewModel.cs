using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                    RaisePropertyChanged("HeroDisplayHP");
                }
            }
        }
        public String ActualHitPoint
        {
            get
            {
                return _Hero.ActualHitPoint.ToString() +"/" + _Hero.MaxHitPoint.ToString();
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
       
        private void InitHero()
        {
            Hero = new Hero("ViewModel");
            Hero.addLoot(CreateLoot.CreateWeapon.Glaive());
            Hero.addLoot(CreateLoot.CreateWeapon.Baton());
            Hero.addLoot(CreateLoot.CreateConsummable.potionDeLampsur());
            Hero.addLoot(CreateLoot.CreateConsummable.potionDeLampsur());
            Hero.addLoot(CreateLoot.CreateFood.ration());
            Hero.addLoot(CreateLoot.CreateSpecialItem.helmet());
            Hero.addLoot(CreateLoot.CreateSpecialItem.buckler());
            Hero.addCapacity(CapacityType.Healing);
            Hero.addCapacity(CapacityType.Hiding);
            Hero.takeDamage(5);
        }

        public RelayCommand ThrowLootCommand { get; set; }
        public RelayCommand UseItemCommand { get; set; }
        public RelayCommand SaveHeroCommand { get; set; }
        public RelayCommand LoadHeroCommand { get; set; }

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
        private void SaveHero(object hero)
        {
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    databaseRequest.SaveHero((Hero)hero);
                }
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("SuccesSaving"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorSaving"));
                System.Diagnostics.Debug.WriteLine("Error saving Hero : " + ex);
            }
        }
        private void LoadHero(object random)
        {
            if (MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ConfirmExit"), GlobalTranslator.Instance.translator.ProvideValue("GoToLoadingMenu"), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {

            }
            else
            {
                MenuLoad loadMenu = new MenuLoad { DataContext = new MenuLoadViewModel() };
                loadMenu.Show();
                CloseWindow();
            }
        }

        public MainWindowViewModel(Hero hero)
        {
            InitHero(hero);
            Initialize();
        }
        //public MainWindowViewModel()
        //{
        //    InitHero();
        //    Initialize();
        //}
        private void Initialize()
        {
            ThrowLootCommand = new RelayCommand(ThrowLoot);
            UseItemCommand = new RelayCommand(UseItem);
            LoadHeroCommand = new RelayCommand(LoadHero);
            SaveHeroCommand = new RelayCommand(SaveHero);
        }
        private void InitHero(Hero hero)
        {
            Hero = hero;
            noNullInHero(hero);
        }

        private void noNullInHero(Hero hero)
        {
            //When loading a Hero from our database, if he had no item/backpack/weapon/weaponHolder/capacity then those will be null instead of empty.
            //we fix the possible problem immediately
            hero.noNullInHero();
        }

    }
}
