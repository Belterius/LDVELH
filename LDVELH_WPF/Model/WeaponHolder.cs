using System;
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

        private readonly ObservableCollection<Weapon> _weapons;


        public WeaponHolder()
        {
            WeaponHolderSize = BasicWeaponHolderSize;
            _weapons = new ObservableCollection<Weapon>();
        }

        /// <summary>
        /// Create a Weapon Holder of a specified Size
        /// </summary>
        /// <param name="maxWeapon">The max number of Weapon the WeaponHolder can contain</param>
        public WeaponHolder(int maxWeapon)
        {
            WeaponHolderSize = maxWeapon;
            _weapons = new ObservableCollection<Weapon>();

        }

        public void Add(Weapon weapon)
        {
            if (_weapons.Count >= WeaponHolderSize)
            {
                throw new WeaponHolderFullException("Your weapon holder is full, throw a weapon to add a new one !");
            }
            else
            {
                _weapons.Add(weapon);
            }
        }
        public void Remove(Weapon weapon)
        {
            _weapons.Remove(weapon);
        }

        public bool Contains(WeaponTypes weaponType)
        {
            foreach (Weapon weapon in _weapons)
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
            if (_weapons.Count == 0)
                return true;
            else
                return false;
        }

        public ObservableCollection<Weapon> GetWeapons => _weapons;
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
