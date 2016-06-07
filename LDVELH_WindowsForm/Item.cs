using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public abstract class Loot
    {

    }
    public class Gold : Loot
    {
        int goldAmount;
        public Gold(int amount)
        {
            this.goldAmount = amount;
        }
        public int getGoldAmount
        {
            get { return this.goldAmount; }
        }
    }
    public abstract class Item : Loot
    {
        protected string name;

        public string getName
        {
            get { return name; }
        }
        public virtual string getDisplayName
        {
            get { return name; }
        }
        public abstract void use(Hero hero);
    }

    public class Consummable : Item
    {
        int healingPower;
        int chargesLeft;
        
        public Consummable(string name, int healingPower, int charges)
        {
            this.healingPower = healingPower;
            this.name = name;
            this.chargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Consummable))
                return false;


            Consummable consummable = (Consummable)obj;
            if (this.name != consummable.name)
                return false;
            if (this.chargesLeft != consummable.chargesLeft)
                return false;
            if (this.healingPower != consummable.healingPower)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
           return new { name, healingPower, chargesLeft }.GetHashCode();
        }
        public override string getDisplayName
        {
            get
            {
                if (chargesLeft > 1)
                {
                    return name + "(+" + healingPower + " life " + chargesLeft + " charges)";
                }
                else
                {
                    return name + "(+" + healingPower + " life " + chargesLeft + " charge)";
                }
            }
        }
        public override void use(Hero hero)
        {
            this.chargesLeft--;
            hero.heal(healingPower);

            if (chargesLeft <= 0)
            {
                throw new ItemDestroyedException();
            }
        }

    }

    public class Food : Item
    {
        int chargesLeft;

        public Food(string name, int charges)
        {
            this.name = name;
            this.chargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Food))
                return false;

            Food food = (Food)obj;
            if (this.name != food.name)
                return false;
            if (this.chargesLeft != food.chargesLeft)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return new { name, chargesLeft }.GetHashCode();
        }

        public override string getDisplayName
        {
            get
            {
                if (chargesLeft > 1)
                {
                    return name + "( food, " + chargesLeft + " charges)";
                }
                else
                {
                    return name + "( food" + chargesLeft + " charge)";
                }
            }
        }

        public override void use(Hero hero)
        {
            this.chargesLeft--;
            hero.eat();

            if (chargesLeft <= 0)
            {
                throw new ItemDestroyedException();
            }
        }

    }

    public class Miscellaneous : Item
    {

        public Miscellaneous(string name)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Miscellaneous))
                return false;

            Miscellaneous food = (Miscellaneous)obj;
            if (this.name != food.name)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return new {name}.GetHashCode();
        }

        public override void use(Hero hero)
        {
            throw new CannotUseItemException("You can't use this item !");
        }
    }

    [Serializable]
    public class CannotUseItemException : Exception
    {
        public CannotUseItemException()
        { }

        public CannotUseItemException(string message)
            : base(message)
        { }

        public CannotUseItemException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected CannotUseItemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }

    [Serializable]
    public class ItemDestroyedException : Exception
    {
        public ItemDestroyedException()
        { }

        public ItemDestroyedException(string message)
            : base(message)
        { }

        public ItemDestroyedException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected ItemDestroyedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }
    
}
