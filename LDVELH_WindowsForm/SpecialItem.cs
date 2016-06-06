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
    }

    public class SpecialItemCombat : SpecialItem
    {
        //Has an effect during combat (Example : +2 agility shield)
        int agilityBonus;
        int hitPointBonus;

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
