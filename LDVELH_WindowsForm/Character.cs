﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class Character
    {
        protected string name;
        protected int maxHitPoint;
        protected int actualHitPoint;
        protected int baseAgility;

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
                actualHitPoint = 0;
        }

    }
}
