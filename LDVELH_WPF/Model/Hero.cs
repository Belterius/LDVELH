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
        public static readonly int SkipMealDamage = 3;
        public static readonly int UnharmedCombatDebuff = 4;
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
        

        public ObservableCollection<Capacity> Capacities { get; set; }

        public BackPack BackPack { get; set; }

        public WeaponHolder WeaponHolder { get; set; }

        public ObservableCollection<SpecialItem> SpecialItems { get; set; }

        [Column("HungryState")]
        private HungryState _HungryStatus{get;set;}
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


        public void AddCapacity(Capacity capacity)
        {
            Capacities.Add(capacity);
            if (capacity.CapacityKind == CapacityType.WeaponMastery)
            {
                while (this.WeaponMastery == WeaponTypes.None)
                {
                    this.WeaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                }
            }
        }
        public void AddCapacity(CapacityType capacityType)
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

        public void Rest()
        {
            if (this.PossesCapacity(CapacityType.Healing))//Healing capacity allow you to regen when not fighting, see resolve of StoryParagraph
            {
                this.Heal(HealingCapacityRegen);
            }
        }
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

        public void NoNullInHero()
        {
            //This function must ONLY be called when loading a hero from the database, if a hero is saved while his BackPack/WeaponHolder/SpecialItems is empty, then when loading it then be equal to null instead of empty
            //So in order to make sure we don't have any null element, we check for null and incase create a new empty element.
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

}
