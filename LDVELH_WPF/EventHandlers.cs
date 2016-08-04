using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Data.Entity;

namespace LDVELH_WPF
{
    class EventHandlers
    {
    }

    class HeroObserver
    {
        Label labelHP;
        Label labelGold;
        Label labelAgility;
        Label labelWeaponMastery;
        Label labelBellyState;
        ListBox listBoxWeapon;
        private BindingList<Weapon> listWeaponSave;
        ListBox listBoxBackPackItem;
        private BindingList<Item> listItemSave;
        ListBox listBoxSpecialItem;
        private BindingList<SpecialItem> listSpecialItemSave;


        public HeroObserver(Hero hero, Label labelHP, Label labelAgility, Label labelWeaponMastery, Label labelGold, Label labelBellyState, ListBox listWeapon, ListBox listItem, ListBox listSpecialItem)
        {
            this.labelGold = labelGold;
            this.listBoxWeapon = listWeapon;
            this.listBoxBackPackItem = listItem;
            this.listBoxSpecialItem = listSpecialItem;
            this.labelHP = labelHP;
            this.labelAgility = labelAgility;
            this.labelWeaponMastery = labelWeaponMastery;
            this.labelBellyState = labelBellyState;

            listWeaponSave = new BindingList<Weapon>();
            listItemSave = new BindingList<Item>();
            listSpecialItemSave = new BindingList<SpecialItem>();


            listBoxSpecialItem.ItemsSource = this.listSpecialItemSave;
            listBoxSpecialItem.DisplayMemberPath = "getDisplayName";
            listBoxBackPackItem.ItemsSource = this.listItemSave;
            listBoxBackPackItem.DisplayMemberPath = "getDisplayName";
            listBoxWeapon.ItemsSource = this.listWeaponSave;
            listBoxWeapon.DisplayMemberPath = "getDisplayName";
        }

        public void HitPointChanged(Hero hero, int damage)
        {
            labelHP.Content = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
        }
        public void MaxHitPointChanged(Hero hero, int damage)
        {
            labelHP.Content = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
        }
        public void HungryStateChanged(Hero hero)
        {
            Translator translator = new Translator();
            labelBellyState.Content = translator.ProvideValue(hero.getHungryState.ToString());
        }
        public void AgilityChanged(Hero hero, int damage)
        {
            labelAgility.Content = hero.getBaseAgility().ToString();
        }
        public void WeaponMasteryChanged(Hero hero)
        {
            Translator translator = new Translator();
            labelWeaponMastery.Content = translator.ProvideValue(hero.getWeaponMastery.ToString());
        }

        public void GoldChanged(Hero hero, int goldChange)
        {
            labelGold.Content = hero.getGold().ToString();
        }

        public void capacitiesChanged(Hero hero, Capacity capacity)
        {
            System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he learned " + capacity.getCapacityType.ToString());

        }
        public void backPackChanged(Hero hero)
        {
            listItemSave = new BindingList<Item>(hero.backPack.getItems);
            listBoxBackPackItem.ItemsSource = listItemSave;
        }
        public void backPackChanged(Hero hero, Item item, bool add)
        {
            listItemSave = new BindingList<Item>(hero.backPack.getItems);
            listBoxBackPackItem.ItemsSource = listItemSave;
        }
        public void weaponHolderChanged(Hero hero)
        {
            listWeaponSave = new BindingList<Weapon>(hero.weaponHolder.getWeapons);
            listBoxWeapon.ItemsSource = listWeaponSave;
        }
        public void weaponHolderChanged(Hero hero, Weapon weapon, bool add)
        {
            listWeaponSave = new BindingList<Weapon>(hero.weaponHolder.getWeapons);
            listBoxWeapon.ItemsSource = listWeaponSave;
        }
        public void specialItemsChanged(Hero hero)
        {
            listSpecialItemSave = new BindingList<SpecialItem>(hero.getSpecialItems);
            listBoxSpecialItem.ItemsSource = listSpecialItemSave;
        }
        public void specialItemsChanged(Hero hero, SpecialItem specialItem, bool add)
        {
            listSpecialItemSave = new BindingList<SpecialItem>(hero.getSpecialItems);
            listBoxSpecialItem.ItemsSource = listSpecialItemSave;
        }
    }
    class StoryObserver
    {
        RichTextBox contentText;
        GroupBox groupBoxDecision;
        Story story;
        Window window;
        public bool loadingHero = false;

        public StoryObserver(Story story, RichTextBox contentText, GroupBox groupBoxDecision, Window window)
        {
            this.story = story;
            this.contentText = contentText;
            this.contentText.IsReadOnly = true;
            this.groupBoxDecision = groupBoxDecision;
            this.window = window;
        }
        public StoryObserver(Story story, RichTextBox contentText)
        {
            this.story = story;
            this.contentText = contentText;
        }

        public void ActualParagraphChanged(Story story, StoryParagraph actualParagraph)
        {
            //Several step :

            //First : the text content and change title
            setMainTextContent(actualParagraph);
            SetTitleParagraph(actualParagraph);

            //Second : the main event (that WILL happen, no choice, unless we're loading a Hero (so he already resolved the mains event))
            try
            {
                resolveMainEvents(story);
            }
            catch (YouAreDeadException)
            {
                handleDeath(story);
                return;
            }

            //Third, the decisions open to the player
            generatePlayerPossibleDecision(story);

            //Fourth, update the hero actualParagraph in case of exit
            story.getHero.setActualParagraph(actualParagraph.getParagraphNumber);

        }
        private void setMainTextContent(StoryParagraph actualParagraph)
        {
            contentText.Document.Blocks.Clear();
            contentText.Document.Blocks.Add(new Paragraph(new Run(actualParagraph.getContent)));
        }
        private void SetTitleParagraph(StoryParagraph actualParagraph)
        {
            window.Title = story.getHero.getName() + " : paraph n°" + actualParagraph.getParagraphNumber;
        }
        private void resolveMainEvents(Story story)
        {
            if (!this.loadingHero)
            {
                try
                {
                    story.resolveActualParagraph();
                }
                catch(YouAreDeadException)
                {
                    throw;
                }
                
            }
            else
                this.loadingHero = false;
        }
        private void generatePlayerPossibleDecision(Story story)
        {
            clearOldPossibleDecision();
            generateButtonPossibleDecision(story);
            placeButtonPossibleDecision(groupBoxDecision);
        }
        private void clearOldPossibleDecision()
        {
            ((Grid)(groupBoxDecision.Content)).Children.Clear();
        }
        private void generateButtonPossibleDecision(Story story)
        {
            foreach (Event possibleEvent in story.getActualParagraph.getListDecision)
            {
                if (ShouldGenerateButton(possibleEvent, story))
                {
                    Button buttonDecision = new Button();
                    buttonDecision.Content = possibleEvent.getTriggerMessage;
                    buttonDecision.Click += delegate {
                        try {
                            possibleEvent.resolveEvent(story);
                        }
                        catch (YouAreDeadException) {
                            handleDeath(story);
                        }
                    };
                    ((Grid)(groupBoxDecision.Content)).Children.Add(buttonDecision);
                    buttonDecision.HorizontalAlignment = HorizontalAlignment.Center;
                    buttonDecision.VerticalAlignment = VerticalAlignment.Center;
                }
            }
            window.UpdateLayout();
        }
        private bool ShouldGenerateButton(Event possibleEvent, Story story)
        {
            if (possibleEvent is CapacityEvent)
            {
                if (!story.getHero.possesCapacity(((CapacityEvent)possibleEvent).CapacityRequiered))
                {
                    return false;
                }
            }
            if (possibleEvent is ItemRequieredEvent)
            {
                if (!story.getHero.possesItem(((ItemRequieredEvent)possibleEvent).itemRequiered))
                {
                    return false;
                }
            }
            return true;
        }
        public double setXPosition(Button button, GroupBox groupBox)
        {
            double totalX = ((Grid)(groupBox.Content)).ActualWidth;
            double mySize = button.ActualWidth;
            return (totalX - mySize) / 2;
        }
        int marginBetweenButton = 6;
        public double calculateYPosition(double totalHeightButton, int numberButton, GroupBox groupBox)
        {
            double availableY = ((Grid)(groupBox.Content)).ActualHeight;

            return (availableY - totalHeightButton - marginBetweenButton * numberButton - 1)/2;
        }
        public double totalHeightButton(GroupBox groupBox)
        {
            double totalHeight = 0;
            foreach (Button button in ((Grid)(groupBoxDecision.Content)).Children)
            {
                totalHeight += button.ActualHeight;
            }
            return totalHeight;
        }
        public int totalNumberButton(GroupBox groupBox)
        {
            int totalNumberButton = 0;
            foreach (Button button in ((Grid)(groupBoxDecision.Content)).Children)
            {
                totalNumberButton++;
            }
            return totalNumberButton;
        }
        public void placeButtonPossibleDecision(GroupBox groupBox)
        {
            double topMargin = calculateYPosition(totalHeightButton(groupBox), totalNumberButton(groupBox), groupBox);
            double previousButtonY = topMargin - marginBetweenButton; //we don't need the margin for the first button
            double previousButtonHeight = 0;
            foreach (Button button in ((Grid)(groupBoxDecision.Content)).Children)
            {
                button.Margin = new Thickness(setXPosition(button, groupBox), previousButtonY, setXPosition(button, groupBox), (((Grid)(groupBox.Content)).ActualHeight - button.ActualHeight - previousButtonY));
                previousButtonHeight = button.ActualHeight;
                previousButtonY = (previousButtonY + previousButtonHeight + marginBetweenButton);
            }
        }
        private void handleDeath(Story story)
        {
            Translator translator = new Translator();
            MessageBox.Show(translator.ProvideValue("YouDied"));
                try
                {
                    Hero savedHero = SQLiteDatabaseFunction.SelectHeroFromID(story.getHero.CharacterID.ToString());
                    SQLiteDatabaseFunction.DeleteHero(savedHero);
                }catch(Exception ex){
                    System.Diagnostics.Debug.WriteLine("Error when deleting hero data : " + ex);
                }
            /* LEGACY CODE TO SAVE ON LOCALDB INSTEAD OF SQLite*/
            //using (HeroSaveContext heroSaveContext = new HeroSaveContext())
            //{
            //    heroSaveContext.MyItems.Load();
            //    heroSaveContext.MySpecialItem.Load();
            //    heroSaveContext.MyWeapons.Load();
            //    heroSaveContext.MyWeaponHolders.Load();
            //    heroSaveContext.MyBackPack.Load();
            //    heroSaveContext.MyHero.Load();
            //    heroSaveContext.MyCapacities.Load();
            //    Hero savedHero = heroSaveContext.MyHero.Where(x => x.CharacterID == story.getHero.CharacterID).FirstOrDefault();
            //    if (savedHero != null)
            //    {
            //        heroSaveContext.MySpecialItem.RemoveRange(savedHero.getSpecialItems);
            //        heroSaveContext.MyCapacities.RemoveRange(savedHero.capacities);
            //        heroSaveContext.MyHero.Remove(savedHero);
            //        heroSaveContext.SaveChanges();
            //    }
            //}
            MenuLoad loadMenu = new MenuLoad();
            loadMenu.Show();
            window.Close();
        }
    }
}
