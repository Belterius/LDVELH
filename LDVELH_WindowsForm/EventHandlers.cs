using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDVELH_WindowsForm
{
    class EventHandlers
    {
    }

    class CharacterObserver
    {
        Label labelHP;

        public CharacterObserver(Label label)
        {
            labelHP = label;
        }

        public void HitPointChanged(Hero hero, int damage)
        {
            System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he took " + damage + " damage");
            labelHP.Text = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
        }
    }

    class HeroObserver
    {
        Label labelGold;
        ListBox listWeapon;
        ListBox listItem;
        ListBox listSpecialItem;

        public HeroObserver(Label labelGold, ListBox listWeapon, ListBox listItem, ListBox listSpecialItem)
        {
            this.labelGold = labelGold;
            this.listWeapon = listWeapon;
            this.listItem = listItem;
            this.listSpecialItem = listSpecialItem;
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
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he got " + item.getName );
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + item.getName);
            }

        }
        public void weaponHolderChanged(Hero hero, Weapon weapon, bool add)
        {
            if (add)
            {
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he got " + weapon.getName);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + weapon.getName);
            }
        }
        public void specialItemsChanged(Hero hero, SpecialItem specialItem, bool add)
        {
            if (add)
            {
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he got " + specialItem.getName);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Something happened to " + hero.getName() + " he lost " + specialItem.getName);
            }
        }
    }
}
