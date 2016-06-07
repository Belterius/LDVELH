using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public abstract class SpecialItem : Loot
    {
        protected string name;

        public string getName
        {
            get { return name; }
        }

        public virtual string getDisplayName
        {
            get { return name; }
        }
    }

    public class SpecialItemCombat : SpecialItem
    {
        //Has an effect during combat (Example : +2 agility shield)
        int agilityBonus;
        int hitPointBonus;

        public override string getDisplayName
        {
            get
            {
                if (agilityBonus > 0 && hitPointBonus > 0)
                {
                    return name + " (+" + agilityBonus + " agi" + " +" + hitPointBonus +" life during battle)";
                }
                if (agilityBonus > 0 )
                {
                    return name + " (+" + agilityBonus + " agi during battle)";
                }
                if (hitPointBonus > 0)
                {
                    return name + " (+" + hitPointBonus + " life during battle)";
                }
                return name;
            }
        }

        public SpecialItemCombat(String name, int agilityBonus, int hitPointBonus)
        {
            this.agilityBonus = agilityBonus;
            this.hitPointBonus = hitPointBonus;
            this.name = name;
        }

        public int getAgilityBonus
        {
            get { return agilityBonus; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpecialItemCombat))
                return false;


            SpecialItemCombat specialItemCombat = (SpecialItemCombat)obj;
            if (this.name != specialItemCombat.name)
                return false;
            if (this.agilityBonus != specialItemCombat.agilityBonus)
                return false;
            if (this.hitPointBonus != specialItemCombat.hitPointBonus)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { name, agilityBonus, hitPointBonus }.GetHashCode();
        }

        
    }

    public class SpecialItemAlways : SpecialItem
    {
        //Has a permanent effect (Example : +4 HitPoint chain mail)
        int agilityBonus;
        int LifePointBonus;

        public SpecialItemAlways(String name, int agilityBonus, int hitPointBonus)
        {
            this.agilityBonus = agilityBonus;
            this.LifePointBonus = hitPointBonus;
            this.name = name;
        }

        public int getAgilityBonus
        {
            get { return agilityBonus; }
        }
        public int getLifeBonus
        {
            get { return LifePointBonus; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpecialItemAlways))
                return false;


            SpecialItemAlways specialItemCombat = (SpecialItemAlways)obj;
            if (this.name != specialItemCombat.name)
                return false;
            if (this.agilityBonus != specialItemCombat.agilityBonus)
                return false;
            if (this.LifePointBonus != specialItemCombat.LifePointBonus)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { name, agilityBonus, LifePointBonus }.GetHashCode();
        }
        public override string getDisplayName
        {
            get
            {
                if (agilityBonus > 0 && LifePointBonus > 0)
                {
                    return name + " (+" + agilityBonus + " agi" + " +" + LifePointBonus + " life permanent)";
                }
                if (agilityBonus > 0)
                {
                    return name + " (+" + agilityBonus + " agi permanent)";
                }
                if (LifePointBonus > 0)
                {
                    return name + " (+" + LifePointBonus + " life permanent)";
                }
                return name;
            }
        }

    }

    public class SpecialItemUsage : SpecialItem
    {
        //Has an effect on usage (Example : a key that you can use to unlock a cell)
    }

}
