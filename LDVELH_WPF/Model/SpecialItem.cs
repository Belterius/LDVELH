using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDVELH_WPF
{
    public abstract class SpecialItem : Loot
    {
        [Column]
        private string _Name{get;set;}

        public string Name
        {
            get
            {
                return _Name;
            }
            protected set
            {
                if (_Name != value)
                {
                    _Name = value;
                }
            }
        }

        public virtual string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                return Name;
            }
        }
        public override void Add(Hero hero)
        {
            hero.SpecialItems.Add(this);
        }
        public override void Remove(Hero hero)
        {
            hero.SpecialItems.Remove(this);
        }
    }

    public class SpecialItemCombat : SpecialItem
    {
        //Has an effect only during combat (Example : +2 agility shield)
        [Column("AgilityBonus")]
        int _AgilityBonus{get;set;}
        public int AgilityBonus
        {
            get { return _AgilityBonus; }
            private set
            {
                if (_AgilityBonus != value)
                {
                    _AgilityBonus = value;
                }
            }
        }
        [Column("HitPointBonus")]
        int HitPointBonus { get; set; }

        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                if (AgilityBonus > 0 && HitPointBonus > 0)
                {
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " +" + HitPointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("DuringBattle") + ")";
                }
                if (AgilityBonus > 0 )
                {
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " " + GlobalTranslator.Instance.translator.ProvideValue("DuringBattle") + ")";
                }
                if (HitPointBonus > 0)
                {
                    return Name + " (+" + HitPointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("DuringBattle") + ")";
                }
                return Name;
            }
        }
        private SpecialItemCombat()
        {

        }
        public SpecialItemCombat(String name, int agilityBonus, int hitPointBonus)
        {
            this.AgilityBonus = agilityBonus;
            this.HitPointBonus = hitPointBonus;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpecialItemCombat))
                return false;


            SpecialItemCombat SpecialItemCombat = (SpecialItemCombat)obj;
            if (this.Name != SpecialItemCombat.Name)
                return false;
            if (AgilityBonus != SpecialItemCombat.AgilityBonus)
                return false;
            if (this.HitPointBonus != SpecialItemCombat.HitPointBonus)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { Name, AgilityBonus, HitPointBonus }.GetHashCode();
        }

        
    }

    public class SpecialItemAlways : SpecialItem
    {
        //Has a permanent effect (Example : +4 HitPoint chain mail)
        [Column("AgilityBonus")]
        int _AgilityBonus { get; set; }
        public int AgilityBonus
        {
            get { return _AgilityBonus; }
            private set
            {
                if (_AgilityBonus != value)
                {
                    _AgilityBonus = value;
                }
            }
        }
        [Column("HitPointBonus")]
        int _HitPointBonus { get; set; }
        public int HitPointBonus
        {
            get { return _HitPointBonus; }
            private set
            {
                if (_HitPointBonus != value)
                {
                    _HitPointBonus = value;
                }
            }
        }
        private SpecialItemAlways()
        {

        }
        public SpecialItemAlways(String name, int agilityBonus, int hitPointBonus)
        {
            AgilityBonus = agilityBonus;
            HitPointBonus = hitPointBonus;
            Name = name;
        }
        
        
        
        public override void Add(Hero hero)
        {
            base.Add(hero);

            if (this.HitPointBonus > 0)
            {
                hero.IncreaseMaxLife(this.HitPointBonus);
                hero.Heal(this.HitPointBonus);
            }
            if (this.AgilityBonus > 0)
            {
                hero.IncreaseAgility(this.AgilityBonus);
            }
        }
        public override void Remove(Hero hero)
        {
            base.Remove(hero);

            if (this.HitPointBonus > 0)
            {
                hero.DecreaseMaxLife(this.HitPointBonus);
            }
            if (this.AgilityBonus > 0)
            {
                hero.DecreaseAgility(this.AgilityBonus);
            }
        
        }
        public override bool Equals(object obj)
        {
            if (!(obj is SpecialItemAlways))
                return false;


            SpecialItemAlways SpecialItemCombat = (SpecialItemAlways)obj;
            if (this.Name != SpecialItemCombat.Name)
                return false;
            if (this.AgilityBonus != SpecialItemCombat.AgilityBonus)
                return false;
            if (this.HitPointBonus != SpecialItemCombat.HitPointBonus)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { Name, AgilityBonus, HitPointBonus }.GetHashCode();
        }
        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                if (AgilityBonus > 0 && HitPointBonus > 0)
                {
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " +" + HitPointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("permanent") + ")";
                }
                if (AgilityBonus > 0)
                {
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("agi") + " " + GlobalTranslator.Instance.translator.ProvideValue("permanent") + ")";
                }
                if (HitPointBonus > 0)
                {
                    return Name + " (+" + HitPointBonus + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.translator.ProvideValue("permanent") + ")";
                }
                return Name;
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
            this.Name = name;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is QuestItem))
                return false;


            QuestItem SpecialItemCombat = (QuestItem)obj;
            if (this.Name != SpecialItemCombat.Name)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { Name }.GetHashCode();
        }
        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
               return Name;
            }
        }
    }

}
