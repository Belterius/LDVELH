using LDVELH_WPF.Helpers;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace LDVELH_WPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public Translator MyTranslator => GlobalTranslator.Instance.Translator;

        public string Test => "HitPoints";

        private bool _loadingHero = false;

        public event GenerateActionButton ActionButtonChanged;
        public delegate void GenerateActionButton(object sender, EventArgs e);

        private Story _myStory;
        public Story MyStory
        {
            get
            {
                return _myStory;
            }
            set
            {
                if (_myStory != value)
                {
                    _myStory = value;
                    RaisePropertyChanged("MyStory");
                }
            }
        }

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
                    RaisePropertyChanged("HeroDisplayHP");
                }
            }
        }
        public string ActualHitPoint => Hero.ActualHitPoint.ToString() +"/" + Hero.MaxHitPoint.ToString();
        private Weapon _selectedWeapon;
        public Weapon SelectedWeapon
        {
            get
            {
                return _selectedWeapon;
            }
            set
            {
                if (_selectedWeapon != value)
                {
                    _selectedWeapon = value;
                    RaisePropertyChanged("SelectedWeapon");
                }
            }
        }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }

        public string TitleWindow => MyStory.PlayerHero.Name + " : paraph n°" + MyStory.PlayerHero.CurrentParagraph;

        public string StoryText => MyStory.ActualParagraph != null ? MyStory.ActualParagraph.ContentText : MyStory.Content.Last().ContentText;

        private void InitHero()
        {
            Hero = new Hero("ViewModel");
            Hero.AddLoot(CreateLoot.CreateWeapon.Glaive());
            Hero.AddLoot(CreateLoot.CreateWeapon.Baton());
            Hero.AddLoot(CreateLoot.CreateConsumable.PotionDeLampsur());
            Hero.AddLoot(CreateLoot.CreateConsumable.PotionDeLampsur());
            Hero.AddLoot(CreateLoot.CreateFood.Ration());
            Hero.AddLoot(CreateLoot.CreateSpecialItem.Helmet());
            Hero.AddLoot(CreateLoot.CreateSpecialItem.Buckler());
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
                    MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("CantEat"));

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
                using (SqLiteDatabaseFunction databaseRequest = new SqLiteDatabaseFunction())
                {
                    databaseRequest.SaveHero((Hero)hero);
                }
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("SuccesSaving"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("ErrorSaving"));
                System.Diagnostics.Debug.WriteLine("Error saving Hero : " + ex);
            }
        }
        private void LoadHero(object random)
        {
            if (MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("ConfirmExit"), GlobalTranslator.Instance.Translator.ProvideValue("GoToLoadingMenu"), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
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
            _loadingHero = loading;
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
            NoNullInHero(hero);
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
            if (!_loadingHero)
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
        private void ResolveParagraph()
        {
            //First : the main event (that WILL happen, no choice, unless we're loading a Hero (so he already resolved the mains event))
            try
            {
                ResolveMainEvents(MyStory);
            }
            catch (YouAreDeadException)
            {
                HandleDeath(MyStory);
                return;
            }

            //Second, the decisions open to the player, as it is design code that should be generated, and it is not the ViewModel role, I generated an event that indicate the need to generate the actions buttons.
            //Our view should subscribe to this event and when it fires generate the actions button.
            //This way our MVVM pattern is respected
            ActionButtonHasChanged();
        }
        private void ResolveMainEvents(Story story)
        {
            if (!_loadingHero)
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
                _loadingHero = false;
        }
        public void ActionButtonHasChanged()
        {
            GenerateActionButton handler = ActionButtonChanged;
            handler?.Invoke(this, null);
        }
        public void HandleDeath(Story story)
        {
            MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("YouDied"));
            try
            {
                using (SqLiteDatabaseFunction databaseRequest = new SqLiteDatabaseFunction())
                {
                    SqLiteDatabaseFunction.DeleteHero(story.PlayerHero);
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

        private static void NoNullInHero(Hero hero)
        {
            //When loading a Hero from our database, if he had no item/backpack/weapon/weaponHolder/capacity then those will be null instead of empty, this is the default behavior of SQLite.
            //we fix the possible problem immediately
            hero.NoNullInHero();
        }

    }
}
