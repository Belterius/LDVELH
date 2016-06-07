using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDVELH_WindowsForm
{
    public partial class Form1 : Form
    {
        Story story;
        StoryObserver storyObserver;
        Hero hero;
        HeroObserver heroObserver;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            initHero(ShowMyDialogBox());
            initStory();
            this.Text = hero.getName();
            story.start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
            heroObserver = new HeroObserver(hero, labelHitPoint,labelAgility, labelGoldAmount, listBoxWeapon, listBoxBackPack, listBoxSpecialItem);

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
            labelHitPoint.Text = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
            labelAgility.Text = hero.getBaseAgility().ToString();
            labelGoldAmount.Text = hero.getGold().ToString();
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
            storyObserver = new StoryObserver(story, richTextBoxMainContent);
            story.ParagraphChanged += storyObserver.ActualParagraphChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hero.takeDamage(2);
            }
            catch (YouAreDeadException)
            {
                MessageBox.Show("You died !");
                initHero(hero.getName());
                
            }
        }
        public string ShowMyDialogBox()
        {
            MessageBoxInput testDialog = new MessageBoxInput();

            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (testDialog.getCharacterName != "")
                {
                    testDialog.Dispose();
                    return testDialog.getCharacterName;
                }
                else
                {
                    testDialog.Dispose();
                    return "NoName";
                }
                    
            }
            else
            {
                testDialog.Dispose();
                return "NoName";
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            hero.addGold(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hero.removeGold(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SpecialItem spItem = new SpecialItemCombat("light shield", 3, 0);
            SpecialItem spItem2 = new SpecialItemAlways(" heavy plate mail", 2, 4);
            hero.addLoot(spItem);
            hero.addLoot(spItem2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpecialItem spItem = new SpecialItemCombat("shield", 3, 0);
            SpecialItem spItem2 = new SpecialItemAlways(" heavy plate mail", 2, 4);
            hero.removeLoot(spItem);
            hero.removeLoot(spItem2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hero.heal(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                hero.takeDamage(2);
            }
            catch (YouAreDeadException)
            {
                MessageBox.Show("You died !");
                initHero(hero.getName());

            }
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            Loot food = new Food("ration", 4);
            Loot healthPotion = CreateLoot.CreateConsummable.minorHealthPotion();
            Loot cord = new Miscellaneous("cord");
            try
            {
                hero.addLoot(food);
                hero.addLoot(healthPotion);
                hero.addLoot(cord);
            }
            catch (BackPackFullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Item food = new Food("ration", 4);
            Item healthPotion = CreateLoot.CreateConsummable.minorHealthPotion();
            hero.removeLoot(food);
            hero.removeLoot(healthPotion);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Weapon sword = new Weapon("Sword", WeaponTypes.Sword);
                hero.addLoot(sword);
            }
            catch (WeaponHolderFullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Weapon sword = new Weapon("Sword", WeaponTypes.Sword);
            hero.removeLoot(sword);
        }

        private void buttonThrowBackPackItem_Click(object sender, EventArgs e)
        {
            hero.removeLoot((Item)listBoxBackPack.SelectedItem);
        }

        private void buttonThrowWeapon_Click(object sender, EventArgs e)
        {
            hero.removeLoot((Weapon)listBoxWeapon.SelectedItem);
        }

        private void buttonUseItem_Click(object sender, EventArgs e)
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

    }
}
