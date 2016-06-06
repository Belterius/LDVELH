using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class Capacity
    {
        private CapacityType capacity;

        public Capacity(CapacityType capacityType)
        {
            this.capacity = capacityType;
        }

        public CapacityType GetCapacityType(){
            return capacity;
        }
    }

    public enum CapacityType
    {
        Hiding,
        WeaponMastery,
        PsychicPower
    }
}
