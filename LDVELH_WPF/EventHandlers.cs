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
        ListBox listBoxWeapon;
        private BindingList<Weapon> listWeaponSave;
        ListBox listBoxBackPackItem;
        private BindingList<Item> listItemSave;
        ListBox listBoxSpecialItem;
        private BindingList<SpecialItem> listSpecialItemSave;

        public HeroObserver(Hero hero,Label labelHP,Label labelAgility, Label labelGold, ListBox listWeapon, ListBox listItem, ListBox listSpecialItem)
        {
            this.labelGold = labelGold;
            this.listBoxWeapon = listWeapon;
            this.listBoxBackPackItem = listItem;
            this.listBoxSpecialItem = listSpecialItem;
            this.labelHP = labelHP;
            this.labelAgility = labelAgility;

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
        public void AgilityChanged(Hero hero, int damage)
        {
            labelAgility.Content = hero.getBaseAgility().ToString();
        }

        public void GoldChanged(Hero hero, int goldChange)
        {
            if(goldChange > 0)
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he won " + goldChange + " gold");
            else
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + goldChange + " gold");
            labelGold.Content = hero.getGold().ToString();
        }

        public void capacitiesChanged(Hero hero, Capacity capacity)
        {
            System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he learned " + capacity.getCapacityType.ToString());

        }
        public void backPackChanged(Hero hero, Item item, bool add)
        {
            listItemSave = new BindingList<Item>(hero.backPack.getItems);
            listBoxBackPackItem.ItemsSource = listItemSave;

        }
        public void weaponHolderChanged(Hero hero, Weapon weapon, bool add)
        {
            listWeaponSave = new BindingList<Weapon>(hero.weaponHolder.getWeapons);
            listBoxWeapon.ItemsSource = listWeaponSave;
        }
        public void specialItemsChanged(Hero hero, SpecialItem specialItem, bool add)
        {
            listSpecialItemSave = new BindingList<SpecialItem>(hero.getSpecialItems);
            listBoxSpecialItem.ItemsSource = listSpecialItemSave;
        }
    }
    class StoryObserver
    {
        ListBox possibleDecision;
        RichTextBox contentText;
        GroupBox groupBoxDecision;
        Story story;
        Window window;

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

            //First : the text content
            contentText.Document.Blocks.Clear();
            contentText.Document.Blocks.Add(new Paragraph(new Run(actualParagraph.getContent)));
            //Second : the main event (that WILL happen, no choice)
            story.resolveActualParagraph();

            //Third, the decisions open to the player
            ((Grid)(groupBoxDecision.Content)).Children.Clear();
            foreach(Event possibleEvent in story.getActualParagraph.getListDecision){
                Button buttonDecision = new Button();
                buttonDecision.Content = possibleEvent.getTriggerMessage;
                buttonDecision.Click += delegate { possibleEvent.resolveEvent(story); };
                ((Grid)(groupBoxDecision.Content)).Children.Add(buttonDecision);
                buttonDecision.HorizontalAlignment = HorizontalAlignment.Center;
                buttonDecision.VerticalAlignment = VerticalAlignment.Center;
            }
            window.UpdateLayout();
            placeButton(groupBoxDecision);

            //Fourth, update the hero actualParagraph in case of exit
            story.getHero.setActualParagraph(actualParagraph.ParagraphID);

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
        public void placeButton(GroupBox groupBox)
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

    }
}
