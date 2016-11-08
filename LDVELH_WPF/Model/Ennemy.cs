using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDVELH_WPF
{
    public class Enemy : Character
    {
        public static readonly List<EnemyTypes> EnemiesWeakToPhychic = new List<EnemyTypes> { EnemyTypes.Human, EnemyTypes.Beast };

        /// <summary>
        /// The Type of Enemy
        /// </summary>
        [Column("Type")]
        public EnemyTypes ClassType;

        /// <summary>
        /// Create an Enemy
        /// </summary>
        /// <param name="name">The Name of the Enemy</param>
        /// <param name="agility">The Agility of the Enemy</param>
        /// <param name="hitPoint">The Max Health Points of the Enemy</param>
        /// <param name="enemyType">The Type of the Enemy</param>
        public Enemy(String name, int agility, int hitPoint, EnemyTypes enemyType)
        {
            this.Name = name;
            this.BaseAgility = agility;
            this.ActualHitPoint = hitPoint;
            this.MaxHitPoint = hitPoint;
            this.ClassType = enemyType;
        }
        /// <summary>
        /// Return if an Enemy will be considered as weak against Phychic Power
        /// </summary>
        /// <returns>True if the Enemy is weak, false else</returns>
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
