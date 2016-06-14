using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public class Weapon : Loot
    {

        [Column]
        private string name{get;set;}
        [Column]
        private WeaponTypes weaponType;

        private Weapon()
        {

        }
        public Weapon(string name, WeaponTypes weaponType){
            this.name = name;
            this.weaponType = weaponType;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Weapon))
                return false;


            Weapon weapon = (Weapon)obj;
            if (this.name != weapon.name)
                return false;
            if (this.weaponType != weapon.weaponType)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { name, weaponType}.GetHashCode();
        }

        public WeaponTypes getWeaponType
        {
            get { return weaponType; }
        }

        public string getName
        {
            get { return name; }
        }

        public string getDisplayName
        {
            get { return name + "(" + weaponType.ToString() + ")"; }
        }
    }
    public enum WeaponTypes
    {
        Sword,
        Spear,
        Hammer,
        None
    }
}
