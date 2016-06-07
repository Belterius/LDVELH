using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public abstract class SpecialItem
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
                    return name + " (+" + agilityBonus + " agi" + " +" + hitPointBonus +" life)";
                }
                if (agilityBonus > 0 )
                {
                    return name + " (+" + agilityBonus + " agi)";
                }
                if (hitPointBonus > 0)
                {
                    return name + " (+" + hitPointBonus + " life)";
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

        
    }

    public class SpecialItemAlways : SpecialItem
    {
        //Has a permanent effect (Example : +4 HitPoint chain mail)
    }

    public class SpecialItemUsage : SpecialItem
    {
        //Has an effect on usage (Example : a key that you can use to unlock a cell)
    }

}
