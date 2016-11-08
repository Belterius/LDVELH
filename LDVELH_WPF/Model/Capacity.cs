using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LDVELH_WPF
{
    public class Capacity : INotifyPropertyChanged
    {
        [Key]
        public int CapacityID { get; set; }

        public static readonly int PhychicPowerStrenght = 2;
        public static readonly int WeaponMasteryStrenght = 2;

        [Column("Capacity")]
        private CapacityType _CapacityKind{get;set;}
        /// <summary>
        /// The Type of the Capacity
        /// </summary>
        public CapacityType CapacityKind
        {
            get
            {
                return _CapacityKind;
            }
            private set
            {
                if (_CapacityKind != value)
                {
                    _CapacityKind = value;
                    RaisePropertyChanged("CapacityKind");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Capacity()
        {
        }
        /// <summary>
        /// Create a Capacity
        /// </summary>
        /// <param name="capacityType">The type of the Capacity</param>
        public Capacity(CapacityType capacityType)

        {
            this.CapacityKind = capacityType;
        }
        /// <summary>
        /// Compare 2 Capacities, return true if they have the same CapacityType
        /// </summary>
        /// <param name="obj">The Capacity to compare to</param>
        /// <returns>True if they are equals, false else</returns>
        public override bool Equals(object obj)
        {
            if(!(obj is Capacity))
            {
                return false;
            }
            if(this.CapacityKind != ((Capacity)obj).CapacityKind)
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.CapacityKind.GetHashCode();
            return hash;
        }
        public string DisplayName
        {
            get {
                return GlobalTranslator.Instance.Translator.ProvideValue(CapacityKind.ToString());
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
        /// <summary>
        /// Get the Name of the CapacityType in the adequate language
        /// </summary>
        /// <param name="capacity">The CapacityType</param>
        /// <returns>the Name of the CapacityType in the adequate language</returns>
        public static String GetTranslation(this CapacityType capacity)
        {
            return GlobalTranslator.Instance.Translator.ProvideValue(capacity.ToString());
        }
    }
}
