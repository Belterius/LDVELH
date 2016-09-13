using LDVELH_WPF.ViewModel;
using System;
using System.Windows;
using System.Windows.Data;

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
        MainWindowViewModel vm;
        bool loadingHero = false;

        public MainWindow(bool loading)
        {
            InitializeComponent();
            TranslateLabel();
            loadingHero = loading;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm = (MainWindowViewModel) DataContext;
            hero = vm.Hero;
            initStory();
            this.Title = hero.Name;
            if (!loadingHero)
                story.start();
            else
            {
                storyObserver.loadingHero = true;
                story.start(hero.CurrentParagraph);
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
            
        }
        private void initHero(Hero savedHero)
        {
            hero = savedHero;
        }
        private void initStory()
        {
            story = new Story("first adventure", hero);
            story.addParagraph(CreateParagraph.CreateAParagraph(hero.CurrentParagraph));

            initStoryObserver();

        }
        private void initStoryObserver()
        {
            storyObserver = new StoryObserver(story, richTextBoxMainContent, groupBoxChoices, this);
            story.ParagraphChanged += storyObserver.ActualParagraphChanged;
        }
    }
}
