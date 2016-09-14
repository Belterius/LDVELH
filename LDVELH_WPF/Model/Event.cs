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
        public bool Done
        {
            get
            {
                return _Done;
            }
        }
        public abstract void ResolveEvent(Story story);
        
    }
    public class CapacityEvent : Event
    {
        CapacityType capacityType;
        private CapacityEvent()
        {

        }
        public CapacityEvent(int destinationNumber, CapacityType capacityType)
        {
            this.DestinationNumber = destinationNumber;
            this.capacityType = capacityType;
            this.TriggerMessage = GlobalTranslator.Instance.translator.ProvideValue("UseCapacity") + capacityType.GetTranslation();
        }
        public CapacityEvent(int destinationNumber, CapacityType capacityType, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.capacityType = capacityType;
            this.TriggerMessage = triggerMessage;
        }
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
        public CapacityType CapacityRequiered{
            get { return capacityType; }
        }
    }
    public class LootEvent : Event
    {
        List<Loot> Loot;
        bool moveAction { get; set; }

        private LootEvent()
        {
            this.Loot = new List<Loot>();
        }
        public LootEvent(Loot item, string triggerMessage = "")
        {
            this.TriggerMessage = triggerMessage;
            this.Loot = new List<Loot>();
            this.Loot.Add(item);
        }
        public LootEvent(List<Loot> listItem, string triggerMessage = "")
        {
            this.Loot = listItem;
            this.TriggerMessage = triggerMessage;
        }
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
                        System.Diagnostics.Debug.WriteLine("LootEvent full backpack, propose choice");
                        MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorInventoryFull"));
                    }
                    catch (WeaponHolderFullException)
                    {
                        MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorWeaponHolderFull"));
                        System.Diagnostics.Debug.WriteLine("LootEvent full weapon holder, propose choice");
                    }
                }
            }
            
        }

    }
    public class BuyEvent : Event
    {
        List<Event> PayableEvent;
        int price;
        private BuyEvent()
        {
            this.PayableEvent = new List<Event>();
        }
        public BuyEvent(Event anEvent, int price, string triggerMessage)
        {
            this.PayableEvent = new List<Event>();
            this.PayableEvent.Add(anEvent);
            this.price = price;
            this.TriggerMessage = triggerMessage + " (" + price + " "+ GlobalTranslator.Instance.translator.ProvideValue("Gold")+" )";
        }
        public BuyEvent(List<Event> listEvent, int price, string triggerMessage)
        {
            this.price = price;
            this.PayableEvent = listEvent;
            this.TriggerMessage = triggerMessage + " (" + price + " " + GlobalTranslator.Instance.translator.ProvideValue("Gold") + " )";
        }
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
                MessageBox.Show( GlobalTranslator.Instance.translator.ProvideValue("ErrorNotEnoughtGold"));
            }
            catch(Exception){
                throw;
            }
        }

    }
    public class DebuffEvent : Event
    {
        int Debuff;
        bool AlwaysHappen = false;
        Item RequieredItem = null;
        bool CapacityRequiered = false;
        CapacityType RequieredCapacity;
        public DebuffEvent(int debuff)
        {
            AlwaysHappen = true;
        }
        public DebuffEvent(Item requieredItem, int debuff)
        {
            this.RequieredItem = requieredItem;
            this.Debuff = debuff;
        }
        public DebuffEvent(CapacityType requieredCapacity, int debuff)
        {
            this.RequieredCapacity = requieredCapacity;
            this.CapacityRequiered = true;
            this.Debuff = debuff;
        }
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
    public class FightEvent : Event
    {
        protected Enemy ennemy;

        public FightEvent()
        {
        }
        public FightEvent(Enemy ennemy)
        {
            this.ennemy = ennemy;
        }
        public override void ResolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, ennemy));
                story.PlayerHero.RemoveTempDebuff();
            }
            catch (YouAreDeadException)
            {
                throw;
            }
        }
        private bool ShowMyDialogBox(Story story, Enemy ennemy)
        {

            MessageBoxFight testDialog = new MessageBoxFight(story.PlayerHero, ennemy);

            if (testDialog.ShowDialog() == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorEscape"));
                return false;
            }
            

        }
    }
    public class RunEvent : FightEvent
    {
        int RanTurn;
        Event RunningEvent;

        public RunEvent(Enemy ennemy, int ranTurn, Event runEvent)
        {
            this.ennemy = ennemy;
            this.RunningEvent = runEvent;
            this.RanTurn = ranTurn;
        }
        public RunEvent(int destinationNumber, Enemy ennemy, int ranTurn, Event runEvent)
        {
            this.ennemy = ennemy;
            this.RunningEvent = runEvent;
            this.DestinationNumber = destinationNumber;
            this.RanTurn = ranTurn;
        }
        public override void ResolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, ennemy, RanTurn, RunningEvent)) ;
            }
            catch (YouAreDeadException)
            {
                throw;
            }
        }
        private bool ShowMyDialogBox(Story story, Enemy ennemy, int ranTurn, Event runEvent)
        {

            MessageBoxFight testDialog = new MessageBoxFight(story.PlayerHero, ennemy, ranTurn);

            if (testDialog.ShowDialog() == true)
            {
                if (testDialog.DidRanAway)
                {
                    story.ActualParagraph.GetListDecision.Clear();
                    story.ActualParagraph.GetListDecision.Add(runEvent);
                }
                return true;
            }
            else
            {
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorEscape"));
                return false;
            }


        }
    }
    public class MoveEvent : Event
    {
        public MoveEvent(int destinationNumber)
        {
            this.DestinationNumber = destinationNumber;
        }
        public MoveEvent(int destinationNumber, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.TriggerMessage = triggerMessage;
        }
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
    }
    public class MealEvent : Event
    {
        public MealEvent(int destinationNumber)
        {
            this.DestinationNumber = destinationNumber;
        }
        public MealEvent(int destinationNumber, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.TriggerMessage = triggerMessage;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.MealTime();
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
    }
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
        public ItemRequieredEvent(int destinationNumber, string itemName)
        {
            this.DestinationNumber = destinationNumber;
            this.ItemName = itemName;
            this.TriggerMessage = GlobalTranslator.Instance.translator.ProvideValue("UseItem") + itemName;
        }
        public override void ResolveEvent(Story story)
        {
            story.AddParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
        
    }
    public class DeathEvent : Event
    {
        string SpecialMessage = "";
        public DeathEvent()
        {
        }
        public DeathEvent(string triggerMessage)
        {
            this.TriggerMessage = triggerMessage;
        }
        public DeathEvent(string triggerMessage, string specialMessage)
        {
            this.TriggerMessage = triggerMessage;
            this.SpecialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.Kill();
            throw new YouAreDeadException(SpecialMessage + GlobalTranslator.Instance.translator.ProvideValue("YouDied"));
        }
    }
    public class DammageEvent : Event
    {
        string SpecialMessage = "";
        int DamageAmount;
        public DammageEvent(int damageAmount)
        {
            this.DamageAmount = damageAmount;
        }
        public DammageEvent(string triggerMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
        }
        public DammageEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
            this.SpecialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            if (this.SpecialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("TakeDamage")+ " " + SpecialMessage);
            story.PlayerHero.TakeDamage(DamageAmount);
        }
    }
    public class DammageAgilityEvent : Event
    {
        string SpecialMessage = "";
        int DamageAmount;
        public DammageAgilityEvent(int damageAmount)
        {
            this.DamageAmount = damageAmount;
        }
        public DammageAgilityEvent(string triggerMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
        }
        public DammageAgilityEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.DamageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
            this.SpecialMessage = specialMessage;
        }
        public override void ResolveEvent(Story story)
        {
            if (this.SpecialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("DebuffAgility") +" " + SpecialMessage);
            story.PlayerHero.DecreaseAgility(DamageAmount);
        }
    }
    public class LinkedEvent : Event
    {
        List<Event> ListLinkedEvent;
        public LinkedEvent(int destinationNumber)
        {
            this.DestinationNumber = destinationNumber;
            ListLinkedEvent = new List<Event>();
        }
        public LinkedEvent(int destinationNumber, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.TriggerMessage = triggerMessage;
            ListLinkedEvent = new List<Event>();
        }
        public void AddEvent(Event newEvent)
        {
            this.ListLinkedEvent.Add(newEvent);
        }
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
    public class LoseBackPack : Event
    {
        public LoseBackPack()
        {
        }
        public LoseBackPack(int destinationNumber)
        {
            this.DestinationNumber = destinationNumber;
        }
        public override void ResolveEvent(Story story)
        {
            story.PlayerHero.RemoveBackPack();
        }
    }
    public class LoseWeaponHolder : Event
    {
        public LoseWeaponHolder()
        {
        }
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
