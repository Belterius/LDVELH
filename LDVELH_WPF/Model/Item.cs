using System;
using System.ComponentModel;
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
    public abstract class Item : Loot, INotifyPropertyChanged
    {
        

        [Column("Name")]
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public virtual string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
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

        [Column("HealingPower")]
        int _HealingPower { get; set; }
        public int HealingPower
        {
            get
            {
                return _HealingPower;
            }
            set
            {
                if (_HealingPower != value)
                {
                    _HealingPower = value;
                    RaisePropertyChanged("HealingPower");
                }
            }
        }

        [Column("ChargesLeft")]
        int _ChargesLeft { get; set; }
        public int ChargesLeft
        {
            get
            {
                return _ChargesLeft;
            }
            protected set
            {
                if (_ChargesLeft != value)
                {
                    _ChargesLeft = value;
                    RaisePropertyChanged("ChargesLeft");
                    RaisePropertyChanged("DisplayName");
                }
            }
        }

        
        private Consummable()
        {

        }
        public Consummable(string name, int healingPower, int charges)
        {
            this.HealingPower = healingPower;
            this.Name = name;
            this.ChargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Consummable))
                return false;


            Consummable consummable = (Consummable)obj;
            if (this.Name != consummable.Name)
                return false;
            if (this.ChargesLeft != consummable.ChargesLeft)
                return false;
            if (this.HealingPower != consummable.HealingPower)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            //return new { Name, healingPower, chargesLeft }.GetHashCode();
            return new { Name, HealingPower }.GetHashCode();
        }

        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                if (ChargesLeft > 1)
                {
                    return Name + "(+" + HealingPower + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + ChargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
                else
                {
                    return Name + "(+" + HealingPower + " " + GlobalTranslator.Instance.translator.ProvideValue("HP") + " " + ChargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
            }
        }
        public override void use(Hero hero)
        {
            if(this.ChargesLeft >= 1)
            {
                this.ChargesLeft--;
                hero.heal(HealingPower);
            }
            if (ChargesLeft <= 0)
            {
                throw new ItemDestroyedException();
            }
        }

    }

    public class Food : Item
    {

        [Column("ChargesLeft")]
        int _ChargesLeft { get; set; }
        public int ChargesLeft
        {
            get
            {
                return _ChargesLeft;
            }
            protected set
            {
                if (_ChargesLeft != value)
                {
                    _ChargesLeft = value;
                    RaisePropertyChanged("DisplayName");
                    RaisePropertyChanged("ChargesLeft");
                }
            }
        }
        private Food()
        {

        }
        public Food(string name, int charges)
        {
            this.Name = name;
            this.ChargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Food))
                return false;

            Food food = (Food)obj;
            if (this.Name != food.Name)
                return false;
            if (this.ChargesLeft != food.ChargesLeft)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            //return new { Name, chargesLeft }.GetHashCode();
            return new { Name }.GetHashCode();
        }

        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                if (ChargesLeft > 1)
                {
                    return Name + "(" + GlobalTranslator.Instance.translator.ProvideValue("food") + ", " + ChargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
                else
                {
                    return Name + "(" + GlobalTranslator.Instance.translator.ProvideValue("food") + ", " + ChargesLeft + " " + GlobalTranslator.Instance.translator.ProvideValue("charges") + " )";
                }
            }
        }

        public override void use(Hero hero)
        {
            if(this.ChargesLeft >= 1)
            {
                this.ChargesLeft--;
                hero.eat();
            }
            if (ChargesLeft <= 0)
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
