using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace LDVELH_WPF.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        bool loadingHero = false;

        public event GenerateActionButton ActionButtonChanged;
        public delegate void GenerateActionButton();

        Story _MyStory;
        public Story MyStory
        {
            get
            {
                return _MyStory;
            }
            set
            {
                if (_MyStory != value)
                {
                    _MyStory = value;
                    RaisePropertyChanged("MyStory");
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

        public String TitleWindow
        {
            get
            {
                return MyStory.PlayerHero.Name + " : paraph n°" + MyStory.PlayerHero.CurrentParagraph;
            }
        }
        public String StoryText
        {
            get
            {
                if(MyStory.ActualParagraph != null)
                {
                    return MyStory.ActualParagraph.ContentText;
                }
                return MyStory.content.Last().ContentText;
            }
        }

        private void InitHero()
        {
            Hero = new Hero("ViewModel");
            Hero.AddLoot(CreateLoot.CreateWeapon.Glaive());
            Hero.AddLoot(CreateLoot.CreateWeapon.Baton());
            Hero.AddLoot(CreateLoot.CreateConsummable.potionDeLampsur());
            Hero.AddLoot(CreateLoot.CreateConsummable.potionDeLampsur());
            Hero.AddLoot(CreateLoot.CreateFood.ration());
            Hero.AddLoot(CreateLoot.CreateSpecialItem.helmet());
            Hero.AddLoot(CreateLoot.CreateSpecialItem.buckler());
            Hero.AddCapacity(CapacityType.Healing);
            Hero.AddCapacity(CapacityType.Hiding);
            Hero.TakeDamage(5);
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
                Hero.RemoveLoot((Loot)item);
            }
        }

        private void UseItem(object itemToUse)
        {

            if (itemToUse != null)
            {
                try
                {
                    Hero.UseItem((Item)itemToUse);
                }
                catch (CantEatException)
                {
                    MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("CantEat"));

                }
                catch (CannotUseItemException ex)
                {
                    MessageBox.Show(ex.Message);
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

        public MainWindowViewModel(Hero hero, bool loading)
        {
            loadingHero = loading;
            InitHero(hero);
            InitStory(hero);
            Initialize();
        }
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
            Hero.PropertyChanged += Hero_PropertyChanged;
        }

        private void Hero_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "CurrentParagraph")
            {
                RaisePropertyChanged("StoryText");
                RaisePropertyChanged("TitleWindow");
            }
        }

        private void InitStory(Hero hero)
        {
            MyStory = new Story("RandomName", Hero);
            MyStory.AddParagraph(CreateParagraph.CreateAParagraph(Hero.CurrentParagraph));
            MyStory.PropertyChanged += MyStory_PropertyChanged;
            if (!loadingHero)
                MyStory.Start();
            else
            {
                MyStory.Start(hero.CurrentParagraph);
            }
        }

        private void MyStory_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "ActualParagraph")
            {
                ResolveParagraph();
            }
        }
        public void ResolveParagraph()
        {
            //First : the main event (that WILL happen, no choice, unless we're loading a Hero (so he already resolved the mains event))
            try
            {
                resolveMainEvents(MyStory);
            }
            catch (YouAreDeadException)
            {
                handleDeath(MyStory);
                return;
            }

            //Second, the decisions open to the player, as it is design code that should be generated, and it is not the ViewModel role, I generated an event that indicate the need to generate the actions buttons.
            //Our view should subscribe to this event and when it fires generate the actions button.
            //This way our MVVM pattern is respected
            ActionButtonHasChanged();
        }
        private void resolveMainEvents(Story story)
        {
            if (!loadingHero)
            {
                try
                {
                    story.ResolveActualParagraph();
                }
                catch (YouAreDeadException)
                {
                    throw;
                }

            }
            else
                loadingHero = false;
        }
        public void ActionButtonHasChanged()
        {
            GenerateActionButton handler = ActionButtonChanged;
            if (handler != null)
            {
                handler();
            }
        }
        public void handleDeath(Story story)
        {
            MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("YouDied"));
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    databaseRequest.DeleteHero(story.PlayerHero);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when deleting hero data : " + ex);
            }
            MenuLoad loadMenu = new MenuLoad() { DataContext = new MenuLoadViewModel() };
            loadMenu.Show();
            CloseWindow();
        }

        private void noNullInHero(Hero hero)
        {
            //When loading a Hero from our database, if he had no item/backpack/weapon/weaponHolder/capacity then those will be null instead of empty, this is the default behavior of SQLite.
            //we fix the possible problem immediately
            hero.NoNullInHero();
        }

    }
}
