using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class WeaponHolder : List<Weapon>
    {
        private int basicWeaponHolderSize = 2;
        private int weaponHolderSize;

        public WeaponHolder()
        {
            this.weaponHolderSize = basicWeaponHolderSize;
        }

        public WeaponHolder(int maxWeapon)
        {
            this.weaponHolderSize = maxWeapon;
        }

        public new void Add(Weapon weapon)
        {
            if (this.Count >= this.weaponHolderSize)
            {
                throw new WeaponHolderFullException("Your weapon holder is full, throw a weapon to add a new one !");
            }
            else
            {
                base.Add(weapon);
            }
        }

        public bool Contains(WeaponTypes weaponType)
        {
            foreach (Weapon weapon in this)
            {
                if (weapon.getWeaponType == weaponType)
                {
                    return true;
                }
            }
            return false;
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
