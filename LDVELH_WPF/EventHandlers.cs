using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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

            listWeaponSave =  new BindingList<Weapon>(hero.weaponHolder.getWeapons);
            listItemSave = new BindingList<Item>(hero.backPack.GetItems);
            listSpecialItemSave = new BindingList<SpecialItem>(hero.getSpecialItems);

            listBoxSpecialItem.ItemsSource = this.listSpecialItemSave;
            listBoxSpecialItem.DisplayMemberPath = "getDisplayName";
            listBoxBackPackItem.ItemsSource = this.listItemSave;
            listBoxBackPackItem.DisplayMemberPath = "getDisplayName";
            listBoxWeapon.ItemsSource = this.listWeaponSave;
            listBoxWeapon.DisplayMemberPath = "getDisplayName";
        }

        public void HitPointChanged(Hero hero, int damage)
        {
            labelHP.Content = hero.ActualHitPoint.ToString() + "/" + hero.MaxHitPoint.ToString();
        }
        public void MaxHitPointChanged(Hero hero, int damage)
        {
            labelHP.Content = hero.ActualHitPoint.ToString() + "/" + hero.MaxHitPoint.ToString();
        }
        public void HungryStateChanged(Hero hero)
        {
            labelBellyState.Content = GlobalTranslator.Instance.translator.ProvideValue(hero.getHungryState.ToString());
        }
        public void AgilityChanged(Hero hero, int damage)
        {
            labelAgility.Content = hero.BaseAgility.ToString();
        }
        public void WeaponMasteryChanged(Hero hero)
        {
            labelWeaponMastery.Content = GlobalTranslator.Instance.translator.ProvideValue(hero.getWeaponMastery.ToString());
        }

        public void GoldChanged(Hero hero, int goldChange)
        {
            labelGold.Content = hero.getGold().ToString();
        }

        public void capacitiesChanged(Hero hero, Capacity capacity)
        {
            System.Diagnostics.Debug.WriteLine("Something happened to " + hero.Name+ " he learned " + capacity.getCapacityType.ToString());
        }
        public void backPackChanged(Hero hero)
        {
            listBoxBackPackItem.Items.Refresh();
        }
        public void backPackChanged(Hero hero, Item item, bool add)
        {
            listBoxBackPackItem.Items.Refresh();
        }
        public void weaponHolderChanged(Hero hero)
        {
            listBoxWeapon.Items.Refresh();
        }
        public void weaponHolderChanged(Hero hero, Weapon weapon, bool add)
        {
            listBoxWeapon.Items.Refresh();
        }
        public void specialItemsChanged(Hero hero)
        {
            listBoxSpecialItem.Items.Refresh();
        }
        public void specialItemsChanged(Hero hero, SpecialItem specialItem, bool add)
        {
            listBoxSpecialItem.Items.Refresh();
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
            window.Title = story.getHero.Name+ " : paraph n°" + actualParagraph.getParagraphNumber;
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
            MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("YouDied"));
            try
            {
                using (SQLiteDatabaseFunction databaseRequest = new SQLiteDatabaseFunction())
                {
                    databaseRequest.DeleteHero(story.getHero);
                }
                
            }catch(Exception ex){
                System.Diagnostics.Debug.WriteLine("Error when deleting hero data : " + ex);
            }
            MenuLoad loadMenu = new MenuLoad();
            loadMenu.Show();
            window.Close();
        }
    }
}
