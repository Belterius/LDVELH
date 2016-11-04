using LDVELH_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace LDVELH_WPF
{
    public abstract class Event
    {
        [Key]
        int EventID { get; set; }

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
        protected bool _Done = false;
        /// <summary>
        /// If the action has already executed
        /// </summary>
        public bool Done
        {
            get
            {
                return _Done;
            }
        }
        /// <summary>
        /// Execute the Event.
        /// </summary>
        /// <param name="story">The Story to which the Event belongs to</param>
        public abstract void ResolveEvent(Story story);
        
    }
    /// <summary>
    /// An Event that require a Capacity to be available
    /// </summary>
    public class CapacityEvent : Event
    {
        CapacityType capacityType;
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
            this.DestinationNumber = destinationNumber;
            this.capacityType = capacityType;
            this.TriggerMessage = GlobalTranslator.Instance.Translator.ProvideValue("UseCapacity") + capacityType.GetTranslation();
        }
        /// <summary>
        /// Create a CapacityEvent
        /// </summary>
        /// <param name="destinationNumber">The Paragraph Number the Player will be send to</param>
        /// <param name="capacityType">The required CapacityType in order to see the Event</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public CapacityEvent(int destinationNumber, CapacityType capacityType, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.capacityType = capacityType;
            this.TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// Send the Player to the Destination Number.
        /// </summary>
        /// <param name="story">The Story to which the Event belongs to</param>
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
        /// <summary>
        /// The Capacity Type required to execute the Event
        /// </summary>
        public CapacityType CapacityRequiered{
            get { return capacityType; }
        }
    }
    /// <summary>
    /// An Event where the player get Item(s)
    /// </summary>
    public class LootEvent : Event
    {
        List<Loot> Loot;
        /// <summary>
        /// If the action will end the Paragraph (send the player to a new Paragraph) or not
        /// </summary>
        bool moveAction { get; set; }

        private LootEvent()
        {
            this.Loot = new List<Loot>();
        }
        /// <summary>
        /// Create an Event that allow the Player to get a Loot
        /// </summary>
        /// <param name="item">The Item the Player get</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public LootEvent(Loot item, string triggerMessage = "")
        {
            this.TriggerMessage = triggerMessage;
            this.Loot = new List<Loot>();
            this.Loot.Add(item);
        }
        /// <summary>
        /// Create an Event that allow the Player to get multiples Loots
        /// </summary>
        /// <param name="item">The Items the Player get</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public LootEvent(List<Loot> listItem, string triggerMessage = "")
        {
            this.Loot = listItem;
            this.TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// Give the item(s) to the players if he has enougth room
        /// </summary>
        /// <param name="story">The Story to which the Event belongs to</param>
        public override void ResolveEvent(Story story)
        {
            if (!_Done)
            {
                foreach (Loot lootItem in Loot)
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

    }
    /// <summary>
    /// An Event that require to pay to execute it
    /// </summary>
    public class BuyEvent : Event
    {
        List<Event> PayableEvent;
        int price;
        private BuyEvent()
        {
            this.PayableEvent = new List<Event>();
        }
        /// <summary>
        /// Create a Buy Event
        /// </summary>
        /// <param name="anEvent">The Event that will be executed by paying</param>
        /// <param name="price">The price to execute the Event</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public BuyEvent(Event anEvent, int price, string triggerMessage)
        {
            this.PayableEvent = new List<Event>();
            this.PayableEvent.Add(anEvent);
            this.price = price;
            this.TriggerMessage = triggerMessage + " (" + price + " "+ GlobalTranslator.Instance.Translator.ProvideValue("Gold")+" )";
        }
        /// <summary>
        /// Create a Buy Event
        /// </summary>
        /// <param name="anEvent">The Events that will be executed by paying</param>
        /// <param name="price">The price to execute the Events</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public BuyEvent(List<Event> listEvent, int price, string triggerMessage)
        {
            this.price = price;
            this.PayableEvent = listEvent;
            this.TriggerMessage = triggerMessage + " (" + price + " " + GlobalTranslator.Instance.Translator.ProvideValue("Gold") + " )";
        }
        /// <summary>
        /// Pay the price required to execute all linked Events
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            try
            {
                story.PlayerHero.RemoveGold(this.price);
                foreach (Event payedEvent in PayableEvent)
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
    /// <summary>
    /// Can add a temporary Bonus or Malus to the player Agility depending on the conditions
    /// </summary>
    public class BuffOrDebuffEvent : Event
    {
        int Debuff;
        bool AlwaysHappen = false;
        Item RequieredItem = null;
        bool CapacityRequiered = false;
        CapacityType RequieredCapacity;
        /// <summary>
        /// A BuffEvent that will always Happen
        /// </summary>
        /// <param name="debuff">The amount of Agility added (minus than 0 for a malus)</param>
        public BuffOrDebuffEvent(int debuff)
        {
            AlwaysHappen = true;
        }
        /// <summary>
        /// A BuffEvent that happen if the player posses an Item
        /// </summary>
        /// <param name="requieredItem">The item required to have the buff</param>
        /// <param name="debuff">The amount of Agility added (minus than 0 for a malus)</param>
        public BuffOrDebuffEvent(Item requieredItem, int debuff)
        {
            this.RequieredItem = requieredItem;
            this.Debuff = debuff;
        }
        /// <summary>
        /// A BuffEvent that happen if the player posses an Item
        /// </summary>
        /// <param name="requieredItem">The item required to have the buff</param>
        /// <param name="debuff">The amount of Agility added (minus than 0 for a malus)</param>
        public BuffOrDebuffEvent(CapacityType requieredCapacity, int debuff)
        {
            this.RequieredCapacity = requieredCapacity;
            this.CapacityRequiered = true;
            this.Debuff = debuff;
        }
        /// <summary>
        /// Add the bonus or malus to the Player if it meets the conditions
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            if(CapacityRequiered)
            {
                if (!story.PlayerHero.PossesCapacity(RequieredCapacity))
                {
                    story.PlayerHero.AddTempDebuff(Debuff);
                    return;
                }
            }
            if (RequieredItem != null)
            {
                if (!story.PlayerHero.PossesItem(RequieredItem.Name))
                {
                    story.PlayerHero.AddTempDebuff(Debuff);
                    return;
                }
            }
            if (AlwaysHappen)
            {
                story.PlayerHero.AddTempDebuff(Debuff);
                return;
            }
        }
    }
    /// <summary>
    /// An Event that start a Fight between the Hero and an Enemy
    /// </summary>
    public class FightEvent : Event
    {
        protected Enemy enemy;

        /// <summary>
        /// FightEvent Constructor
        /// </summary>
        public FightEvent()
        {
        }
        /// <summary>
        /// Create a FightEvent
        /// </summary>
        /// <param name="enemy">The Enemy the Hero will fight</param>
        public FightEvent(Enemy enemy)
        {
            this.enemy = enemy;
        }
        /// <summary>
        /// Start a MessageBoxFight between the Hero and an Enemy
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, enemy));
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
        private bool ShowMyDialogBox(Story story, Enemy enemy)
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
        int RanTurn;
        Event RunningEvent;

        /// <summary>
        /// A FightEvent from which the player can Run from after a number of turn, instead of fighting to death
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="ranTurn">The earliest turn the Hero can decide to Run from the fight</param>
        /// <param name="runEvent">The Event that will happen if the player Run</param>
        public RunEvent(Enemy enemy, int ranTurn, Event runEvent)
        {
            this.enemy = enemy;
            this.RunningEvent = runEvent;
            this.RanTurn = ranTurn;
        }
        /// <summary>
        /// Start a MessageBoxFight between the Hero and an Enemy
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, enemy, RanTurn, RunningEvent)) ;
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
        private bool ShowMyDialogBox(Story story, Enemy enemy, int ranTurn, Event runEvent)
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
            this.DestinationNumber = destinationNumber;
        }
        /// <summary>
        /// Send the Player to another Paragraph
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public MoveEvent(int destinationNumber, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// Send the Player to another Paragraph
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
    }
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
            this.DestinationNumber = destinationNumber;
        }
        /// <summary>
        /// An Event that require the Hero to eat to not take damage
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public MealEvent(int destinationNumber, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.TriggerMessage = triggerMessage;
        }

        /// <summary>
        /// If the Hero hasn't eaten he takes damage
        /// </summary>
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.MealTime();
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
    }
    /// <summary>
    /// An Event that require an Item to be available/executed
    /// </summary>
    public class ItemRequieredEvent : Event
    {
        string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            private set
            {
                if (_ItemName != value)
                {
                    _ItemName = value;
                }
            }
        }
        private ItemRequieredEvent()
        {

        }
        /// <summary>
        /// An Event that require an Item to be available/executed
        /// </summary>
        /// <param name="destinationNumber">The Destination Paragraph Number</param>
        /// <param name="itemName">The Name of the item required for the Event</param>
        public ItemRequieredEvent(int destinationNumber, string itemName)
        {
            this.DestinationNumber = destinationNumber;
            this.ItemName = itemName;
            this.TriggerMessage = GlobalTranslator.Instance.Translator.ProvideValue("UseItem") + itemName;
        }
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
        
    }
    /// <summary>
    /// An Event that lead to the death of the Hero
    /// </summary>
    public class DeathEvent : Event
    {
        string SpecialMessage = "";
        public DeathEvent()
        {
        }
        /// <summary>
        /// An Event that lead to the death of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public DeathEvent(string triggerMessage)
        {
            this.TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// An Event that lead to the death of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="specialMessage">A custom message displayed on death that should explain to the Hero why he died</param>
        public DeathEvent(string triggerMessage, string specialMessage)
        {
            this.TriggerMessage = triggerMessage;
            this.SpecialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.Kill();
            throw new YouAreDeadException(SpecialMessage + GlobalTranslator.Instance.Translator.ProvideValue("YouDied"));
        }
    }
    /// <summary>
    /// An Event that lead the Hero to take damages
    /// </summary>
    public class DamageEvent : Event
    {
        string SpecialMessage = "";
        int DamageAmount;
        /// <summary>
        /// An Event that lead the Hero to take damages
        /// </summary>
        /// <param name="damageAmount">The amount of damage the Hero will take</param>
        public DamageEvent(int damageAmount)
        {
            this.DamageAmount = damageAmount;
        }
        /// <summary>
        /// An Event that lead the Hero to take damages
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="damageAmount">The amount of damage the Hero will take</param>
        public DamageEvent(string triggerMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// An Event that lead the Hero to take damages
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="specialMessage">A custom message displayed that should explain to the Player why he took some damage</param>
        /// <param name="damageAmount">The amount of damage the Hero will take</param>
        public DamageEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
            this.SpecialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            if (this.SpecialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("TakeDamage")+ " " + SpecialMessage);
            story.PlayerHero.TakeDamage(DamageAmount);
        }
    }
    /// <summary>
    /// An Event that permanently decrease the Agility of the Hero
    /// </summary>
    public class DamageAgilityEvent : Event
    {
        string SpecialMessage = "";
        int DamageAmount;
        /// <summary>
        /// Permanently decrease the Agility of the Hero
        /// </summary>
        /// <param name="damageAmount">The ammount of Agility that will be retracted from the Hero total</param>
        public DamageAgilityEvent(int damageAmount)
        {
            this.DamageAmount = damageAmount;
        }
        /// <summary>
        /// Permanently decrease the Agility of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="damageAmount">The ammount of Agility that will be retracted from the Hero total</param>
        public DamageAgilityEvent(string triggerMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
        }
        /// <summary>
        /// Permanently decrease the Agility of the Hero
        /// </summary>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        /// <param name="specialMessage">A custom message displayed that should explain to the Player why he took some damage</param>
        /// <param name="damageAmount">The ammount of Agility that will be retracted from the Hero total</param>
        public DamageAgilityEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
            this.SpecialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            if (this.SpecialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("DebuffAgility") +" " + SpecialMessage);
            story.PlayerHero.DecreaseAgility(DamageAmount);
        }
    }
    /// <summary>
    /// Allow to resolve multiples events with one decision
    /// </summary>
    public class LinkedEvent : Event
    {
        List<Event> ListLinkedEvent;
        /// <summary>
        /// Resolve multiples events
        /// </summary>
        /// <param name="destinationNumber">The Paragraph Number of the Destination</param>
        /// <param name="triggerMessage">The message that will be displayed to the Player to start the event</param>
        public LinkedEvent(int destinationNumber, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.TriggerMessage = triggerMessage;
            ListLinkedEvent = new List<Event>();
        }
        /// <summary>
        /// Add a new Event that will be resolved on execution
        /// </summary>
        /// <param name="newEvent"></param>
        public void AddEvent(Event newEvent)
        {
            this.ListLinkedEvent.Add(newEvent);
        }
        /// <summary>
        /// Resolve ALL linked event, then move to the DestinationNumber
        /// </summary>
        /// <param name="story"></param>
        public override void ResolveEvent(Story story)
        {
            foreach(Event linkEvent in this.ListLinkedEvent)
            {
                linkEvent.ResolveEvent(story);
            }
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
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
            this.DestinationNumber = destinationNumber;
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
            this.DestinationNumber = destinationNumber;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.RemoveWeaponHolder();
        }
    }

}
