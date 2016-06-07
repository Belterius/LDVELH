using System;
using System.Collections.Generic;
using System.ComponentModel;
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
}
