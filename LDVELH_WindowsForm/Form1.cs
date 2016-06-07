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
        Hero hero;
        HeroObserver heroObserver;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            initHero(ShowMyDialogBox());
            this.Text = hero.getName();
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
            hero.addSpecialItem(spItem);
            hero.addSpecialItem(spItem2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpecialItem spItem = new SpecialItemCombat("shield", 3, 0);
            SpecialItem spItem2 = new SpecialItemAlways(" heavy plate mail", 2, 4);
            hero.removeSpecialItem(spItem);
            hero.removeSpecialItem(spItem2);
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
            Item food = new Food("ration", 4);
            Item healthPotion = CreateConsummable.minorHealthPotion();
            Item cord = new Miscellaneous("cord");
            try
            {
                hero.addBackPackItem(food);
                hero.addBackPackItem(healthPotion);
                hero.addBackPackItem(cord);
            }
            catch (BackPackFullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Item food = new Food("ration", 4);
            Item healthPotion = CreateConsummable.minorHealthPotion();
            hero.removeBackPackItem(food);
            hero.removeBackPackItem(healthPotion);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Weapon sword = new Weapon("Sword", WeaponTypes.Sword);
                hero.addWeapon(sword);
            }
            catch (WeaponHolderFullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Weapon sword = new Weapon("Sword", WeaponTypes.Sword);
            hero.removeWeapon(sword);
        }

        private void buttonThrowBackPackItem_Click(object sender, EventArgs e)
        {
            hero.removeBackPackItem((Item)listBoxBackPack.SelectedItem);
        }

        private void buttonThrowWeapon_Click(object sender, EventArgs e)
        {
            hero.removeWeapon((Weapon)listBoxWeapon.SelectedItem);
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
