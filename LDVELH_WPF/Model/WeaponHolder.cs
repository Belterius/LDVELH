﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    public class WeaponHolder
    {
        [Key]
        public int WeaponHolderID { get; set; }
        [Column]
        private int weaponHolderSize{get;set;}
        List<Weapon> weapons;

        private int basicWeaponHolderSize = 2;

        public WeaponHolder()
        {
            this.weaponHolderSize = basicWeaponHolderSize;
            weapons = new List<Weapon>();
        }

        public WeaponHolder(int maxWeapon)
        {
            this.weaponHolderSize = maxWeapon;
            weapons = new List<Weapon>();

        }

        public void Add(Weapon weapon)
        {
            if (this.weapons.Count >= this.weaponHolderSize)
            {
                throw new WeaponHolderFullException("Your weapon holder is full, throw a weapon to add a new one !");
            }
            else
            {
                this.weapons.Add(weapon);
            }
        }
        public void Remove(Weapon weapon)
        {
            this.weapons.Remove(weapon);
        }

        public bool Contains(WeaponTypes weaponType)
        {
            foreach (Weapon weapon in this.weapons)
            {
                if (weapon.getWeaponType == weaponType)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isEmpty()
        {
            if (this.weapons.Count == 0)
                return true;
            else
                return false;
        }

        public List<Weapon> getWeapons
        {
            get { return weapons;}
        }

    }

    [Serializable]
    public class WeaponHolderFullException : Exception
    {
        public WeaponHolderFullException()
        { }

        public WeaponHolderFullException(string message)
            : base(message)
        { }

        public WeaponHolderFullException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected WeaponHolderFullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }

}