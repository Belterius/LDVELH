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
        public Capacity(CapacityType capacityType)

        {
            this.CapacityKind = capacityType;
        }

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

        public static String GetTranslation(this CapacityType capacity)
        {
            return GlobalTranslator.Instance.Translator.ProvideValue(capacity.ToString());
        }
    }
}
