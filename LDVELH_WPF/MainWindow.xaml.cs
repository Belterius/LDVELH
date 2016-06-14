using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        HeroContext heroContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            initHero(ShowMyDialogBox());
            initStory();
            this.Title = hero.getName();
            story.start();
        }
        private void initHero(String name)
        {
            heroContext = new HeroContext();
            hero = new Hero(name);
            heroCharacterObserver();
            heroBaseStat();
            heroListeners();

        }
        private void heroCharacterObserver()
        {
            heroObserver = new HeroObserver(hero, labelHitPoint, labelAgility, labelGoldAmount, listBoxWeapons, listBoxBackPack, listBoxSpecialItems);

        }
        private void heroListeners()
        {
            heroHPListener();
            heroMaxLifeListener();
            heroAgilityListener();
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
            story.addParagraph(CreateParagraph.CreateAParagraph(1));
            story.addParagraph(CreateParagraph.CreateAParagraph(2));
            story.addParagraph(CreateParagraph.CreateAParagraph(3));
            story.addParagraph(CreateParagraph.CreateAParagraph(4));

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
                    return "NoName";
                }

            }
            else
            {
                return "NoName";
            }

        }

        private void buttonThrowWeapon_Click(object sender, RoutedEventArgs e)
        {
            hero.removeLoot((Weapon)listBoxWeapons.SelectedItem);
        }

        private void buttonUseItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hero.useItem((Item)listBoxBackPack.SelectedItem);
            }
            catch (CannotUseItemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonThrowItem_Click(object sender, RoutedEventArgs e)
        {
            hero.removeLoot((Item)listBoxBackPack.SelectedItem);
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            heroContext.MyHeroes.Add(hero);
            heroContext.SaveChanges();
        }
    }
}
