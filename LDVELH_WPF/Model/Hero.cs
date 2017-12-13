using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Linq;

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
        // ReSharper disable once InconsistentNaming
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
        public string HungryStatusDisplay => GlobalTranslator.Instance.Translator.ProvideValue(_HungryStatus.ToString());

        private int _combatDebuff;

        [Column("Paragraph")]
        // ReSharper disable once InconsistentNaming : Requiered for Database
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
        // ReSharper disable once InconsistentNaming : Requiered for Database
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
        public string WeaponMasteryDisplay => GlobalTranslator.Instance.Translator.ProvideValue(_WeaponMastery.ToString());

        private Hero()
        {
        }
        /// <summary>
        /// Create a Hero
        /// </summary>
        /// <param name="name">The Hero Name</param>
        public Hero(string name)
        {
            Name = name;
            MaxHitPoint = RandMaxHitPoint();
            ActualHitPoint = MaxHitPoint;
            BaseAgility = RandBaseAgility();
            Gold = 0;
            CurrentParagraph = 1;
            WeaponMastery = WeaponTypes.None;
            Capacities = new ObservableCollection<Capacity>();
            BackPack = new BackPack();
            WeaponHolder = new WeaponHolder();
            SpecialItems = new ObservableCollection<SpecialItem>();
            HungryStatus = HungryState.Hungry;
            _combatDebuff = 0;
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
            BaseAgility += bonusAgility;
        }
        internal void DecreaseAgility(int bonusAgility)
        {
            BaseAgility -= bonusAgility;
        }
        internal void IncreaseMaxLife(int bonusLife)
        {
            MaxHitPoint += bonusLife;
        }
        internal void DecreaseMaxLife(int bonusLife)
        {
            MaxHitPoint -= bonusLife;
            if (ActualHitPoint > MaxHitPoint)
            {
                ActualHitPoint = MaxHitPoint;
            }
        }
        /// <summary>
        /// Heal the Hero for a specified amount of Health
        /// </summary>
        /// <param name="healAmount">The amount of Health gained back by the Hero</param>
        public void Heal(int healAmount)
        {
            ActualHitPoint += healAmount;
            if (ActualHitPoint > MaxHitPoint)
            {
                ActualHitPoint = MaxHitPoint;
            }
        }
        
        public void AddGold(int gold)
        {
            Gold += gold;
        }
        public void RemoveGold(int gold)
        {
            if ((Gold - gold) >= 0)
            {

                Gold -= gold;
            }
            else
            {
                throw new NotEnoughtGoldException("Error Not Enought Gold");
            }

        }
        public void EmptyGold()
        {
            int tempoGold = Gold;
            Gold = 0;
        }

        public void AddCapacity(CapacityType capacityType)
        {
            if(MaxNumberOfCapacities > Capacities.Count)
            {
                if (!PossesCapacity(capacityType))
                {
                    Capacity capacity = new Capacity(capacityType);
                    Capacities.Add(capacity);

                    if (capacityType == CapacityType.WeaponMastery)
                    {
                        while (WeaponMastery == WeaponTypes.None)
                        {
                            WeaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
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
                WeaponMastery = WeaponTypes.None;
            }
        }

        public ObservableCollection<SpecialItem> GetSpecialItems => SpecialItems;

        public SpecialItem GetSpecialItem(SpecialItem specialItem)
        {
            return SpecialItems.FirstOrDefault(spItem => spItem == specialItem);
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
            BackPack.GetItems.Clear();
        }
        public void RemoveWeaponHolder()
        {
            WeaponHolder.GetWeapons.Clear();
        }
        /// <summary>
        /// Called on every Paragraph that does not contain a fight, Heal if the Hero posses the Healing Capacity
        /// </summary>
        public void Rest()
        {
            if (PossesCapacity(CapacityType.Healing))//Healing capacity allow you to regen when not fighting, see resolve of StoryParagraph
            {
                Heal(HealingCapacityRegen);
            }
        }
        /// <summary>
        /// Change the Hungry State of the Hero to Full
        /// </summary>
        public void Eat()
        {
            if (HungryStatus != HungryState.Full)
            {
                HungryStatus = HungryState.Full;
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
            if (!PossesCapacity(CapacityType.Hunting))//Hunting capacity allow you to never have to eat when required.
            {
                if (HungryStatus == HungryState.Hungry)
                {
                    TakeDamage(SkipMealDamage);
                }
                HungryStatus = HungryState.Hungry;
            }
            
        }
        /// <summary>
        /// Check if the Hero posses a Capacity
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns>True if he does, False else</returns>
        public bool PossesCapacity(CapacityType capacity)
        {
            return Capacities.Any(capa => capa.CapacityKind == capacity);
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
        private bool PossesWeapon(string itemName)
        {
            return WeaponHolder.GetWeapons.Any(weapon => weapon.Name == itemName);
        }
        /// <summary>
        /// Check if the Hero posses a particular BackPack Item 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>True if he does, False else</returns>
        private bool PossesBackPackItem(string itemName)
        {
            return BackPack.GetItems.Any(item => item.Name == itemName);
        }
        /// <summary>
        /// Check if the Hero posses a particular Special Item 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>True if he does, False else</returns>
        private bool PossesSpecialItem(string itemName)
        {
            return GetSpecialItems.Any(specialItem => specialItem.Name == itemName);
        }

        public void AddTempDebuff(int debuff)
        {
            _combatDebuff += debuff;
        }
        public void RemoveTempDebuff()
        {
            _combatDebuff = 0;
        }

        /// <summary>
        /// A round of fighting between the Hero and an Enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns>True if the Enemy is dead, False if not, YouAreDeadException if the Hero is dead</returns>
        public bool Fight(Enemy enemy)
        {
            int strenghtDifference = FindStrenghtDifference(enemy);
            bool battleOver = false;
            try
            {
                battleOver = ResolveDamage(strenghtDifference, enemy);
            }
            catch (YouAreDeadException)
            {
                throw;
            }

            return battleOver;
        }

        public int FindStrenghtDifference(Enemy enemy)
        {
            int heroAgility = GetHeroAgilityInBattle(enemy);
            int enemyAgility = enemy.BaseAgility;
            return (heroAgility - enemyAgility);
        }

        public int GetHeroAgilityInBattle(Enemy enemy)
        {
           return BaseAgility+ GetBonusAgility(enemy) - GetMalusAgility();
        }

        public int GetBonusAgility(Enemy enemy)
        {
            int bonusAgility = 0;
            bonusAgility += GetBonusItemAgility();
            bonusAgility += GetBonusCapacityAgility(enemy);
            return bonusAgility;
        }

        private int GetBonusItemAgility()
        {
            return SpecialItems.OfType<SpecialItemCombat>().Sum(combatItem => (combatItem).AgilityBonus);
        }

        private int GetBonusCapacityAgility(Enemy enemy)
        {
            int bonusAgility = 0;
            if (PossesCapacity(CapacityType.WeaponMastery))
            {
                if (WeaponHolder.Contains(WeaponMastery))
                {
                    bonusAgility += Capacity.WeaponMasteryStrenght;
                }
            }

            if (!PossesCapacity(CapacityType.PsychicPower)) return bonusAgility;

            if (enemy.IsWeakToPhychic())
            {
                bonusAgility += Capacity.PhychicPowerStrenght;
            }
            return bonusAgility;
        }

        private int GetMalusAgility()
        {
            int malusAgility = 0;
            if (WeaponHolder.IsEmpty())
            {
                malusAgility += UnharmedCombatDebuff;
            }
            malusAgility += _combatDebuff;
            return malusAgility;
        }
        /// <summary>
        /// Inflict damage to both the Hero and Enemy depending on the result of the DamageTable
        /// </summary>
        /// <param name="strenghDifference"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        private bool ResolveDamage(int strenghDifference, Enemy enemy)
        {
            int randomD10 = DiceRoll.D10Roll();
            enemy.TakeDamage(DamageTable.EnemyDamageTaken(strenghDifference, randomD10));
            try
            {
                TakeDamage(DamageTable.HeroDamageTaken(strenghDifference, randomD10));
            }
            catch (YouAreDeadException)
            {
                throw;
            }
            return enemy.ActualHitPoint<= 0;
        }
        /// <summary>
        ///This function must ONLY be called when loading a hero from the database, if a hero is saved while his BackPack/WeaponHolder/SpecialItems is empty, then when loading it then be equal to null instead of empty
        ///So in order to make sure we don't have any null element, we check for null and incase create a new empty element.
        /// </summary>
        public void NoNullInHero()
        {
            
            if (SpecialItems == null)
                SpecialItems = new ObservableCollection<SpecialItem>();
            if (Capacities == null)
                Capacities = new ObservableCollection<Capacity>();
            if (BackPack == null)
                BackPack = new BackPack();
            if (WeaponHolder == null)
                WeaponHolder = new WeaponHolder();
        }
        
        public string GetResume => Name + " ( Paragraph : " + CurrentParagraph + " )";

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
