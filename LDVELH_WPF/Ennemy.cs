using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public class Ennemy : Character
    {
        public static readonly List<EnnemyTypes> ennemiesWeakToPhychic = new List<EnnemyTypes> { EnnemyTypes.Human, EnnemyTypes.Beast };


        [Column("Type")]
        public EnnemyTypes ClassType;

        public Ennemy(String name, int agility, int hitPoint, EnnemyTypes ennemyType)
        {
            this.name = name;
            this.baseAgility = agility;
            this.actualHitPoint = hitPoint;
            this.maxHitPoint = hitPoint;
            this.ClassType = ennemyType;
        }

        public bool isWeakToPhychic()
        {
            if (ennemiesWeakToPhychic.Contains(ClassType))
            {
                return true;
            }
            return false;
        }
    }

    public enum EnnemyTypes
    {
        Human,
        Beast,
        Orc,
        Hero
    }

}
