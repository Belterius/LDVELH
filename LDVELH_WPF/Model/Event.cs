using LDVELH_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace LDVELH_WPF
{
    /// <summary>
    /// Something that will happen to the Hero
    /// </summary>
    public abstract class Event
    {
        [Key]
        // ReSharper disable once InconsistentNaming : DO NOT CHANGE required for Database
        private int EventID { get; set; }

        // ReSharper disable once InconsistentNaming : Requiered for the Database
        // ReSharper disable once MemberCanBePrivate.Global
        protected string _TriggerMessage;
        /// <summary>
        /// The message that will be displayed to the Player to start the event
        /// </summary>
        public string TriggerMessage
        {
            get
            {
                return _TriggerMessage;
            }
            protected set
            {
                if (_TriggerMessage != value)
                {
                    _TriggerMessage = value;
                }
            }
        }

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBePrivate.Global
        protected int _DestinationNumber;
        /// <summary>
        /// The Paragraph Number the Player will be send to
        /// </summary>
        public int DestinationNumber
        {
            get
            {
                return _DestinationNumber;
            }
            protected set
            {
                if (_DestinationNumber != value)
                {
                    _DestinationNumber = value;
                }
            }
        }
        // ReSharper disable once InconsistentNaming
        protected bool _Done = false;
        /// <summary>
        /// If the action has already executed
        /// </summary>
        public bool Done => _Done;

        /// <summary>
        /// Execute the Event.
        /// </summary>
        /// <param name="story">The Story to which the Event belongs to</param>
        public abstract void ResolveEvent(Story story);
        
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that require a Capacity to be available
    /// </summary>
    public class CapacityEvent : Event
    {
        private readonly CapacityType _capacityType;
        private CapacityEvent()
        {

        }
        /// <summary>
        /// Create a CapacityEvent
        /// </summary>
        /// <param name="destinationNumber">The Paragraph Number the Player will be send to</param>
        /// <param name="capacityType">The required CapacityType in order to see the Event</param>
        public CapacityEvent(int destinationNumber, CapacityType capacityType)
        {
            DestinationNumber = destinationNumber;
            _capacityType = capacityType;
            TriggerMessage = GlobalTranslator.Instance.Translator.ProvideValue("UseCapacity") + capacityType.GetTranslation();
        }
        /// <summary>
        /// Create a CapacityEvent
        /// </summary>
        /// <param name="destinationNumber">The Paragraph Number the Player will be send to</param>
        /// <param name="capacityType">The required CapacityType in order to see the Event</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public CapacityEvent(int destinationNumber, CapacityType capacityType, string triggerMessage)
        {
            DestinationNumber = destinationNumber;
            _capacityType = capacityType;
            TriggerMessage = triggerMessage;
        }
        /// <inheritdoc />
        /// <summary>
        /// Send the Player to the Destination Number.
        /// </summary>
        /// <param name="story">The Story to which the Event belongs to</param>
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(DestinationNumber));
            story.Move(DestinationNumber);
        }
        /// <summary>
        /// The Capacity Type required to execute the Event
        /// </summary>
        public CapacityType CapacityRequiered => _capacityType;
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event where the player get Item(s)
    /// </summary>
    public class LootEvent : Event
    {
        private readonly List<Loot> _loot;

        private LootEvent()
        {
            _loot = new List<Loot>();
        }
        /// <summary>
        /// Create an Event that allow the Player to get a Loot
        /// </summary>
        /// <param name="item">The Item the Player get</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public LootEvent(Loot item, string triggerMessage = "")
        {
            TriggerMessage = triggerMessage;
            _loot = new List<Loot> {item};
        }

        /// <summary>
        /// Create an Event that allow the Player to get multiples Loots
        /// </summary>
        /// <param name="listItem"></param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public LootEvent(List<Loot> listItem, string triggerMessage = "")
        {
            _loot = listItem;
            TriggerMessage = triggerMessage;
        }
        /// <inheritdoc />
        /// <summary>
        /// Give the item(s) to the players if he has enougth room
        /// </summary>
        /// <param name="story">The Story to which the Event belongs to</param>
        public override void ResolveEvent(Story story)
        {
            if (_Done) return;
            foreach (Loot lootItem in _loot)
            {
                try
                {
                    story.PlayerHero.AddLoot(lootItem);
                    _Done = true;
                }
                catch (BackPackFullException)
                {
                    System.Diagnostics.Debug.WriteLine("LootEvent full backpack");
                    MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("ErrorInventoryFull"));
                }
                catch (WeaponHolderFullException)
                {
                    MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("ErrorWeaponHolderFull"));
                    System.Diagnostics.Debug.WriteLine("LootEvent full weapon holder");
                }
            }
        }

    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that require to pay to execute it
    /// </summary>
    public class BuyEvent : Event
    {
        private readonly List<Event> _payableEvent;
        private readonly int _price;
        private BuyEvent()
        {
            _payableEvent = new List<Event>();
        }
        /// <summary>
        /// Create a Buy Event
        /// </summary>
        /// <param name="anEvent">The Event that will be executed by paying</param>
        /// <param name="price">The price to execute the Event</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public BuyEvent(Event anEvent, int price, string triggerMessage)
        {
            _payableEvent = new List<Event> {anEvent};
            _price = price;
            TriggerMessage = triggerMessage + " (" + price + " "+ GlobalTranslator.Instance.Translator.ProvideValue("Gold")+" )";
        }

        /// <summary>
        /// Create a Buy Event
        /// </summary>
        /// <param name="listEvent"></param>
        /// <param name="price">The price to execute the Events</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public BuyEvent(List<Event> listEvent, int price, string triggerMessage)
        {
            _price = price;
            _payableEvent = listEvent;
            TriggerMessage = triggerMessage + " (" + price + " " + GlobalTranslator.Instance.Translator.ProvideValue("Gold") + " )";
        }
        /// <inheritdoc />
        /// <summary>
        /// Pay the price required to execute all linked Events
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            try
            {
                story.PlayerHero.RemoveGold(_price);
                foreach (Event payedEvent in _payableEvent)
                {
                        payedEvent.ResolveEvent(story);
                }

            }
            catch(NotEnoughtGoldException){
                MessageBox.Show( GlobalTranslator.Instance.Translator.ProvideValue("ErrorNotEnoughtGold"));
            }
            catch(Exception){
                throw;
            }
        }

    }
    /// <inheritdoc />
    /// <summary>
    /// Can add a temporary Bonus or Malus to the player Agility depending on the conditions
    /// </summary>
    public class BuffOrDebuffEvent : Event
    {
        private readonly int _debuff;
        private readonly bool _alwaysHappen = false;
        private readonly Item _requiredItem = null;
        private readonly bool _capacityRequiered = false;
        private readonly CapacityType _requiredCapacity;
        /// <summary>
        /// A BuffEvent that will always Happen
        /// </summary>
        /// <param name="debuff">The amount of Agility added (minus than 0 for a malus)</param>
        public BuffOrDebuffEvent(int debuff)
        {
            _alwaysHappen = true;
        }
        /// <summary>
        /// A BuffEvent that happen if the player posses an Item
        /// </summary>
        /// <param name="requiredItem">The item required to have the buff</param>
        /// <param name="debuff">The amount of Agility added (minus than 0 for a malus)</param>
        public BuffOrDebuffEvent(Item requiredItem, int debuff)
        {
            _requiredItem = requiredItem;
            _debuff = debuff;
        }

        /// <summary>
        /// A BuffEvent that happen if the player posses an Item
        /// </summary>
        /// <param name="requiredCapacity"></param>
        /// <param name="debuff">The amount of Agility added (minus than 0 for a malus)</param>
        public BuffOrDebuffEvent(CapacityType requiredCapacity, int debuff)
        {
            _requiredCapacity = requiredCapacity;
            _capacityRequiered = true;
            _debuff = debuff;
        }
        /// <inheritdoc />
        /// <summary>
        /// Add the bonus or malus to the Player if it meets the conditions
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            if(_capacityRequiered)
            {
                if (!story.PlayerHero.PossesCapacity(_requiredCapacity))
                {
                    story.PlayerHero.AddTempDebuff(_debuff);
                    return;
                }
            }
            if (_requiredItem != null)
            {
                if (!story.PlayerHero.PossesItem(_requiredItem.Name))
                {
                    story.PlayerHero.AddTempDebuff(_debuff);
                    return;
                }
            }
            if (!_alwaysHappen) return;
            story.PlayerHero.AddTempDebuff(_debuff);
            return;
        }
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that start a Fight between the Hero and an Enemy
    /// </summary>
    public class FightEvent : Event
    {
        protected Enemy Enemy;

        /// <summary>
        /// FightEvent Constructor
        /// </summary>
        // ReSharper disable once MemberCanBeProtected.Global
        public FightEvent()
        {
        }
        /// <summary>
        /// Create a FightEvent
        /// </summary>
        /// <param name="enemy">The Enemy the Hero will fight</param>
        public FightEvent(Enemy enemy)
        {
            Enemy = enemy;
        }
        /// <inheritdoc />
        /// <summary>
        /// Start a MessageBoxFight between the Hero and an Enemy
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, Enemy))
                {
                }
                story.PlayerHero.RemoveTempDebuff();
            }
            catch (YouAreDeadException)
            {
                throw;
            }
        }
        /// <summary>
        /// Pop a Window to take care of the fight between the Hero and the Enemy
        /// </summary>
        /// <param name="story"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        private static bool ShowMyDialogBox(Story story, Enemy enemy)
        {

            MessageBoxFight testDialog = new MessageBoxFight() { DataContext = new FightViewModel(story.PlayerHero, enemy)};

            if (testDialog.ShowDialog() == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("ErrorEscape"));
                return false;
            }
            

        }
    }
    /// <summary>
    /// A FightEvent from which the player can Run from after a number of turn, instead of fighting to death
    /// </summary>
    public class RunEvent : FightEvent
    {
        private readonly int _ranTurn;
        private readonly Event _runningEvent;

        /// <inheritdoc />
        /// <summary>
        /// A FightEvent from which the player can Run from after a number of turn, instead of fighting to death
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="ranTurn">The earliest turn the Hero can decide to Run from the fight</param>
        /// <param name="runEvent">The Event that will happen if the player Run</param>
        public RunEvent(Enemy enemy, int ranTurn, Event runEvent)
        {
            Enemy = enemy;
            _runningEvent = runEvent;
            _ranTurn = ranTurn;
        }
        /// <inheritdoc />
        /// <summary>
        /// Start a MessageBoxFight between the Hero and an Enemy
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, Enemy, _ranTurn, _runningEvent))
                {
                }
            }
            catch (YouAreDeadException)
            {
                throw;
            }
        }
        /// <summary>
        /// Pop a Window to take care of the fight between the Hero and the Enemy
        /// </summary>
        /// <param name="story"></param>
        /// <param name="enemy"></param>
        /// <param name="ranTurn">The earliest turn the Hero can decide to Run from the fight</param>
        /// <param name="runEvent">The Event that will happen if the player Run</param>
        /// <returns></returns>
        private static bool ShowMyDialogBox(Story story, Enemy enemy, int ranTurn, Event runEvent)
        {

            MessageBoxFight testDialog = new MessageBoxFight() { DataContext = new FightViewModel(story.PlayerHero, enemy, ranTurn) };

            if (testDialog.ShowDialog() == true)
            {
                if (((FightViewModel)testDialog.DataContext).RanAway)
                {
                    story.ActualParagraph.GetListDecision.Clear();
                    story.ActualParagraph.GetListDecision.Add(runEvent);
                }
                return true;
            }
            else
            {
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("ErrorEscape"));
                return false;
            }


        }
    }
    /// <inheritdoc />
    /// <summary>
    /// Send the Player to another Paragraph
    /// </summary>
    public class MoveEvent : Event
    {
        /// <summary>
        /// Send the Player to another Paragraph
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        public MoveEvent(int destinationNumber)
        {
            DestinationNumber = destinationNumber;
        }
        /// <summary>
        /// Send the Player to another Paragraph
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public MoveEvent(int destinationNumber, string triggerMessage)
        {
            DestinationNumber = destinationNumber;
            TriggerMessage = triggerMessage;
        }
        /// <inheritdoc />
        /// <summary>
        /// Send the Player to another Paragraph
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(DestinationNumber));
            story.Move(DestinationNumber);
        }
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that require the Hero to eat to not take damage
    /// </summary>
    public class MealEvent : Event
    {
        /// <summary>
        /// An Event that require the Hero to eat to not take damage
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        public MealEvent(int destinationNumber)
        {
            DestinationNumber = destinationNumber;
        }
        /// <summary>
        /// An Event that require the Hero to eat to not take damage
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public MealEvent(int destinationNumber, string triggerMessage)
        {
            DestinationNumber = destinationNumber;
            TriggerMessage = triggerMessage;
        }

        /// <inheritdoc />
        /// <summary>
        /// If the Hero hasn't eaten he takes damage
        /// </summary>
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.MealTime();
            story.AddParagraph(CreateParagraph.CreateAParagraph(DestinationNumber));
            story.Move(DestinationNumber);
        }
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that require an Item to be available/executed
    /// </summary>
    public class ItemRequiredEvent : Event
    {
        private string _itemName;
        public string ItemName
        {
            get { return _itemName; }
            private set
            {
                if (_itemName != null && _itemName != value)
                {
                    _itemName = value;
                }
            }
        }
        private ItemRequiredEvent()
        {

        }
        /// <summary>
        /// An Event that require an Item to be available/executed
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        /// <param name="itemName">The Name of the item required for the Event</param>
        public ItemRequiredEvent(int destinationNumber, string itemName)
        {
            DestinationNumber = destinationNumber;
            ItemName = itemName;
            TriggerMessage = GlobalTranslator.Instance.Translator.ProvideValue("UseItem") + itemName;
        }
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(DestinationNumber));
            story.Move(DestinationNumber);
        }
        
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that lead to the death of the Hero
    /// </summary>
    public class DeathEvent : Event
    {
        private readonly string _specialMessage = "";
        public DeathEvent()
        {
        }
        /// <summary>
        /// An Event that lead to the death of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public DeathEvent(string triggerMessage)
        {
            TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// An Event that lead to the death of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="specialMessage">A custom message displayed on death that should explain to the Hero why he died</param>
        public DeathEvent(string triggerMessage, string specialMessage)
        {
            TriggerMessage = triggerMessage;
            _specialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.Kill();
            throw new YouAreDeadException(_specialMessage + GlobalTranslator.Instance.Translator.ProvideValue("YouDied"));
        }
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that lead the Hero to take damages
    /// </summary>
    public class DamageEvent : Event
    {
        private readonly string _specialMessage = "";
        private readonly int _damageAmount;
        /// <summary>
        /// An Event that lead the Hero to take damages
        /// </summary>
        /// <param name="damageAmount">The amount of damage the Hero will take</param>
        public DamageEvent(int damageAmount)
        {
            _damageAmount = damageAmount;
        }
        /// <summary>
        /// An Event that lead the Hero to take damages
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="damageAmount">The amount of damage the Hero will take</param>
        public DamageEvent(string triggerMessage, int damageAmount)
        {
            _damageAmount = damageAmount;
            TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// An Event that lead the Hero to take damages
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="specialMessage">A custom message displayed that should explain to the Player why he took some damage</param>
        /// <param name="damageAmount">The amount of damage the Hero will take</param>
        public DamageEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            _damageAmount = damageAmount;
            TriggerMessage = triggerMessage;
            _specialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            if (_specialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("TakeDamage")+ " " + _specialMessage);
            story.PlayerHero.TakeDamage(_damageAmount);
        }
    }
    /// <inheritdoc />
    /// <summary>
    /// An Event that permanently decrease the Agility of the Hero
    /// </summary>
    public class DamageAgilityEvent : Event
    {
        private readonly string _specialMessage = "";
        private readonly int _damageAmount;
        /// <summary>
        /// Permanently decrease the Agility of the Hero
        /// </summary>
        /// <param name="damageAmount">The ammount of Agility that will be retracted from the Hero total</param>
        public DamageAgilityEvent(int damageAmount)
        {
            _damageAmount = damageAmount;
        }
        /// <summary>
        /// Permanently decrease the Agility of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="damageAmount">The ammount of Agility that will be retracted from the Hero total</param>
        public DamageAgilityEvent(string triggerMessage, int damageAmount)
        {
            _damageAmount = damageAmount;
            TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// Permanently decrease the Agility of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="specialMessage">A custom message displayed that should explain to the Player why he took some damage</param>
        /// <param name="damageAmount">The ammount of Agility that will be retracted from the Hero total</param>
        public DamageAgilityEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            _damageAmount = damageAmount;
            TriggerMessage = triggerMessage;
            _specialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            if (_specialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("DebuffAgility") +" " + _specialMessage);
            story.PlayerHero.DecreaseAgility(_damageAmount);
        }
    }
    /// <inheritdoc />
    /// <summary>
    /// Allow to resolve multiples events with one decision
    /// </summary>
    public class LinkedEvent : Event
    {
        private readonly List<Event> _listLinkedEvent;
        /// <summary>
        /// Resolve multiples events
        /// </summary>
        /// <param name="destinationNumber">The Paragraph Number of the Destination</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public LinkedEvent(int destinationNumber, string triggerMessage)
        {
            DestinationNumber = destinationNumber;
            TriggerMessage = triggerMessage;
            _listLinkedEvent = new List<Event>();
        }
        /// <summary>
        /// Add a new Event that will be resolved on execution
        /// </summary>
        /// <param name="newEvent"></param>
        public void AddEvent(Event newEvent)
        {
            _listLinkedEvent.Add(newEvent);
        }
        /// <summary>
        /// Resolve ALL linked event, then move to the DestinationNumber
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            foreach(Event linkEvent in _listLinkedEvent)
            {
                linkEvent.ResolveEvent(story);
            }
            story.AddParagraph(CreateParagraph.CreateAParagraph(DestinationNumber));
            story.Move(DestinationNumber);
        }
    }
    /// <summary>
    /// An event in which the Hero lose his BackPack and its content
    /// </summary>
    public class LoseBackPack : Event
    {
        /// <summary>
        /// An event in which the Hero lose his BackPack and its content
        /// </summary>
        public LoseBackPack()
        {
        }
        /// <summary>
        /// An event in which the Hero lose his BackPack and its content
        /// </summary>
        public LoseBackPack(int destinationNumber)
        {
            DestinationNumber = destinationNumber;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.RemoveBackPack();
        }
    }
    /// <summary>
    /// An Event in which the Hero lose his WeaponHolder and its content
    /// </summary>
    public class LoseWeaponHolder : Event
    {
        /// <summary>
        /// An Event in which the Hero lose his WeaponHolder and its content
        /// </summary>
        public LoseWeaponHolder()
        {
        }
        /// <summary>
        /// An Event in which the Hero lose his WeaponHolder and its content
        /// </summary>
        public LoseWeaponHolder(int destinationNumber)
        {
            DestinationNumber = destinationNumber;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.RemoveWeaponHolder();
        }
    }

}
