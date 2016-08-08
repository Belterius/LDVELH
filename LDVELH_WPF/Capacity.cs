using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public class Capacity
    {
        [Key]
        public int CapacityID { get; set; }

        public static readonly int phychicPowerStrenght = 2;
        public static readonly int weaponMasteryStrenght = 2;

        [Column("Capacity")]
        private CapacityType capacity{get;set;}

        public Capacity()
        {
        }
        public Capacity(CapacityType capacityType)
        {
            this.capacity = capacityType;
        }

        public CapacityType getCapacityType{
            get { return capacity; }
        }

        public string getCapacityDisplayName
        {
            get {
                return GlobalTranslator.Instance.translator.ProvideValue(capacity.ToString());
            }
        }
        

    }

    public enum CapacityType
    {
        Hiding,
        WeaponMastery,
        PsychicPower,
        Hunting,
        SixthSense,
        Orientation,
        Healing,
        PsychicShield,
        BeastWhisperer,
        Telekinesis,

    }
    static class CapacityTypeMethods
    {

        public static String GetTranslation(this CapacityType capacity)
        {
            return GlobalTranslator.Instance.translator.ProvideValue(capacity.ToString());
        }
    }
}
