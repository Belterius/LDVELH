using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class Hero : Character
    {
        private int gold;
        private List<Capacity> capacities;
        public BackPack backPack;
        public WeaponHolder weaponHolder;
        private List<SpecialItem> specialItems;
        private WeaponTypes weaponMastery = WeaponTypes.None;

        public Hero(string name){
            this.name = name;
            this.maxHitPoint = randMaxHitPoint();
            this.actualHitPoint = this.maxHitPoint;
            this.baseAgility = randBaseAgility();

            capacities = new List<Capacity>();
            backPack = new BackPack();
            weaponHolder = new WeaponHolder();
            specialItems = new List<SpecialItem>();
        }

        private int randMaxHitPoint()
        {
            int minimumValue = 20;
            Random random = new Random();
            return minimumValue + DiceRoll.D10Roll();
        }
        private int randBaseAgility()
        {
            int minimumValue = 10;
            Random random = new Random();
            return minimumValue + DiceRoll.D10Roll();
        }

        public int getGold()
        {
            return this.gold;
        }
        public void addGold(int gold)
        {
            this.gold += gold;
        }
        public void removeGold(int gold)
        {
            if ((this.gold - gold) >= 0)
                this.gold -= gold;
            else
                throw new NotEnoughtGoldException("You don't have enough gold !");

        }
        public void emptyGold()
        {
            this.gold = 0;
        }

        public void addCapacity(Capacity capacity)
        {
            capacities.Add(capacity);

            if (capacity.getCapacityType == CapacityType.WeaponMastery)
            {
                while (this.weaponMastery == WeaponTypes.None)
                {
                    this.weaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                }
            }
        }

        public void addCapacity(CapacityType capacityType)
        {
            Capacity capacity = new Capacity(capacityType);
            capacities.Add(capacity);

            if (capacityType == CapacityType.WeaponMastery)
            {
                while (this.weaponMastery == WeaponTypes.None)
                {
                    this.weaponMastery = GlobalFunction.RandomEnumValue<WeaponTypes>();
                }
            }
        }

        public void addSpecialItem(SpecialItem item)
        {
            this.specialItems.Add(item);
        }

        public WeaponTypes getWeaponMastery
        {
            get {return this.weaponMastery;}
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

        public void Fight(Ennemy ennemy)
        {
            int strenghtDifference = findStrenghtDifference(ennemy);
        }

        public int findStrenghtDifference(Ennemy ennemy)
        {
            int heroAgility = this.getBaseAgility() + getBonusAgility(ennemy);
            int ennemyAgility = ennemy.getBaseAgility();
            return (heroAgility - ennemyAgility);
        }

        private int getBonusAgility()
        {
            int bonusAgility = 0;
            foreach (SpecialItemCombat combatItem in specialItems)
            {
                bonusAgility += combatItem.getAgilityBonus;
            }

            if (this.possesCapacity(CapacityType.WeaponMastery))
            {
                if (this.weaponHolder.Contains(weaponMastery))
                {
                    bonusAgility += 2;
                }
            }
            return bonusAgility;

        }

        private int getBonusAgility(Ennemy ennemy)
        {
            int bonusAgility = 0;
            bonusAgility += getBonusItemAgility();
            bonusAgility += getBonusCapacityAgility(ennemy);
            return bonusAgility;
        }

        private int getBonusItemAgility()
        {
            int bonusAgility = 0;
            foreach (SpecialItemCombat combatItem in specialItems)
            {
                bonusAgility += combatItem.getAgilityBonus;
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
}
