using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    public class WeaponHolder
    {
        private int basicWeaponHolderSize = 2;

        [Key]
        public int WeaponHolderID { get; set; }
        [Column("WeaponHolderSize")]
        private int _WeaponHolderSize{get;set;}
        public int WeaponHolderSize
        {
            get
            {
                return _WeaponHolderSize;
            }
            private set
            {
                if (_WeaponHolderSize != value)
                {
                    _WeaponHolderSize = value;
                }
            }
        }
        //List<Weapon> weapons;
        ObservableCollection<Weapon> weapons;


        public WeaponHolder()
        {
            this.WeaponHolderSize = basicWeaponHolderSize;
            //weapons = new List<Weapon>();
            weapons = new ObservableCollection<Weapon>();
        }

        public WeaponHolder(int maxWeapon)
        {
            this.WeaponHolderSize = maxWeapon;
            //weapons = new List<Weapon>();
            weapons = new ObservableCollection<Weapon>();

        }

        public void Add(Weapon weapon)
        {
            if (this.weapons.Count >= this.WeaponHolderSize)
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
                if (weapon.WeaponType == weaponType)
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

        public ObservableCollection<Weapon> getWeapons
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
