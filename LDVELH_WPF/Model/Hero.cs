using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace LDVELH_WPF
{
    public class Hero : Character, INotifyPropertyChanged
    {
        /// <summary>
        /// The damage the Hero will take by not having eaten before a MealEvent
        /// </summary>
        public static readonly int SkipMealDamage = 3;
        /// <summary>
        /// The Agility Debuff the Hero will have by figthing with no weapon
        /// </summary>
        public static readonly int UnharmedCombatDebuff = 4;
        /// <summary>
        /// The amount of Health the Hero will gain at each Paragraph if he has the Healing Capacity
        /// </summary>
        public static readonly int HealingCapacityRegen = 1;
        
        [ForeignKey("BackPack")]
        public int BackPack_ID{get;set;}

        [ForeignKey("WeaponHolder")]
        public int WeaponHolder_ID { get; set; }

        [Column("Gold")]
        private int _Gold { get; set; }
        public int Gold
        {
            get
            {
                return _Gold;
            }
            private set
            {
                if (_Gold != value)
                {
                    _Gold = value;
                    RaisePropertyChanged("Gold");
                }
            }
        }

        [Column("MaxNumberOfCapacities")]
        private int _MaxNumberOfCapacities = 5; // Can change depending on the number of stories completed
        /// <summary>
        /// The Max number of capacities the Hero can posses
        /// </summary>
        public int MaxNumberOfCapacities
        {
            get
            {
                return _MaxNumberOfCapacities;
            }
            private set
            {
                if (_MaxNumberOfCapacities != value)
                {
                    _MaxNumberOfCapacities = value;
                    RaisePropertyChanged("MaxNumberOfCapacities");
                }
            }
        }
        /// <summary>
        /// All the Hero known Capacities
        /// </summary>
        public ObservableCollection<Capacity> Capacities { get; set; }
        /// <summary>
        /// Contains all the Hero Items
        /// </summary>
        public BackPack BackPack { get; set; }

        /// <summary>
        /// Contain all the Hero Weapons
        /// </summary>
        public WeaponHolder WeaponHolder { get; set; }
        /// <summary>
        /// Contains all the Hero SpecialItems
        /// </summary>
        public ObservableCollection<SpecialItem> SpecialItems { get; set; }

        [Column("HungryState")]
        private HungryState _HungryStatus{get;set;}
        /// <summary>
        /// The current Hungry Status of the Hero
        /// </summary>
        public HungryState HungryStatus
        {
            get
            {
                return _HungryStatus;
            }
            private set
            {
                if (_HungryStatus != value)
                {
                    _HungryStatus = value;
                    RaisePropertyChanged("HungryStatus");
                    RaisePropertyChanged("HungryStatusDisplay");
                }
            }
        }
        public string HungryStatusDisplay
        {
            get
            {
                return GlobalTranslator.Instance.Translator.ProvideValue(_HungryStatus.ToString());
            }
        }

        private int CombatDebuff;

        [Column("Paragraph")]
        private int _CurrentParagraph { get; set; }
        public int CurrentParagraph
        {
            get
            {
                return _CurrentParagraph;
            }
            set
            {
                if (_CurrentParagraph != value)
                {
                    _CurrentParagraph = value;
                    RaisePropertyChanged("CurrentParagraph");
                }
            }
        }

        [Column("WeaponMastery")]
        private WeaponTypes _WeaponMastery { get; set; }
        public WeaponTypes WeaponMastery
        {
            get
            {
                return _WeaponMastery;
            }
            private set
            {
                if (_WeaponMastery != value)
                {
                    _WeaponMastery = value;
                    RaisePropertyChanged("WeaponMastery");
                    RaisePropertyChanged("WeaponMasteryDisplay");
                }
            }
        }
        public string WeaponMasteryDisplay
        {
            get
            {
                return GlobalTranslator.Instance.Translator.ProvideValue(_WeaponMastery.ToString());
            }
        }

        private Hero()
        {
        }
        /// <summary>
        /// Create a Hero
        /// </summary>
        /// <param name="name">The Hero Name</param>
        public Hero(string name)
        {
            this.Name = name;
            this.MaxHitPoint = RandMaxHitPoint();
            this.ActualHitPoint = this.MaxHitPoint;
            this.BaseAgility = RandBaseAgility();
            this.Gold = 0;
            this.CurrentParagraph = 1;
            WeaponMastery = WeaponTypes.None;
            Capacities = new ObservableCollection<Capacity>();
            BackPack = new BackPack();
            WeaponHolder = new WeaponHolder();
            SpecialItems = new ObservableCollection<SpecialItem>();
            HungryStatus = HungryState.Hungry;
            CombatDebuff = 0;
        }

        private int RandMaxHitPoint()
        {
            int minimumValue = 20;
            return minimumValue + DiceRoll.D10Roll();
        }
        private int RandBaseAgility()
        {
            int minimumValue = 10;
            return minimumValue + DiceRoll.D10Roll();
        }
        internal void IncreaseAgility(int bonusAgility)
        {
            this.BaseAgility += bonusAgility;
        }
        internal void DecreaseAgility(int bonusAgility)
        {
            this.BaseAgility -= bonusAgility;
        }
        internal void IncreaseMaxLife(int bonusLife)
        {
            this.MaxHitPoint += bonusLife;
        }
        internal void DecreaseMaxLife(int bonusLife)
        {
            this.MaxHitPoint -= bonusLife;
            if (this.ActualHitPoint > this.MaxHitPoint)
            {
                this.ActualHitPoint = this.MaxHitPoint;
            }
        }
        /// <summary>
        /// Heal the Hero for a specified amount of Health
        /// </summary>
        /// <param name="healAmount">The amount of Health gained back by the Hero</param>
        public void Heal(int healAmount)
        {
            this.ActualHitPoint += healAmount;
            if (this.ActualHitPoint > this.MaxHitPoint)
            {
                this.ActualHitPoint = this.MaxHitPoint;
            }
        }
        
        public void AddGold(int gold)
        {
            this.Gold += gold;
        }
        public void RemoveGold(int gold)
        {
            if ((this.Gold - gold) >= 0)
            {

                this.Gold -= gold;
            }
            else
            {
                throw new NotEnoughtGoldException("Error Not Enought Gold");
            }

        }
        public void EmptyGold()
        {
            int tempoGold = this.Gold;
            this.Gold = 0;
        }

        public void AddCapacity(CapacityType capacityType)
        {
            if(this.MaxNumberOfCapacities > this.Capacities.Count)
            {
                if (!PossesCapacity(capacityType))
                {
                    Capacity capacity = new Capacity(capacityType);
                    Capacities.Add(capacity);

                    if (capacityType == CapacityType.WeaponMastery)
                    {
                        while (this.WeaponMastery == WeaponTypes.None)
                        {
                            this.WeaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                        }
                    }
                }
                
            }
            else
            {
                throw new MaxNumberOfCapacitiesReached(GlobalTranslator.Instance.Translator.ProvideValue("TooManyCapacities") + " (" + MaxNumberOfCapacities + ")");
            }
            
        }
        public void RemoveCapacity(CapacityType capacityType)
        {
            Capacity capacity = new Capacity(capacityType);
            Capacities.Remove(capacity);

            if (capacityType == CapacityType.WeaponMastery)
            {
                this.WeaponMastery = WeaponTypes.None;
            }
        }

        public ObservableCollection<SpecialItem> GetSpecialItems
        {
            get { return SpecialItems; }
        }
        public SpecialItem GetSpecialItem(SpecialItem specialItem)
        {
            foreach (SpecialItem SpItem in SpecialItems)
            {
                if (SpItem == specialItem)
                {
                    return SpItem;
                }
            }
            return null;
        }
        public void UseItem(Item item)
        {
            try
            {
                item.Use(this);
            }
            catch (ItemDestroyedException)
            {
                item.Remove(this);
            }
            catch (CannotUseItemException)
            {
                throw;
            }

        }

        public void AddLoot(Loot loot)
        {
            try
            {
                loot.Add(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveLoot(Loot loot)
        {
            try
            {
                loot.Remove(this);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveBackPack()
        {
            this.BackPack.GetItems.Clear();
        }
        public void RemoveWeaponHolder()
        {
            this.WeaponHolder.GetWeapons.Clear();
        }
        /// <summary>
        /// Called on every Paragraph that does not contain a fight, Heal if the Hero posses the Healing Capacity
        /// </summary>
        public void Rest()
        {
            if (this.PossesCapacity(CapacityType.Healing))//Healing capacity allow you to regen when not fighting, see resolve of StoryParagraph
            {
                this.Heal(HealingCapacityRegen);
            }
        }
        /// <summary>
        /// Change the Hungry State of the Hero to Full
        /// </summary>
        public void Eat()
        {
            if (this.HungryStatus != HungryState.Full)
            {
                this.HungryStatus = HungryState.Full;
            }
            else
            {
                throw new CantEatException();
            }
            
        }
        /// <summary>
        /// Check if the Hero is not Hungry, and either make him Hungry or make him take damage
        /// </summary>
        public void MealTime()
        {
            if (!this.PossesCapacity(CapacityType.Hunting))//Hunting capacity allow you to never have to eat when required.
            {
                if (this.HungryStatus == HungryState.Hungry)
                {
                    this.TakeDamage(SkipMealDamage);
                }
                this.HungryStatus = HungryState.Hungry;
            }
            
        }
        /// <summary>
        /// Check if the Hero posses a Capacity
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns>True if he does, False else</returns>
        public bool PossesCapacity(CapacityType capacity)
        {
            foreach (Capacity Capa in this.Capacities)
            {
                if (Capa.CapacityKind == capacity)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check if the Hero posses an Item
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>True if he does, False else</returns>
        public bool PossesItem(String itemName)
        {
            if (PossesBackPackItem(itemName) || PossesSpecialItem(itemName) || PossesWeapon(itemName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Check if the Hero posses a particular Weapon 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>True if he does, False else</returns>
        private bool PossesWeapon(String itemName)
        {
            foreach (Weapon Weapon in this.WeaponHolder.GetWeapons)
            {
                if (Weapon.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check if the Hero posses a particular BackPack Item 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>True if he does, False else</returns>
        private bool PossesBackPackItem(String itemName)
        {
            foreach (Item Item in this.BackPack.GetItems)
            {
                if (Item.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check if the Hero posses a particular Special Item 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>True if he does, False else</returns>
        private bool PossesSpecialItem(String itemName)
        {
            foreach (SpecialItem SpecialItem in this.GetSpecialItems)
            {
                if (SpecialItem.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTempDebuff(int debuff)
        {
            this.CombatDebuff += debuff;
        }
        public void RemoveTempDebuff()
        {
            this.CombatDebuff = 0;
        }

        /// <summary>
        /// A round of fighting between the Hero and an Enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns>True if the Enemy is dead, False if not, YouAreDeadException if the Hero is dead</returns>
        public bool Fight(Enemy enemy)
        {
            int StrenghtDifference = FindStrenghtDifference(enemy);
            bool BattleOver = false;
            try
            {
                BattleOver = ResolveDamage(StrenghtDifference, enemy);
            }
            catch (YouAreDeadException)
            {
                throw;
            }

            return BattleOver;
        }

        public int FindStrenghtDifference(Enemy enemy)
        {
            int HeroAgility = GetHeroAgilityInBattle(enemy);
            int EnemyAgility = enemy.BaseAgility;
            return (HeroAgility - EnemyAgility);
        }

        public int GetHeroAgilityInBattle(Enemy enemy)
        {
           return this.BaseAgility+ GetBonusAgility(enemy) - GetMalusAgility();
        }

        public int GetBonusAgility(Enemy enemy)
        {
            int BonusAgility = 0;
            BonusAgility += GetBonusItemAgility();
            BonusAgility += GetBonusCapacityAgility(enemy);
            return BonusAgility;
        }

        private int GetBonusItemAgility()
        {
            int BonusAgility = 0;
            foreach (SpecialItem CombatItem in SpecialItems)
            {
                if (CombatItem is SpecialItemCombat)
                    BonusAgility += ((SpecialItemCombat)CombatItem).AgilityBonus;
            }
            return BonusAgility;
        }

        private int GetBonusCapacityAgility(Enemy enemy)
        {
            int BonusAgility = 0;
            if (this.PossesCapacity(CapacityType.WeaponMastery))
            {
                if (this.WeaponHolder.Contains(this.WeaponMastery))
                {
                    BonusAgility += Capacity.WeaponMasteryStrenght;
                }
            }
            if (this.PossesCapacity(CapacityType.PsychicPower))
            {
                if (enemy.IsWeakToPhychic())
                {
                    BonusAgility += Capacity.PhychicPowerStrenght;
                }
            }
            return BonusAgility;
        }

        private int GetMalusAgility()
        {
            int MalusAgility = 0;
            if (this.WeaponHolder.IsEmpty())
            {
                MalusAgility += UnharmedCombatDebuff;
            }
            MalusAgility += CombatDebuff;
            return MalusAgility;
        }
        /// <summary>
        /// Inflict damage to both the Hero and Enemy depending on the result of the DamageTable
        /// </summary>
        /// <param name="strenghDifference"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        private bool ResolveDamage(int strenghDifference, Enemy enemy)
        {
            int RandomD10 = DiceRoll.D10Roll();
            enemy.TakeDamage(DamageTable.enemyDamageTaken(strenghDifference, RandomD10));
            try
            {
                this.TakeDamage(DamageTable.heroDamageTaken(strenghDifference, RandomD10));
            }
            catch (YouAreDeadException)
            {
                throw;
            }
            if (enemy.ActualHitPoint<= 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///This function must ONLY be called when loading a hero from the database, if a hero is saved while his BackPack/WeaponHolder/SpecialItems is empty, then when loading it then be equal to null instead of empty
        ///So in order to make sure we don't have any null element, we check for null and incase create a new empty element.
        /// </summary>
        public void NoNullInHero()
        {
            
            if (this.SpecialItems == null)
                this.SpecialItems = new ObservableCollection<SpecialItem>();
            if (this.Capacities == null)
                this.Capacities = new ObservableCollection<Capacity>();
            if (this.BackPack == null)
                this.BackPack = new BackPack();
            if (this.WeaponHolder == null)
                this.WeaponHolder = new WeaponHolder();
        }
        
        public string GetResume
        {
            get { return this.Name + " ( Paragraph : " + this.CurrentParagraph + " )"; }
        }

        public enum HungryState
        {
            Hungry,
            Full
        }

    }
    /// <summary>
    /// Thrown when the Player doesn't have enought gold to perform an action
    /// </summary>
    [Serializable]
    public class NotEnoughtGoldException : Exception
    {
        public NotEnoughtGoldException()
        { }

        public NotEnoughtGoldException(string message)
            : base(message)
        { }

        public NotEnoughtGoldException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected NotEnoughtGoldException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }

    /// <summary>
    /// Thrown when the Hero cannot eat (usually because he has already eaten before and is still Full)
    /// </summary>
    [Serializable]
    public class CantEatException : Exception
    {
        public CantEatException()
        { }

        public CantEatException(string message)
            : base(message)
        { }

        public CantEatException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected CantEatException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }

    /// <summary>
    /// Thrown when the Hero's HP reach 0
    /// </summary>
    [Serializable]
    public class YouAreDeadException : Exception
    {
        public YouAreDeadException()
        { }

        public YouAreDeadException(string message)
            : base(message)
        { }

        public YouAreDeadException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected YouAreDeadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }
    /// <summary>
    /// Thrown when the Hero try to add a new Capacity while he has already reached the max allowed
    /// </summary>
    [Serializable]
    public class MaxNumberOfCapacitiesReached : Exception
    {
        public MaxNumberOfCapacitiesReached()
        { }

        public MaxNumberOfCapacitiesReached(string message)
            : base(message)
        { }

        public MaxNumberOfCapacitiesReached(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected MaxNumberOfCapacitiesReached(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }

}
