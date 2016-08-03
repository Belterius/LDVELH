using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public class Hero : Character
    {
        public static readonly int skipMealDamage = 3;
        public static readonly int unharmedCombatDebuff = 4;
        public static readonly int healingCapacityRegen = 1;

        public event MaxLifeHandler MaxLifeChanged;
        public delegate void MaxLifeHandler(Hero m, int lifeChange);

        public event AgilityHandler AgilityChanged;
        public delegate void AgilityHandler(Hero m, int agilityChange);

        [Column("Gold")]
        private int gold { get; set; }
        public event GoldHandler GoldChanged;
        public delegate void GoldHandler(Hero m, int goldChange);

        public List<Capacity> capacities { get; set; }
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

        private HungryState hungryStatus;
        public event HungryStateHandler hungryStateChanged;
        public delegate void HungryStateHandler(Hero m);

        private int combatDebuff;

        [Column("Paragraph")]
        private int saveActualParagraph { get; set; }

        [Column("WeaponMastery")]
        private WeaponTypes weaponMastery { get; set; }
        public event WeaponMasteryHandler weaponMasteryChanged;
        public delegate void WeaponMasteryHandler(Hero m);

        private Hero()
        {
            //Only time we can call that is if we load a Hero from the database AND he had no SpecialItems/backpack/weaponHolder during saving
            backPack = new BackPack();
            weaponHolder = new WeaponHolder();
            specialItems = new List<SpecialItem>();
        }

        public Hero(string name)
        {
            this.name = name;
            this.maxHitPoint = randMaxHitPoint();
            this.actualHitPoint = this.maxHitPoint;
            this.baseAgility = randBaseAgility();
            this.gold = 0;
            this.saveActualParagraph = 1;
            weaponMastery = WeaponTypes.None;
            capacities = new List<Capacity>();
            backPack = new BackPack();
            weaponHolder = new WeaponHolder();
            specialItems = new List<SpecialItem>();
            hungryStatus = HungryState.Hungry;
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
            this.baseAgility += bonusAgility;
            AgilityHasChanged(bonusAgility);
        }
        internal void decreaseAgility(int bonusAgility)
        {
            this.baseAgility -= bonusAgility;
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
        private void increaseMaxLife(int bonusLife)
        {
            this.maxHitPoint += bonusLife;
            MaxLifeHasChanged(bonusLife);
        }
        private void decreaseMaxLife(int bonusLife)
        {
            this.maxHitPoint -= bonusLife;
            if (this.actualHitPoint > this.maxHitPoint)
            {
                this.actualHitPoint = this.maxHitPoint;
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
            this.actualHitPoint += healAmount;
            if (this.actualHitPoint > this.maxHitPoint)
            {
                this.actualHitPoint = this.maxHitPoint;
            }
            lifePointHasChanged(this, healAmount);
        }

        public int getGold()
        {
            return this.gold;
        }

        public void addGold(int gold)
        {
            this.gold += gold;
            GoldHasChanged(gold);
        }
        public void removeGold(int gold)
        {
            if ((this.gold - gold) >= 0)
            {

                this.gold -= gold;
                GoldHasChanged(-gold);
            }
            else
                throw new NotEnoughtGoldException("You don't have enough gold !");

        }
        public void emptyGold()
        {
            int tempoGold = this.gold;
            this.gold = 0;
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
            if (capacity.getCapacityType == CapacityType.WeaponMastery)
            {
                while (this.weaponMastery == WeaponTypes.None)
                {
                    this.weaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                    WeaponMasteryHasChanged(this.weaponMastery);
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
                while (this.weaponMastery == WeaponTypes.None)
                {
                    this.weaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                    WeaponMasteryHasChanged(this.weaponMastery);
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
        private void addSpecialItem(SpecialItem item)
        {
            this.specialItems.Add(item);
            specialItemHasChanged(item, true);

            if (item is SpecialItemAlways)
            {
                addPermanentItemEffect((SpecialItemAlways)item);
            }


        }
        private void addPermanentItemEffect(SpecialItemAlways item)
        {

            if (item.getLifeBonus > 0)
            {
                this.increaseMaxLife(item.getLifeBonus);
                this.heal(item.getLifeBonus);
            }
            if (item.getAgilityBonus > 0)
            {
                this.increaseAgility(item.getAgilityBonus);
            }
        }
        private void removeSpecialItem(SpecialItem item)
        {
            if (this.specialItems.Remove(item))
            {
                specialItemHasChanged(item, false);
                if (item is SpecialItemAlways)
                {
                    removePermanentItemEffect((SpecialItemAlways)item);
                }
            }

        }
        private void removePermanentItemEffect(SpecialItemAlways item)
        {

            if (item.getLifeBonus > 0)
            {
                this.decreaseMaxLife(item.getLifeBonus);
            }
            if (item.getAgilityBonus > 0)
            {
                this.decreaseAgility(item.getAgilityBonus);
            }
        }
        public void specialItemHasChanged(SpecialItem item, bool add)
        {
            specialItemsHandler handler = specialItemsChanged;
            if (handler != null)
            {
                handler((Hero)this, item, add);
            }
        }

        private void addWeapon(Weapon weapon)
        {
            this.weaponHolder.Add(weapon);
            weaponHolderHasChanged(weapon, true);
        }
        private void removeWeapon(Weapon weapon)
        {
            this.weaponHolder.Remove(weapon);
            weaponHolderHasChanged(weapon, false);
        }
        public void weaponHolderHasChanged(Weapon weapon, bool add)
        {
            weaponHolderHandler handler = weaponHolderChanged;
            if (handler != null)
            {
                handler((Hero)this, weapon, add);
            }
        }

        private void addBackPackItem(Item item)
        {
            this.backPack.Add(item);
            backPackItemHasChanged(item, true);
        }
        private bool removeBackPackItem(Item item)
        {
            if (this.backPack.Remove(item))
            {
                backPackItemHasChanged(item, false);
                return true;
            }
            else
                return false;
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
                this.removeBackPackItem(item);
                backPackItemHasChanged(item, false);
            }
            catch (CannotUseItemException)
            {
                throw;
            }

        }

        public void addLoot(Loot loot)
        {
            if (loot is Weapon)
            {
                this.addWeapon((Weapon)loot);
                return;
            }
            if (loot is Item)
            {
                this.addBackPackItem((Item)loot);
                return;
            }
            if (loot is SpecialItem)
            {
                this.addSpecialItem((SpecialItem)loot);
                return;
            }
            if (loot is Gold)
            {
                this.addGold(((Gold)loot).getGoldAmount);
            }
        }

        public void removeLoot(Loot loot)
        {
            if (loot is Weapon)
            {
                this.removeWeapon((Weapon)loot);
                return;
            }
            if (loot is Item)
            {
                this.removeBackPackItem((Item)loot);
                return;
            }
            if (loot is SpecialItem)
            {
                this.removeSpecialItem((SpecialItem)loot);
            }
            if (loot is Gold)
            {
                this.removeGold(((Gold)loot).getGoldAmount);
            }
        }
        public void removeBackPack()
        {
            this.backPack.getItems.Clear();
        }
        public void removeWeaponHolder()
        {
            this.weaponHolder.getWeapons.Clear();
        }

        public void rest()
        {
            if (!this.possesCapacity(CapacityType.Healing))//Healing capacity allow you to regen when not fighting, see resolve of StoryParagraph
            {
                this.heal(healingCapacityRegen);
            }
        }
        public void eat()
        {
            this.hungryStatus = HungryState.Full;
            HungryStateHasChanged();
        }

        public void mealTime()
        {
            if (!this.possesCapacity(CapacityType.Hunting))//Hunting capacity allow you to never have to eat when required.
            {
                if (this.getHungryState == HungryState.Hungry)
                {
                    this.takeDamage(skipMealDamage);
                }
                this.hungryStatus = HungryState.Hungry;
                HungryStateHasChanged();
            }
            
        }
        public HungryState getHungryState
        {
            get
            {
                return this.hungryStatus;
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



        public WeaponTypes getWeaponMastery
        {
            get { return this.weaponMastery; }
        }

        public bool possesCapacity(CapacityType capacity)
        {
            foreach (Capacity capa in this.capacities)
            {
                if (capa.getCapacityType == capacity)
                {
                    return true;
                }
            }
            return false;
        }
        public bool possesItem(String itemName)
        {
            foreach (Weapon weapon in this.weaponHolder.getWeapons)
            {
                if (weapon.getName == itemName)
                {
                    return true;
                }
            }
            foreach (Item item in this.backPack.getItems)
            {
                if (item.getName == itemName)
                {
                    return true;
                }
            }
            foreach (SpecialItem specialItem in this.getSpecialItems)
            {
                if (specialItem.getName == itemName)
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

        public bool Fight(Ennemy ennemy)
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

        public int findStrenghtDifference(Ennemy ennemy)
        {
            int heroAgility = getHeroAgilityInBattle(ennemy);
            int ennemyAgility = ennemy.getBaseAgility();
            return (heroAgility - ennemyAgility);
        }

        public int getHeroAgilityInBattle(Ennemy ennemy)
        {
           return this.getBaseAgility() + getBonusAgility(ennemy) - getMalusAgility();
        }

        public int getBonusAgility(Ennemy ennemy)
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

        private int getBonusCapacityAgility(Ennemy ennemy)
        {
            int bonusAgility = 0;
            if (this.possesCapacity(CapacityType.WeaponMastery))
            {
                if (this.weaponHolder.Contains(this.weaponMastery))
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

        private bool resolveDamage(int strenghDifference, Ennemy ennemy)
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
            if (ennemy.getActualHitPoint() <= 0)
            {
                return true;
            }
            return false;
        }

        public void noNullInHero()
        {
            if (this.specialItems == null)
                this.specialItems = new List<SpecialItem>();
            if (this.capacities == null)
                this.capacities = new List<Capacity>();
            if (this.backPack == null)
                this.backPack = new BackPack();
            if (this.weaponHolder == null)
                this.weaponHolder = new WeaponHolder();
        }

        public void setActualParagraph(int actualParagraph)
        {
            this.saveActualParagraph = actualParagraph;
        }
        public int getActualParagraph()
        {
            return this.saveActualParagraph;
        }

        public string getResume
        {
            get { return this.name + " ( Paragraph : " + this.saveActualParagraph + " )"; }
        }

        public enum HungryState
        {
            Full,
            Hungry
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
