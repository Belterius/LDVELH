using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDVELH_WPF
{
    public class Enemy : Character
    {
        public static readonly List<EnemyTypes> EnemiesWeakToPhychic = new List<EnemyTypes> { EnemyTypes.Human, EnemyTypes.Beast };


        [Column("Type")]
        public EnemyTypes ClassType;

        public Enemy(String name, int agility, int hitPoint, EnemyTypes enemyType)
        {
            this.Name = name;
            this.BaseAgility = agility;
            this.ActualHitPoint = hitPoint;
            this.MaxHitPoint = hitPoint;
            this.ClassType = enemyType;
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

    public enum EnemyTypes
    {
        Human,
        Beast,
        Orc,
        Hero
    }

}
