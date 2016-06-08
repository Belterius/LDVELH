using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDVELH_WindowsForm
{
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }
        [Column("name")]
        protected string name;
        [Column("maxLife")]
        protected int maxHitPoint;
        [Column("actualLife")]
        protected int actualHitPoint;
        [Column("baseAgility")]
        protected int baseAgility;
        public event HitPointHandler HitPointChanged;
        public delegate void HitPointHandler(Hero m, int damage);

        public string getName(){
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
            this.actualHitPoint = 0;
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

        public void lifePointHasChanged(Hero hero, int damage){
            HitPointHandler handler = HitPointChanged;
            if (handler != null)
            {
                handler(hero, damage);
            }
        }

    }
}
