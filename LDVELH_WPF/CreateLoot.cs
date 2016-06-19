using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public static class CreateLoot
    {
        public static class CreateGold
        {
            public static Gold Gold(int amount)
            {
                return new Gold(amount);
            }
        }
        public static class CreateConsummable
        {
            public static Consummable minorHealthPotion()
            {
                return new Consummable("minor health potion", 4, 3);
            }
            public static Consummable potionDeGuerison()
            {
                return new Consummable("minor health potion", 4, 1);
            }
            public static Consummable potionDeLampsur(int healingPower = 3, int charges = 2)
            {
                return new Consummable("potion De Lampsur", healingPower, charges);
            }
        }
        public static class CreateFood
        {
            public static Food ration(int charges = 1)
            {
                return new Food("ration", charges);
            }
        }
        public static class CreateMiscellaneous
        {

        }
        public static class CreateWeapon
        {
            public static Weapon sword(){
                return new Weapon("Sword", WeaponTypes.Epee);
            }
            public static Weapon MarteauDeGuerre()
            {
                return new Weapon("MarteauDeGuerre", WeaponTypes.MarteauDeGuerre);
            }
            public static Weapon spear()
            {
                return new Weapon("Spear", WeaponTypes.Lance);
            }
            public static Weapon masseDArme()
            {
                return new Weapon("MasseDArmes", WeaponTypes.MasseDArmes);
            }
            public static Weapon Baton()
            {
                return new Weapon("Baton", WeaponTypes.Baton);
            }
            public static Weapon Lance()
            {
                return new Weapon("Lance", WeaponTypes.Lance);
            }
            public static Weapon Glaive()
            {
                return new Weapon("Glaive", WeaponTypes.Glaive);
            }
            public static Weapon Hache()
            {
                return new Weapon("Hache", WeaponTypes.Hache);
            }
            public static Weapon Poignard()
            {
                return new Weapon("Poignard", WeaponTypes.Poignard);
            }
        }
        public static class CreateSpecialItem
        {
            public static SpecialItem buckler()
            {
                return new SpecialItemCombat("Buckler", 2, 0);
            }
            public static SpecialItem chainMail()
            {
                return new SpecialItemAlways("ChainMail", 0, 4);
            }
            public static SpecialItem helmet()
            {
                return new SpecialItemAlways("ChainMail", 0, 2);
            }
        }
        
    }
}
