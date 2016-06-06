﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public abstract class Item
    {
        protected string name;
    }

    public class Consummable : Item
    {
        int healingPower;
        int chargesLeft;
        
        public Consummable(string name, int healingPower, int charges)
        {
            this.healingPower = healingPower;
            this.name = name;
            this.chargesLeft = chargesLeft;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Consummable))
                return false;


            Consummable consummable = (Consummable)obj;
            if (this.name != consummable.name)
                return false;
            if (this.chargesLeft != consummable.chargesLeft)
                return false;
            if (this.healingPower != consummable.healingPower)
                return false;

            return true;
        }

    }

    public class Food : Item
    {
        int chargesLeft;

        public Food(string name, int charges)
        {
            this.name = name;
            this.chargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Food))
                return false;

            Food food = (Food)obj;
            if (this.name != food.name)
                return false;
            if (this.chargesLeft != food.chargesLeft)
                return false;
            return true;
        }

    }
    
}
