using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    public abstract class Loot
    {
        [Key]
        public int LootID { get; set; }
        public abstract void add(Hero hero);
        public abstract void remove(Hero hero);

    }
    public class Gold : Loot
    {
        int goldAmount;
        private Gold()
        {

        }
        public Gold(int amount)
        {
            this.goldAmount = amount;
        }
        public int GoldAmount
        {
            get { return this.goldAmount; }
        }
        public override void add(Hero hero)
        {
            hero.addGold(this.GoldAmount);
        }
        public override void remove(Hero hero)
        {
            hero.removeGold(this.GoldAmount);
        }
    }
    public abstract class Item : Loot
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
        {
            get
            {
                return Name;
            }
        }
        public abstract void use(Hero hero);

        public override void add(Hero hero)
        {
            hero.backPack.AddItem(this);
            hero.backPackItemHasChanged(this, true);
        }
        public override void remove(Hero hero)
        {
            if (hero.backPack.RemoveItem(this))
            {
                hero.backPackItemHasChanged(this, false);
            }
        }
    }

    public class Consummable : Item
    {

        [Column]
        int healingPower{get;set;}

        [Column]
        int chargesLeft { get; set; }

        private Consummable()
        {

        }
        public Consummable(string name, int healingPower, int charges)
        {
            this.healingPower = healingPower;
            this.Name = name;
            this.chargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Consummable))
                return false;


            Consummable consummable = (Consummable)obj;
            if (this.Name != consummable.Name)
                return false;
            if (this.chargesLeft != consummable.chargesLeft)
                return false;
            if (this.healingPower != consummable.healingPower)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return new { Name, healingPower, chargesLeft }.GetHashCode();
            //return new { name, healingPower }.GetHashCode();
        }
        public override string DisplayName
        {
            get
            {
                if (chargesLeft > 1)
                {
                    return Name + "(+" + healingPower + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + chargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
                else
                {
                    return Name + "(+" + healingPower + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + chargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
            }
        }
        public override void use(Hero hero)
        {
            if(this.chargesLeft >= 1)
            {
                this.chargesLeft--;
                hero.heal(healingPower);
            }
            if (chargesLeft <= 0)
            {
                throw new ItemDestroyedException();
            }
        }

    }

    public class Food : Item
    {

        [Column]
        int chargesLeft { get; set; }
        private Food()
        {

        }
        public Food(string name, int charges)
        {
            this.Name = name;
            this.chargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Food))
                return false;

            Food food = (Food)obj;
            if (this.Name != food.Name)
                return false;
            if (this.chargesLeft != food.chargesLeft)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return new { Name, chargesLeft }.GetHashCode();
            //return new { name }.GetHashCode();
        }

        public override string DisplayName
        {
            get
            {
                if (chargesLeft > 1)
                {
                    return Name + "(" + GlobalTranslator.Instance.translator.ProvideValue("food") + ", " + chargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
                else
                {
                    return Name + "(" + GlobalTranslator.Instance.translator.ProvideValue("food") + ", " + chargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
            }
        }

        public override void use(Hero hero)
        {
            if(this.chargesLeft >= 1)
            {
                this.chargesLeft--;
                hero.eat();
            }
            if (chargesLeft <= 0)
            {
                throw new ItemDestroyedException();
            }
        }

    }

    public class Miscellaneous : Item
    {

        private Miscellaneous()
        {

        }
        public Miscellaneous(string name)
        {
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Miscellaneous))
                return false;

            Miscellaneous food = (Miscellaneous)obj;
            if (this.Name != food.Name)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return new {Name}.GetHashCode();
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
