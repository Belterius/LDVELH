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
using System.Data.Entity;

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
            using (HeroSaveContext heroContext = new HeroSaveContext())
            {
                //foreach(Weapon weapon in hero.weaponHolder.getWeapons)
                //{
                //    heroContext.MyWeapons.Add(weapon);
                //}
                //heroContext.SaveChanges();

                //heroContext.MyWeaponHolders.Add(hero.weaponHolder);

                //foreach (Item item in hero.backPack.getItems)
                //{
                //    heroContext.MyItems.Add(item);
                //}

                //heroContext.MyBackPack.Add(hero.backPack);

                //foreach (SpecialItem specialItem in hero.getSpecialItems)
                //{
                //    heroContext.MySpecialItem.Add(specialItem);
                //}

                heroContext.MyHero.Add(hero);

                heroContext.SaveChanges();
            }
            
        }

        private void buttonTestLoad_Click(object sender, RoutedEventArgs e)
        {
            using (HeroSaveContext heroContext = new HeroSaveContext())
            {
                heroContext.MyWeapons.Load();
                var query = from hero in heroContext.MyWeapons
                            select hero;
                List<Weapon> myHeroes = query.ToList();
                heroContext.MyWeaponHolders.Load();
                var queryWH = from hero in heroContext.MyWeaponHolders
                            select hero;
                List<WeaponHolder> myWH = queryWH.ToList();
                heroContext.MyItems.Load();
                var queryItems = from hero in heroContext.MyItems
                              select hero;
                List<Item> myItems = queryItems.ToList();
                heroContext.MyBackPack.Load();
                var queryBP = from hero in heroContext.MyBackPack
                                 select hero;
                List<BackPack> myBP = queryBP.ToList();
                heroContext.MySpecialItem.Load();
                var querySI = from hero in heroContext.MySpecialItem
                              select hero;
                List<SpecialItem> mySI = querySI.ToList();

                heroContext.MyHero.Load();
                var queryHero = from hero in heroContext.MyHero
                              select hero;
                List<Hero> myHero = queryHero.ToList();
            }
            //    heroContext.MyBackPacks.Load();
            //    heroContext.MyHeroes.Load();
            //    heroContext.MyWeaponHolders.Load();
            //    heroContext.MyWeapons.Load();
            //    heroContext.SpecialItems.Load();
            //    var query = from hero in heroContext.MyHeroes
            //                select hero;
            //    List<Hero> myHeroes = query.ToList();
            //    var query2 = from hero in heroContext.MyItems
            //                select hero;
            //    List<Item> myItems = query2.ToList();
            //}
        }
    }
}
