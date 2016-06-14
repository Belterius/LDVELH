using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public class Capacity
    {
        [Key]
        public int CapacityID { get; set; }

        public const int phychicPowerStrenght = 2;
        public const int weaponMasteryStrenght = 2;

        private CapacityType capacity;

        public Capacity(CapacityType capacityType)
        {
            this.capacity = capacityType;
        }

        public CapacityType getCapacityType{
            get { return capacity; }
        }

    }

    public enum CapacityType
    {
        Hiding,
        WeaponMastery,
        PsychicPower,
    }
}
