using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDVELH_WindowsForm
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


            listBoxSpecialItem.DataSource = this.listSpecialItemSave;
            listBoxSpecialItem.DisplayMember = "getDisplayName";
            listBoxBackPackItem.DataSource = this.listItemSave;
            listBoxBackPackItem.DisplayMember = "getDisplayName";
            listBoxWeapon.DataSource = this.listWeaponSave;
            listBoxWeapon.DisplayMember = "getDisplayName";
        }

        public void HitPointChanged(Hero hero, int damage)
        {
            labelHP.Text = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
        }
        public void MaxHitPointChanged(Hero hero, int damage)
        {
            labelHP.Text = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
        }
        public void AgilityChanged(Hero hero, int damage)
        {
            labelAgility.Text = hero.getBaseAgility().ToString();
        }

        public void GoldChanged(Hero hero, int goldChange)
        {
            if(goldChange > 0)
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he won " + goldChange + " gold");
            else
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + goldChange + " gold");
            labelGold.Text = hero.getGold().ToString();
        }

        public void capacitiesChanged(Hero hero, Capacity capacity)
        {
            System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he learned " + capacity.getCapacityType.ToString());

        }
        public void backPackChanged(Hero hero, Item item, bool add)
        {
            listItemSave = new BindingList<Item>(hero.backPack.getItems);
            listBoxBackPackItem.DataSource = listItemSave;

        }
        public void weaponHolderChanged(Hero hero, Weapon weapon, bool add)
        {
            listWeaponSave = new BindingList<Weapon>(hero.weaponHolder.getWeapons);
            listBoxWeapon.DataSource = listWeaponSave;
        }
        public void specialItemsChanged(Hero hero, SpecialItem specialItem, bool add)
        {
            listSpecialItemSave = new BindingList<SpecialItem>(hero.getSpecialItems);
            listBoxSpecialItem.DataSource = listSpecialItemSave;
        }
    }
    class StoryObserver
    {
        ListBox possibleDecision;
        RichTextBox contentText;
        GroupBox groupBoxDecision;
        Story story;

        public StoryObserver(Story story, RichTextBox contentText, GroupBox groupBoxDecision)
        {
            this.story = story;
            this.contentText = contentText;
            this.groupBoxDecision = groupBoxDecision;
        }
        public StoryObserver(Story story, RichTextBox contentText)
        {
            this.story = story;
            this.contentText = contentText;
        }

        public void ActualParagraphChanged(Story story, Paragraph actualParagraph)
        {
            //Several step :

            //First : the text content
            contentText.Text = actualParagraph.getContent;

            //Second : the main event (that WILL happen, no choice)
            story.resolveActualParagraph();

            //Third, the decisions open to the player
            //TODO

            groupBoxDecision.Controls.Clear();
            foreach(Event possibleEvent in story.getActualParagraph.getListDecision){
                Button buttonDecision = new Button();
                buttonDecision.Text = possibleEvent.getTriggerMessage;
                buttonDecision.Click += delegate { possibleEvent.resolveEvent(story); };
                groupBoxDecision.Controls.Add(buttonDecision);
                buttonDecision.Location = new Point(setXPosition(buttonDecision, groupBoxDecision), 0);
            }
            placeButton(groupBoxDecision);

        }

        public int setXPosition(Button button, GroupBox groupBox)
        {
            int totalX = groupBox.Width;
            int mySize = button.Width;
            return (totalX - mySize) / 2;
        }

        int marginBetweenButton = 6;
        public int calculateYPosition(int totalHeightButton, int numberButton, GroupBox groupBox)
        {
            int availableY = groupBox.Height;

            return (availableY - totalHeightButton - marginBetweenButton * numberButton - 1)/2;
        }
        public int totalHeightButton(GroupBox groupBox)
        {
            int totalHeight = 0;
            foreach (Button button in groupBox.Controls)
            {
                totalHeight += button.Height;
            }
            return totalHeight;
        }
        public int totalNumberButton(GroupBox groupBox)
        {
            int totalNumberButton = 0;
            foreach (Button button in groupBox.Controls)
            {
                totalNumberButton++;
            }
            return totalNumberButton;
        }
        public void placeButton(GroupBox groupBox)
        {
            int topMargin = calculateYPosition(totalHeightButton(groupBox), totalNumberButton(groupBox), groupBox);
            int previousButtonY = topMargin - marginBetweenButton; //we don't need the margin for the first button
            int previousButtonHeight = 0;
            foreach (Button button in groupBox.Controls)
            {
                button.Location = new Point(setXPosition(button, groupBox), (previousButtonY + previousButtonHeight + marginBetweenButton));
                previousButtonHeight = button.Height;
                previousButtonY = button.Location.Y;
            }
        }

    }
}
