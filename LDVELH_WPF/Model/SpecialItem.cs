using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public override void add(Hero hero)
        {
            hero.specialItems.Add(this);
            hero.specialItemHasChanged(this, true);
        }
        public override void remove(Hero hero)
        {
            if (hero.specialItems.Remove(this))
            {
                hero.specialItemHasChanged(this, false);
            }
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
                if (agilityBonus > 0 && hitPointBonus > 0)
                {
                    return name + " (+" + agilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " +" + hitPointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("DuringBattle") + ")";
                }
                if (agilityBonus > 0 )
                {
                    return name + " (+" + agilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " " + GlobalTranslator.Instance.translator.ProvideValue("DuringBattle") + ")";
                }
                if (hitPointBonus > 0)
                {
                    return name + " (+" + hitPointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("DuringBattle") + ")";
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
        public override void add(Hero hero)
        {
            base.add(hero);

            if (this.getLifeBonus > 0)
            {
                hero.increaseMaxLife(this.getLifeBonus);
                hero.heal(this.getLifeBonus);
            }
            if (this.getAgilityBonus > 0)
            {
                hero.increaseAgility(this.getAgilityBonus);
            }
        }
        public override void remove(Hero hero)
        {
            base.remove(hero);

            if (this.getLifeBonus > 0)
            {
                hero.decreaseMaxLife(this.getLifeBonus);
            }
            if (this.getAgilityBonus > 0)
            {
                hero.decreaseAgility(this.getAgilityBonus);
            }
        
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
                    return name + " (+" + agilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " +" + LifePointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("permanent") + ")";
                }
                if (agilityBonus > 0)
                {
                    return name + " (+" + agilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " " + GlobalTranslator.Instance.translator.ProvideValue("permanent") + ")";
                }
                if (LifePointBonus > 0)
                {
                    return name + " (+" + LifePointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("permanent") + ")";
                }
                return name;
            }
        }

    }

    public class QuestItem : SpecialItem
    {
        //Has an effect on usage (Example : a key that you can use to unlock a cell)
        private QuestItem()
        {

        }
        public QuestItem(String name)
        {
            this.name = name;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is QuestItem))
                return false;


            QuestItem specialItemCombat = (QuestItem)obj;
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
