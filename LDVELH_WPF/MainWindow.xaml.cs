using System;
using System.Windows;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Story story;
        StoryObserver storyObserver;
        Hero hero;
        HeroObserver heroObserver;
        bool loadingHero = false;

        public MainWindow()
        {
            InitializeComponent();
            TranslateLabel();
            initHero(ShowMyDialogBox());
        }
        public MainWindow(Hero savedHero)
        {
            InitializeComponent();
            TranslateLabel();
            loadingHero = true;
            initHero(savedHero);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            initStory();
            this.Title = hero.getName();
            if (!loadingHero)
                story.start();
            else
            {
                storyObserver.loadingHero = true;
                story.start(hero.getActualParagraph());
            }
        }
        private void TranslateLabel()
        {
            groupBoxHeroStat.Header = GlobalTranslator.Instance.translator.ProvideValue("HeroStats");
            labelDescriptionHitPoint.Content = GlobalTranslator.Instance.translator.ProvideValue("HitPoints");
            labelDescriptionAgility.Content = GlobalTranslator.Instance.translator.ProvideValue("Agility");
            LabelWeaponMastery.Content = GlobalTranslator.Instance.translator.ProvideValue("WeaponMasteryLabel");
            LabelCapacities.Content = GlobalTranslator.Instance.translator.ProvideValue("CapacitiesLabel");
            LabelHunger.Content = GlobalTranslator.Instance.translator.ProvideValue("Hunger");
            labelHungryState.Content = GlobalTranslator.Instance.translator.ProvideValue("Hungry");
            groupBoxInventory.Header = GlobalTranslator.Instance.translator.ProvideValue("Inventory");
            LabelBackPack.Content = GlobalTranslator.Instance.translator.ProvideValue("BackPack");
            LabelSpecialItems.Content = GlobalTranslator.Instance.translator.ProvideValue("SpecialItems");
            LabelWeapons.Content = GlobalTranslator.Instance.translator.ProvideValue("Weapon");
            labelDescriptionGold.Content = GlobalTranslator.Instance.translator.ProvideValue("LabelGold");
            buttonThrowItem.Content = GlobalTranslator.Instance.translator.ProvideValue("ThrowItem");
            buttonUseItem.Content = GlobalTranslator.Instance.translator.ProvideValue("UseItem");
            buttonThrowWeapon.Content = GlobalTranslator.Instance.translator.ProvideValue("ThrowWeapon");
            groupBoxChoices.Header = GlobalTranslator.Instance.translator.ProvideValue("Choices");
            buttonSave.Content = GlobalTranslator.Instance.translator.ProvideValue("Save");
            buttonLoad.Content = GlobalTranslator.Instance.translator.ProvideValue("Load");
        }
        private void initHero(String name)
        {
            
            hero = new Hero(name);
            heroChoseCapacities();
            heroCharacterObserver();
            heroBaseStat();
            heroListeners();

        }
        private void heroChoseCapacities()
        {
            MenuCapacities menuCapacities = new MenuCapacities(this.hero, this);
            menuCapacities.Show();
            this.Hide();
        }
        private void initHero(Hero savedHero)
        {
            hero = savedHero;
            noNullInHero(); //secure our hero identity
            heroCharacterObserver();
            heroBaseStat();
            heroListeners();
            heroSavedItems();
        }
        private void noNullInHero()
        {
            //When loading a Hero from our database, if he had no item/backpack/weapon/weaponHolder/capacity then those will be null instead of empty.
            //we fix the possible problem immediately
            hero.noNullInHero();
        }
        private void heroSavedItems()
        {
            heroObserver.weaponHolderChanged(hero);
            heroObserver.specialItemsChanged(hero);
            heroObserver.backPackChanged(hero);
        }
        private void heroCharacterObserver()
        {
            heroObserver = new HeroObserver(hero, labelHitPoint, labelAgility, labelWeaponMastery, labelGoldAmount, labelHungryState, listBoxWeapons, listBoxBackPack, listBoxSpecialItems);

        }
        private void heroListeners()
        {
            heroHPListener();
            heroMaxLifeListener();
            heroAgilityListener();
            heroHungryStateListener();  
            heroWeaponMasteryListener();
            heroGoldListener();
            heroSpecialItemListener();
            heroBackPackItemListener();
            heroWeaponHolderListener();
        }
        private void heroBaseStat()
        {
            labelHitPoint.Content = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
            labelAgility.Content = hero.getBaseAgility().ToString();
            labelGoldAmount.Content = hero.getGold().ToString();
            labelWeaponMastery.Content = GlobalTranslator.Instance.translator.ProvideValue(hero.getWeaponMastery.ToString());
            listBoxCapacities.ItemsSource = hero.capacities;
            listBoxCapacities.DisplayMemberPath = "getCapacityDisplayName";
            labelHungryState.Content = GlobalTranslator.Instance.translator.ProvideValue(hero.getHungryState.ToString());
        }
        private void heroHPListener()
        {
            hero.HitPointChanged += heroObserver.HitPointChanged;
        }
        private void heroMaxLifeListener()
        {
            hero.MaxLifeChanged += heroObserver.MaxHitPointChanged;
        }
        private void heroAgilityListener()
        {
            hero.AgilityChanged += heroObserver.AgilityChanged;
        }
        private void heroHungryStateListener()
        {
            hero.hungryStateChanged += heroObserver.HungryStateChanged;
        }
        private void heroWeaponMasteryListener()
        {
            hero.weaponMasteryChanged += heroObserver.WeaponMasteryChanged;
        }
        private void heroGoldListener()
        {
            hero.GoldChanged += heroObserver.GoldChanged;
        }
        private void heroSpecialItemListener()
        {
            hero.specialItemsChanged += heroObserver.specialItemsChanged;
        }
        private void heroBackPackItemListener()
        {
            hero.backPackChanged += heroObserver.backPackChanged;
        }
        private void heroWeaponHolderListener()
        {
            hero.weaponHolderChanged += heroObserver.weaponHolderChanged;
        }
        private void initStory()
        {
            story = new Story("first adventure", hero);
            story.addParagraph(CreateParagraph.CreateAParagraph(hero.getActualParagraph()));

            initStoryObserver();

        }
        private void initStoryObserver()
        {
            storyObserver = new StoryObserver(story, richTextBoxMainContent, groupBoxChoices, this);
            story.ParagraphChanged += storyObserver.ActualParagraphChanged;
        }
        public string ShowMyDialogBox()
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

        private void buttonThrowWeapon_Click(object sender, RoutedEventArgs e)
        {
            Weapon weaponToThrow = (Weapon)listBoxWeapons.SelectedItem;
            if (weaponToThrow != null)
            {
                hero.removeLoot(weaponToThrow);
            }
        }

        private void buttonUseItem_Click(object sender, RoutedEventArgs e)
        {
            Item itemToUse = (Item)listBoxBackPack.SelectedItem;
            if (itemToUse != null)
            {
                try
                {
                    hero.useItem(itemToUse);
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

        private void buttonThrowItem_Click(object sender, RoutedEventArgs e)
        {
            Item itemToThrow = (Item)listBoxBackPack.SelectedItem;
            if (itemToThrow != null)
            {
                hero.removeLoot(itemToThrow);
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    databaseRequest.SaveHero(hero);
                }
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("SuccesSaving"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorSaving"));
                System.Diagnostics.Debug.WriteLine("Error saving Hero : " + ex);
            }
        }

        private void buttonTestLoad_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ConfirmExit"), GlobalTranslator.Instance.translator.ProvideValue("GoToLoadingMenu"), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                
            }
            else
            {
                MenuLoad loadMenu = new MenuLoad();
                loadMenu.Show();
                this.Close();
            }
        }
    }
}
