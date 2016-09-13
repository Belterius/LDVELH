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
        public static readonly int skipMealDamage = 3;
        public static readonly int unharmedCombatDebuff = 4;
        public static readonly int healingCapacityRegen = 1;

        [ForeignKey("backPack")]
        public int BackPack_ID{get;set;}

        [ForeignKey("weaponHolder")]
        public int WeaponHolder_ID { get; set; }

        public event MaxLifeHandler MaxLifeChanged;
        public delegate void MaxLifeHandler(Hero m, int lifeChange);

        public event AgilityHandler AgilityChanged;
        public delegate void AgilityHandler(Hero m, int agilityChange);

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

        public event GoldHandler GoldChanged;
        public delegate void GoldHandler(Hero m, int goldChange);

        public ObservableCollection<Capacity> capacities { get; set; }
        public event capacitiesHandler capacitiesChanged;
        public delegate void capacitiesHandler(Hero m, Capacity capacity);

        public BackPack backPack { get; set; }
        public event backPackHandler backPackChanged;
        public delegate void backPackHandler(Hero m, Item item, bool add);

        public WeaponHolder weaponHolder { get; set; }
        public event weaponHolderHandler weaponHolderChanged;
        public delegate void weaponHolderHandler(Hero m, Weapon weapon, bool add);

        public List<SpecialItem> specialItems { get; set; }
        public event specialItemsHandler specialItemsChanged;
        public delegate void specialItemsHandler(Hero m, SpecialItem specialItem, bool add);

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
                return GlobalTranslator.Instance.translator.ProvideValue(_HungryStatus.ToString());
            }
        }
        public event HungryStateHandler hungryStateChanged;
        public delegate void HungryStateHandler(Hero m);

        private int combatDebuff;

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
                return GlobalTranslator.Instance.translator.ProvideValue(_WeaponMastery.ToString());
            }
        }
        public event WeaponMasteryHandler weaponMasteryChanged;
        public delegate void WeaponMasteryHandler(Hero m);

        private Hero()
        {
        }

        public Hero(string name)
        {
            this.Name = name;
            this.MaxHitPoint = randMaxHitPoint();
            this.ActualHitPoint = this.MaxHitPoint;
            this.BaseAgility = randBaseAgility();
            this.Gold = 0;
            this.CurrentParagraph = 1;
            WeaponMastery = WeaponTypes.None;
            capacities = new ObservableCollection<Capacity>();
            backPack = new BackPack();
            weaponHolder = new WeaponHolder();
            specialItems = new List<SpecialItem>();
            HungryStatus = HungryState.Hungry;
            combatDebuff = 0;
        }

        private int randMaxHitPoint()
        {
            int minimumValue = 20;
            return minimumValue + DiceRoll.D10Roll();
        }
        private int randBaseAgility()
        {
            int minimumValue = 10;
            return minimumValue + DiceRoll.D10Roll();
        }
        internal void increaseAgility(int bonusAgility)
        {
            this.BaseAgility += bonusAgility;
            AgilityHasChanged(bonusAgility);
        }
        internal void decreaseAgility(int bonusAgility)
        {
            this.BaseAgility -= bonusAgility;
            AgilityHasChanged(bonusAgility);
        }
        public void AgilityHasChanged(int bonusAgility)
        {
            AgilityHandler handler = AgilityChanged;
            if (handler != null)
            {
                handler((Hero)this, bonusAgility);
            }
        }
        internal void increaseMaxLife(int bonusLife)
        {
            this.MaxHitPoint += bonusLife;
            MaxLifeHasChanged(bonusLife);
        }
        internal void decreaseMaxLife(int bonusLife)
        {
            this.MaxHitPoint -= bonusLife;
            if (this.ActualHitPoint > this.MaxHitPoint)
            {
                this.ActualHitPoint = this.MaxHitPoint;
            }
            MaxLifeHasChanged(bonusLife);
        }
        public void MaxLifeHasChanged(int bonusLife)
        {
            MaxLifeHandler handler = MaxLifeChanged;
            if (handler != null)
            {
                handler((Hero)this, bonusLife);
            }
        }

        public void heal(int healAmount)
        {
            this.ActualHitPoint += healAmount;
            if (this.ActualHitPoint > this.MaxHitPoint)
            {
                this.ActualHitPoint = this.MaxHitPoint;
            }
            lifePointHasChanged(this, healAmount);
        }
        
        public void addGold(int gold)
        {
            this.Gold += gold;
            GoldHasChanged(gold);
        }
        public void removeGold(int gold)
        {
            if ((this.Gold - gold) >= 0)
            {

                this.Gold -= gold;
                GoldHasChanged(-gold);
            }
            else
            {
                throw new NotEnoughtGoldException("Error Not Enought Gold");
            }

        }
        public void emptyGold()
        {
            int tempoGold = this.Gold;
            this.Gold = 0;
            GoldHasChanged(-tempoGold);
        }
        public void GoldHasChanged(int gold)
        {
            GoldHandler handler = GoldChanged;
            if (handler != null)
            {
                handler((Hero)this, gold);
            }
        }


        public void addCapacity(Capacity capacity)
        {
            capacities.Add(capacity);
            capacitiesHasChanged(capacity);
            if (capacity.CapacityKind == CapacityType.WeaponMastery)
            {
                while (this.WeaponMastery == WeaponTypes.None)
                {
                    this.WeaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                    WeaponMasteryHasChanged(this.WeaponMastery);
                }
            }
        }
        public void addCapacity(CapacityType capacityType)
        {
            Capacity capacity = new Capacity(capacityType);
            capacities.Add(capacity);
            capacitiesHasChanged(capacity);

            if (capacityType == CapacityType.WeaponMastery)
            {
                while (this.WeaponMastery == WeaponTypes.None)
                {
                    this.WeaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                    WeaponMasteryHasChanged(this.WeaponMastery);
                }
            }
        }
        private void WeaponMasteryHasChanged(WeaponTypes WeaponType)
        {
            WeaponMasteryHandler handler = weaponMasteryChanged;
            if (handler != null)
            {
                handler((Hero)this);
            }
        }
        public void capacitiesHasChanged(Capacity capacity)
        {
            capacitiesHandler handler = capacitiesChanged;
            if (handler != null)
            {
                handler((Hero)this, capacity);
            }
        }

        public List<SpecialItem> getSpecialItems
        {
            get { return specialItems; }
        }
        public SpecialItem getSpecialItem(SpecialItem specialItem)
        {
            foreach (SpecialItem spItem in specialItems)
            {
                if (spItem == specialItem)
                {
                    return spItem;
                }
            }
            return null;
        }
        
        public void specialItemHasChanged(SpecialItem item, bool add)
        {
            specialItemsHandler handler = specialItemsChanged;
            if (handler != null)
            {
                handler((Hero)this, item, add);
            }
        }
        public void weaponHolderHasChanged(Weapon weapon, bool add)
        {
            weaponHolderHandler handler = weaponHolderChanged;
            if (handler != null)
            {
                handler((Hero)this, weapon, add);
            }
        }
        public void backPackItemHasChanged(Item item, bool add)
        {
            backPackHandler handler = backPackChanged;
            if (handler != null)
            {
                handler((Hero)this, item, add);
            }
        }

        public void useItem(Item item)
        {
            try
            {
                item.use(this);
                backPackItemHasChanged(item, false);
            }
            catch (ItemDestroyedException)
            {
                item.remove(this);
                backPackItemHasChanged(item, false);
            }
            catch (CannotUseItemException)
            {
                throw;
            }

        }

        public void addLoot(Loot loot)
        {
            try
            {
                loot.add(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void removeLoot(Loot loot)
        {
            try
            {
                loot.remove(this);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void removeBackPack()
        {
            this.backPack.GetItems.Clear();
        }
        public void removeWeaponHolder()
        {
            this.weaponHolder.getWeapons.Clear();
        }

        public void rest()
        {
            if (this.possesCapacity(CapacityType.Healing))//Healing capacity allow you to regen when not fighting, see resolve of StoryParagraph
            {
                this.heal(healingCapacityRegen);
            }
        }
        public void eat()
        {
            if (this.HungryStatus != HungryState.Full)
            {
                this.HungryStatus = HungryState.Full;
                HungryStateHasChanged();
            }
            else
            {
                throw new CantEatException();
            }
            
        }

        public void mealTime()
        {
            if (!this.possesCapacity(CapacityType.Hunting))//Hunting capacity allow you to never have to eat when required.
            {
                if (this.HungryStatus == HungryState.Hungry)
                {
                    this.takeDamage(skipMealDamage);
                }
                this.HungryStatus = HungryState.Hungry;
                HungryStateHasChanged();
            }
            
        }
        public void HungryStateHasChanged()
        {
            HungryStateHandler handler = hungryStateChanged;
            if (handler != null)
            {
                handler(this);
            }
        }
        
        public bool possesCapacity(CapacityType capacity)
        {
            foreach (Capacity capa in this.capacities)
            {
                if (capa.CapacityKind == capacity)
                {
                    return true;
                }
            }
            return false;
        }
        public bool possesItem(String itemName)
        {
            if (possesBackPackItem(itemName) || possesSpecialItem(itemName) || possesWeapon(itemName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool possesWeapon(String itemName)
        {
            foreach (Weapon weapon in this.weaponHolder.getWeapons)
            {
                if (weapon.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }
        private bool possesBackPackItem(String itemName)
        {
            foreach (Item item in this.backPack.GetItems)
            {
                if (item.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }
        private bool possesSpecialItem(String itemName)
        {
            foreach (SpecialItem specialItem in this.getSpecialItems)
            {
                if (specialItem.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }

        public void addTempDebuff(int debuff)
        {
            this.combatDebuff += debuff;
        }
        public void removeTempDebuff()
        {
            this.combatDebuff = 0;
        }

        public bool Fight(Enemy ennemy)
        {
            int strenghtDifference = findStrenghtDifference(ennemy);
            bool battleOver = false;
            try
            {
                battleOver = resolveDamage(strenghtDifference, ennemy);
            }
            catch (YouAreDeadException)
            {
                throw;
            }

            return battleOver;
        }

        public int findStrenghtDifference(Enemy ennemy)
        {
            int heroAgility = getHeroAgilityInBattle(ennemy);
            int ennemyAgility = ennemy.BaseAgility;
            return (heroAgility - ennemyAgility);
        }

        public int getHeroAgilityInBattle(Enemy ennemy)
        {
           return this.BaseAgility+ getBonusAgility(ennemy) - getMalusAgility();
        }

        public int getBonusAgility(Enemy ennemy)
        {
            int bonusAgility = 0;
            bonusAgility += getBonusItemAgility();
            bonusAgility += getBonusCapacityAgility(ennemy);
            return bonusAgility;
        }

        private int getBonusItemAgility()
        {
            int bonusAgility = 0;
            foreach (SpecialItem combatItem in specialItems)
            {
                if (combatItem is SpecialItemCombat)
                    bonusAgility += ((SpecialItemCombat)combatItem).getAgilityBonus;
            }
            return bonusAgility;
        }

        private int getBonusCapacityAgility(Enemy ennemy)
        {
            int bonusAgility = 0;
            if (this.possesCapacity(CapacityType.WeaponMastery))
            {
                if (this.weaponHolder.Contains(this.WeaponMastery))
                {
                    bonusAgility += Capacity.weaponMasteryStrenght;
                }
            }
            if (this.possesCapacity(CapacityType.PsychicPower))
            {
                if (ennemy.isWeakToPhychic())
                {
                    bonusAgility += Capacity.phychicPowerStrenght;
                }
            }
            return bonusAgility;
        }

        private int getMalusAgility()
        {
            int malusAgility = 0;
            if (this.weaponHolder.isEmpty())
            {
                malusAgility += unharmedCombatDebuff;
            }
            malusAgility += combatDebuff;
            return malusAgility;
        }

        private bool resolveDamage(int strenghDifference, Enemy ennemy)
        {
            int randomD10 = DiceRoll.D10Roll();
            ennemy.takeDamage(DamageTable.ennemyDamageTaken(strenghDifference, randomD10));
            try
            {
                this.takeDamage(DamageTable.heroDamageTaken(strenghDifference, randomD10));
            }
            catch (YouAreDeadException)
            {
                throw;
            }
            if (ennemy.ActualHitPoint<= 0)
            {
                return true;
            }
            return false;
        }

        public void noNullInHero()
        {
            //This function must ONLY be called when loading a hero from the database, if a hero is saved while his BackPack/WeaponHolder/SpecialItems is empty, then when loading it then be equal to null instead of empty
            //So in order to make sure we don't have any null element, we check for null and incase create a new empty element.
            if (this.specialItems == null)
                this.specialItems = new List<SpecialItem>();
            if (this.capacities == null)
                this.capacities = new ObservableCollection<Capacity>();
            if (this.backPack == null)
                this.backPack = new BackPack();
            if (this.weaponHolder == null)
                this.weaponHolder = new WeaponHolder();
        }
        
        public string getResume
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
