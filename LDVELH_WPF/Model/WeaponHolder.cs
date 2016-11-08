using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    /// <summary>
    /// A Weapon Holder can only contain Weapons, and only as much as it's WeaponHolderSize
    /// </summary>
    public class WeaponHolder
    {
        private int BasicWeaponHolderSize = 2;

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
        ObservableCollection<Weapon> Weapons;


        public WeaponHolder()
        {
            this.WeaponHolderSize = BasicWeaponHolderSize;
            Weapons = new ObservableCollection<Weapon>();
        }

        /// <summary>
        /// Create a Weapon Holder of a specified Size
        /// </summary>
        /// <param name="maxWeapon">The max number of Weapon the WeaponHolder can contain</param>
        public WeaponHolder(int maxWeapon)
        {
            this.WeaponHolderSize = maxWeapon;
            Weapons = new ObservableCollection<Weapon>();

        }

        public void Add(Weapon weapon)
        {
            if (this.Weapons.Count >= this.WeaponHolderSize)
            {
                throw new WeaponHolderFullException("Your weapon holder is full, throw a weapon to add a new one !");
            }
            else
            {
                this.Weapons.Add(weapon);
            }
        }
        public void Remove(Weapon weapon)
        {
            this.Weapons.Remove(weapon);
        }

        public bool Contains(WeaponTypes weaponType)
        {
            foreach (Weapon weapon in this.Weapons)
            {
                if (weapon.WeaponType == weaponType)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (this.Weapons.Count == 0)
                return true;
            else
                return false;
        }

        public ObservableCollection<Weapon> GetWeapons
        {
            get { return Weapons;}
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
