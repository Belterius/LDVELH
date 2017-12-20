using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    /// <summary>
    /// Any kind of stuff the Hero can get
    /// </summary>
    public abstract class Loot 
    {
        [Key]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        public int LootID { get; set; }


        public abstract void Add(Hero hero);
        public abstract void Remove(Hero hero);

    }
    /// <inheritdoc />
    /// <summary>
    /// Single currency, used to buy stuff/pay for some special action or event
    /// </summary>
    public class Gold : Loot
    {
        public int GoldAmount { get; private set; }

        private Gold()
        {

        }
        public Gold(int amount)
        {
            GoldAmount = amount;
        }
        
        /// <summary>
        /// Add the Gold amount to the Hero
        /// </summary>
        /// <param name="hero">The Hero that will receive the gold</param>
        public override void Add(Hero hero)
        {
            hero.AddGold(GoldAmount);
        }
        /// <summary>
        /// Remove the Gold amount from the Hero
        /// </summary>
        /// <param name="hero">The Hero that will lose the gold</param>
        public override void Remove(Hero hero)
        {
            hero.RemoveGold(GoldAmount);
        }
    }
    /// <summary>
    /// An Item can only go into the Hero BackPack and take a spot.
    /// <para />Posses a name, base class for every kind of loot appart from Gold
    /// </summary>
    public abstract class Item : Loot, INotifyPropertyChanged
    {
        

        [Column("Name")]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public virtual string DisplayName => Name;
        public abstract void Use(Hero hero);

        public override void Add(Hero hero)
        {
            hero.BackPack.AddItem(this);
        }
        public override void Remove(Hero hero)
        {
            hero.BackPack.RemoveItem(this);
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// An Item than can be used, posses a number of charge left, and an effect, for now only healing effect but could implements more sub-class
    /// </summary>
    public class Consumable : Item
    {

        [Column("HealingPower")]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        int _HealingPower { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
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
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        int _ChargesLeft { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
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

        
        private Consumable()
        {

        }
        /// <summary>
        /// Create a Consumable
        /// </summary>
        /// <param name="name">The name of the Consumable</param>
        /// <param name="healingPower">The amount of Health that will be restored on use</param>
        /// <param name="charges">The number of time the Item can be used before destruction</param>
        public Consumable(string name, int healingPower, int charges)
        {
            HealingPower = healingPower;
            Name = name;
            ChargesLeft = charges;
        }

        /// <summary>
        /// For two Consumables to be equal they need to have the same Name, ChargesLeft and HealingPower
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Consumable))
                return false;


            Consumable consumable = (Consumable)obj;
            if (Name != consumable.Name)
                return false;
            if (ChargesLeft != consumable.ChargesLeft)
                return false;
            return HealingPower == consumable.HealingPower;
        }
        public override int GetHashCode()
        {
            return new { Name, HealingPower }.GetHashCode();
        }

        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                if (ChargesLeft > 1)
                {
                    return Name + "(+" + HealingPower + " " + GlobalTranslator.Instance.Translator.ProvideValue("HP") + " " + ChargesLeft + " " + GlobalTranslator.Instance.Translator.ProvideValue("charges") + " )";
                }
                else
                {
                    return Name + "(+" + HealingPower + " " + GlobalTranslator.Instance.Translator.ProvideValue("HP") + " " + ChargesLeft + " " + GlobalTranslator.Instance.Translator.ProvideValue("charges") + " )";
                }
            }
        }
        /// <summary>
        /// Remove a Charge from the Consumable in order to restaure Health
        /// <para />If the number of Charge reach 0, the Item is destroyed
        /// </summary>
        /// <param name="hero"></param>
        public override void Use(Hero hero)
        {
            if(ChargesLeft >= 1)
            {
                ChargesLeft--;
                hero.Heal(HealingPower);
            }
            if (ChargesLeft <= 0)
            {
                throw new ItemDestroyedException();
            }
        }

    }
    /// <summary>
    /// Item that's used to change the Satiety level from Hungry to Full
    /// It can be used as many time as it's ChargesLeft number, before being destroyed
    /// </summary>
    public class Food : Item
    {

        [Column("ChargesLeft")]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        private int _ChargesLeft { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
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
        /// <summary>
        /// Create a Food item, used to set the Satiety level to Full
        /// </summary>
        /// <param name="name">The Name of the item</param>
        /// <param name="charges">The number of time it can be used before destruction</param>
        public Food(string name, int charges)
        {
            Name = name;
            ChargesLeft = charges;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Food))
                return false;

            Food food = (Food)obj;
            if (Name != food.Name)
                return false;
            if (ChargesLeft != food.ChargesLeft)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return new { Name }.GetHashCode();
        }

        public override string DisplayName
        {//If changing the name make sure to change the string too as the ItemSources must be passed by a string
            get
            {
                if (ChargesLeft > 1)
                {
                    return Name + "(" + GlobalTranslator.Instance.Translator.ProvideValue("food") + ", " + ChargesLeft + " " + GlobalTranslator.Instance.Translator.ProvideValue("charges") + " )";
                }
                else
                {
                    return Name + "(" + GlobalTranslator.Instance.Translator.ProvideValue("food") + ", " + ChargesLeft + " " + GlobalTranslator.Instance.Translator.ProvideValue("charges") + " )";
                }
            }
        }
        /// <summary>
        /// Remove a Charge from the Food in order to increase the Satiety status to Full
        /// <para />If the number of Charge reach 0, the Item is destroyed
        /// </summary>
        /// <param name="hero"></param>
        public override void Use(Hero hero)
        {
            if(ChargesLeft >= 1)
            {
                ChargesLeft--;
                hero.Eat();
            }
            if (ChargesLeft <= 0)
            {
                throw new ItemDestroyedException();
            }
        }

    }

    /// <summary>
    /// Any random Item that still take a spot in the Hero BackPack.
    /// Cannot be used unless there's a specific Event checking for it
    /// </summary>
    public class Miscellaneous : Item
    {

        private Miscellaneous()
        {

        }
        public Miscellaneous(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Miscellaneous))
                return false;

            Miscellaneous food = (Miscellaneous)obj;
            if (Name != food.Name)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return new {Name}.GetHashCode();
        }

        public override void Use(Hero hero)
        {
            throw new CannotUseItemException(GlobalTranslator.Instance.Translator.ProvideValue("ErrorUseItem"));
        }
    }

    /// <summary>
    /// Thrown when the Player try to use an Item in the wrong conditions
    /// </summary>
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

    /// <summary>
    /// Thrown when an Item number of ChargesLeft reach 0
    /// </summary>
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
