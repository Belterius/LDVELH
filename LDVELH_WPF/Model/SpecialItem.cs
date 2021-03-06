﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDVELH_WPF
{
    /// <summary>
    /// All Items that don't take any spot in the Hero BackPack.
    /// <para /> A Hero can carry an Unlimited number of Special Item
    /// <para /> A Special Item is a proof that the player took a certain choice/path, and prevent the player from unintentionnaly being blocked by throwing a required Item to progress through the game
    /// <para /> It is also used for Items providing permanents bonuses
    /// </summary>
    public abstract class SpecialItem : Loot
    {
        [Column]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
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

        public virtual string DisplayName => Name;

        public override void Add(Hero hero)
        {
            hero.SpecialItems.Add(this);
        }
        public override void Remove(Hero hero)
        {
            hero.SpecialItems.Remove(this);
        }
    }

    /// <summary>
    /// A SpecialItemCombat provide a bonus to the Hero during every fight
    /// <para /> It won't provide its bonus if the Hero is not in a fight (for example for an event requiring an Agility test)
    /// </summary>
    public class SpecialItemCombat : SpecialItem
    {
        [Column("AgilityBonus")]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        int _AgilityBonus{get;set;}
        /// <summary>        
        ///Has an effect only during combat (Example : +2 agility shield)
        /// </summary>
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
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local : Requiered because of the Database that will need to be able to set
        private int HitPointBonus { get; set; }

        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                if (AgilityBonus > 0 && HitPointBonus > 0)
                {
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("agi") + " +" + HitPointBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.Translator.ProvideValue("DuringBattle") + ")";
                }
                if (AgilityBonus > 0 )
                {
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("agi") + " " + GlobalTranslator.Instance.Translator.ProvideValue("DuringBattle") + ")";
                }
                if (HitPointBonus > 0)
                {
                    return Name + " (+" + HitPointBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.Translator.ProvideValue("DuringBattle") + ")";
                }
                return Name;
            }
        }
        private SpecialItemCombat()
        {

        }
        /// <summary>
        /// Create an Item that doesn't take any BackPack space and provide a bonus during every fight
        /// </summary>
        /// <param name="name">The Name of the Item</param>
        /// <param name="agilityBonus">The Agility bonus it provides during a fight</param>
        /// <param name="hitPointBonus">The Health bonus it provides during a fight</param>
        public SpecialItemCombat(String name, int agilityBonus, int hitPointBonus)
        {
            AgilityBonus = agilityBonus;
            HitPointBonus = hitPointBonus;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpecialItemCombat))
                return false;


            SpecialItemCombat specialItemCombat = (SpecialItemCombat)obj;
            if (Name != specialItemCombat.Name)
                return false;
            if (AgilityBonus != specialItemCombat.AgilityBonus)
                return false;
            if (HitPointBonus != specialItemCombat.HitPointBonus)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { Name, AgilityBonus, HitPointBonus }.GetHashCode();
        }

        
    }
    /// <summary>
    /// A SpecialItemAlways provide a permanent bonus to the Hero at any moment
    /// </summary>
    public class SpecialItemAlways : SpecialItem
    {
        [Column("AgilityBonus")]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        int _AgilityBonus { get; set; }

        /// <summary>
        //Has a permanent effect (Example : +4 HitPoint chain mail)
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
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
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        int _HitPointBonus { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
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

        /// <summary>
        /// Create an Item that doesn't take any BackPack space and provide a bonus all the time
        /// </summary>
        /// <param name="name">The Name of the Item</param>
        /// <param name="agilityBonus">The Agility bonus it provides</param>
        /// <param name="hitPointBonus">The Health bonus it provides</param>
        public SpecialItemAlways(String name, int agilityBonus, int hitPointBonus)
        {
            AgilityBonus = agilityBonus;
            HitPointBonus = hitPointBonus;
            Name = name;
        }
        
        
        
        public override void Add(Hero hero)
        {
            base.Add(hero);

            if (HitPointBonus > 0)
            {
                hero.IncreaseMaxLife(HitPointBonus);
                hero.Heal(HitPointBonus);
            }
            if (AgilityBonus > 0)
            {
                hero.IncreaseAgility(AgilityBonus);
            }
        }
        public override void Remove(Hero hero)
        {
            base.Remove(hero);

            if (HitPointBonus > 0)
            {
                hero.DecreaseMaxLife(HitPointBonus);
            }
            if (AgilityBonus > 0)
            {
                hero.DecreaseAgility(AgilityBonus);
            }
        
        }
        public override bool Equals(object obj)
        {
            if (!(obj is SpecialItemAlways))
                return false;


            SpecialItemAlways specialItemCombat = (SpecialItemAlways)obj;
            if (Name != specialItemCombat.Name)
                return false;
            if (AgilityBonus != specialItemCombat.AgilityBonus)
                return false;
            if (HitPointBonus != specialItemCombat.HitPointBonus)
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
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("agi") + " +" + HitPointBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.Translator.ProvideValue("permanent") + ")";
                }
                if (AgilityBonus > 0)
                {
                    return Name + " (+" + AgilityBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("agi") + " " + GlobalTranslator.Instance.Translator.ProvideValue("permanent") + ")";
                }
                if (HitPointBonus > 0)
                {
                    return Name + " (+" + HitPointBonus + " " + GlobalTranslator.Instance.Translator.ProvideValue("HP") + " " + GlobalTranslator.Instance.Translator.ProvideValue("permanent") + ")";
                }
                return Name;
            }
        }

    }

    /// <inheritdoc />
    /// <summary>
    /// A SpecialItem that doesn't provide any bonus, it will only be usefull when an Event require the Item.
    /// </summary>
    public class QuestItem : SpecialItem
    {
        //Has an effect on usage (Example : a key that you can use to unlock a cell)
        private QuestItem()
        {

        }
        public QuestItem(string name)
        {
            Name = name;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is QuestItem))
                return false;


            QuestItem specialItemCombat = (QuestItem)obj;
            return Name == specialItemCombat.Name;
        }
        public override int GetHashCode()
        {
            return new { Name }.GetHashCode();
        }
        public override string DisplayName => Name;
    }

}
