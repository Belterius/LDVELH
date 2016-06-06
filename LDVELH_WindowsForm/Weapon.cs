﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class Weapon
    {
        string name;
        WeaponTypes weaponType;

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
    }
    public enum WeaponTypes
    {
        Sword,
        Spear,
        Hammer
    }
}