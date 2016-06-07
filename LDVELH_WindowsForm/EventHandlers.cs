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
        ListBox listBoxWeapon;
        private BindingList<Weapon> listWeaponSave;
        ListBox listBoxBackPackItem;
        private BindingList<Item> listItemSave;
        ListBox listBoxSpecialItem;
        private BindingList<SpecialItem> listSpecialItemSave;

        public HeroObserver(Hero hero,Label labelHP, Label labelGold, ListBox listWeapon, ListBox listItem, ListBox listSpecialItem)
        {
            this.labelGold = labelGold;
            this.listBoxWeapon = listWeapon;
            this.listBoxBackPackItem = listItem;
            this.listBoxSpecialItem = listSpecialItem;
            this.labelHP = labelHP;

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
            System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he took " + damage + " damage");
            labelHP.Text = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
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
            if(add)
            {
                listItemSave.Add(item);
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he got " + item.getName );
            }
            else
            {
                listItemSave.Remove(item);
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + item.getName);
            }

        }
        public void weaponHolderChanged(Hero hero, Weapon weapon, bool add)
        {
            if (add)
            {
                listWeaponSave.Add(weapon);
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he got " + weapon.getName);
            }
            else
            {
                listWeaponSave.Remove(weapon);
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + weapon.getName);
            }
        }
        public void specialItemsChanged(Hero hero, SpecialItem specialItem, bool add)
        {
            
            if (add)
            {
                listSpecialItemSave.Add(specialItem);
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he got " + specialItem.getName);
            }
            else
            {
                listSpecialItemSave.Remove(specialItem);
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + specialItem.getName);
            }
        }
    }
}
