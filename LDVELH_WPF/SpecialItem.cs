using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public abstract class SpecialItem : Loot
    {
        [Column]
        protected string name{get;set;}

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
        [Column]
        int agilityBonus{get;set;}
        [Column]
        int hitPointBonus { get; set; }

        public override string getDisplayName
        {
            get
            {
                Translator translator = new Translator();
                if (agilityBonus > 0 && hitPointBonus > 0)
                {
                    return name + " (+" + agilityBonus + " " + translator.ProvideValue("agi") + " +" + hitPointBonus + " " + translator.ProvideValue("HP") + " " + translator.ProvideValue("DuringBattle") + ")";
                }
                if (agilityBonus > 0 )
                {
                    return name + " (+" + agilityBonus + " " + translator.ProvideValue("agi") + " " + translator.ProvideValue("DuringBattle") + ")";
                }
                if (hitPointBonus > 0)
                {
                    return name + " (+" + hitPointBonus + " " + translator.ProvideValue("HP") + " " + translator.ProvideValue("DuringBattle") + ")";
                }
                return name;
            }
        }
        private SpecialItemCombat()
        {

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
        [Column]
        int agilityBonus { get; set; }
        [Column]
        int LifePointBonus { get; set; }
        private SpecialItemAlways()
        {

        }
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
                Translator translator = new Translator();
                if (agilityBonus > 0 && LifePointBonus > 0)
                {
                    return name + " (+" + agilityBonus + " " + translator.ProvideValue("agi") + " +" + LifePointBonus + " " + translator.ProvideValue("HP") + " " + translator.ProvideValue("permanent")+ ")";
                }
                if (agilityBonus > 0)
                {
                    return name + " (+" + agilityBonus + " " + translator.ProvideValue("agi") + " " + translator.ProvideValue("permanent") + ")";
                }
                if (LifePointBonus > 0)
                {
                    return name + " (+" + LifePointBonus + " " + translator.ProvideValue("HP") +" " + translator.ProvideValue("permanent") + ")";
                }
                return name;
            }
        }

    }

    public class SpecialItemUsage : SpecialItem
    {
        //Has an effect on usage (Example : a key that you can use to unlock a cell)
        private SpecialItemUsage()
        {

        }
        public SpecialItemUsage(String name)
        {
            this.name = name;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is SpecialItemUsage))
                return false;


            SpecialItemUsage specialItemCombat = (SpecialItemUsage)obj;
            if (this.name != specialItemCombat.name)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { name }.GetHashCode();
        }
        public override string getDisplayName
        {
            get
            {
               return name;
            }
        }
    }

}
