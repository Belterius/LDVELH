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
        int gold;
        List<Capacity> capacities;
        BackPack backPack;
        WeaponHolder weaponHolder;
        List<SpecialItem> specialItems;

        public Hero(string name){
            this.name = name;
            this.maxHitPoint = randMaxHitPoint();
            this.actualHitPoint = this.maxHitPoint;
            this.baseAgility = randBaseAgility();
        }

        private int randMaxHitPoint()
        {
            int minimumValue = 12;
            Random random = new Random();
            return minimumValue + DiceRoll.D6Roll() + DiceRoll.D6Roll();
        }
        private int randBaseAgility()
        {
            int minimumValue = 12;
            Random random = new Random();
            return minimumValue + DiceRoll.D6Roll();
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

        public void AddCapacity(Capacity capacity)
        {
            capacities.Add(capacity);
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
