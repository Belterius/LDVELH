using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public static class CreateLoot
    {
        public static class CreateConsummable
        {
            public static Consummable minorHealthPotion()
            {
                return new Consummable("minor health potion", 4, 3);
            }
        }
        public static class CreateFood
        {
            public static Food ration()
            {
                return new Food("ration", 4);
            }
        }
        public static class CreateMiscellaneous
        {

        }
        public static class CreateWeapon
        {
            public static Weapon sword(){
                return new Weapon("Sword", WeaponTypes.Sword);
            }
            public static Weapon spear()
            {
                return new Weapon("Spear", WeaponTypes.Spear);
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
        }
        
    }
}
