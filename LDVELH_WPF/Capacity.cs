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

        public const int phychicPowerStrenght = 2;
        public const int weaponMasteryStrenght = 2;

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
        

    }

    public enum CapacityType
    {
        Camouflage,
        MaitriseDesArmes,
        PuissancePsychique,
        Chasse,
        SixiemeSens,
        Orientation,
        Guerison,
        BouclierPsychique,
        CommunicationAnimale,
        MaitriseDeLaMatiere,

    }
}
