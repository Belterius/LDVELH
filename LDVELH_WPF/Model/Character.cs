using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDVELH_WPF
{
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("maxLife")]
        protected int maxHitPoint { get; set; }
        [Column("actualLife")]
        protected int actualHitPoint { get; set; }
        [Column("baseAgility")]
        protected int baseAgility { get; set; }
        public event HitPointHandler HitPointChanged;
        public delegate void HitPointHandler(Hero m, int damage);

        public string getName()
        {
            return name;
        }
        public int getMaxHitPoint()
        {
            return maxHitPoint;
        }
        public int getActualHitPoint()
        {
            return actualHitPoint;
        }
        public int getBaseAgility()
        {
            return baseAgility;
        }

        public void kill()
        {
            this.takeDamage(this.actualHitPoint);
        }

        public void takeDamage(int damage)
        {
            this.actualHitPoint -= damage;
            if (actualHitPoint <= 0)
            {
                actualHitPoint = 0;
                if (this is Hero)
                {
                    throw new YouAreDeadException("You are dead");
                }
            }

            if (this is Hero)
            {
                lifePointHasChanged((Hero)this, damage);
            }

        }

        public void lifePointHasChanged(Hero hero, int damage)
        {
            HitPointHandler handler = HitPointChanged;
            if (handler != null)
            {
                handler(hero, damage);
            }
        }

    }
}
