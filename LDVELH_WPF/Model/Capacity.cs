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
        // ReSharper disable once InconsistentNaming : Requiered for Database
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
                if (_CapacityKind == value) return;
                _CapacityKind = value;
                RaisePropertyChanged("CapacityKind");
            }
        }

        private void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
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
            CapacityKind = capacityType;
        }
        /// <summary>
        /// Compare 2 Capacities, return true if they have the same CapacityType
        /// </summary>
        /// <param name="obj">The Capacity to compare to</param>
        /// <returns>True if they are equals, false else</returns>
        public override bool Equals(object obj)
        {
            return CapacityKind == (obj as Capacity)?.CapacityKind;
            
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + CapacityKind.GetHashCode();
            return hash;
        }
        public string DisplayName => GlobalTranslator.Instance.Translator.ProvideValue(CapacityKind.ToString());
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

    internal static class CapacityTypeMethods
    {
        /// <summary>
        /// Get the Name of the CapacityType in the adequate language
        /// </summary>
        /// <param name="capacity">The CapacityType</param>
        /// <returns>the Name of the CapacityType in the adequate language</returns>
        public static string GetTranslation(this CapacityType capacity)
        {
            return GlobalTranslator.Instance.Translator.ProvideValue(capacity.ToString());
        }
    }
}
