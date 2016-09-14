using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDVELH_WPF
{
    public class Enemy : Character
    {
        public static readonly List<EnnemyTypes> EnemiesWeakToPhychic = new List<EnnemyTypes> { EnnemyTypes.Human, EnnemyTypes.Beast };


        [Column("Type")]
        public EnnemyTypes ClassType;

        public Enemy(String name, int agility, int hitPoint, EnnemyTypes ennemyType)
        {
            this.Name = name;
            this.BaseAgility = agility;
            this.ActualHitPoint = hitPoint;
            this.MaxHitPoint = hitPoint;
            this.ClassType = ennemyType;
        }

        public bool IsWeakToPhychic()
        {
            if (EnemiesWeakToPhychic.Contains(ClassType))
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
