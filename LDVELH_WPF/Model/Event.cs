﻿using System;
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
        protected bool done = false;
        public abstract void resolveEvent(Story story);
        
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
        public override void resolveEvent(Story story)
        {
            story.addParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
        public CapacityType CapacityRequiered{
            get { return capacityType; }
        }
    }
    public class LootEvent : Event
    {
        List<Loot> loot;
        bool moveAction { get; set; }

        private LootEvent()
        {
            this.loot = new List<Loot>();
        }
        public LootEvent(Loot item, string triggerMessage = "")
        {
            this.TriggerMessage = triggerMessage;
            this.loot = new List<Loot>();
            this.loot.Add(item);
        }
        public LootEvent(List<Loot> listItem, string triggerMessage = "")
        {
            this.loot = listItem;
            this.TriggerMessage = triggerMessage;
        }
        public override void resolveEvent(Story story)
        {
            if (!done)
            {
                foreach (Loot lootItem in loot)
                {
                    try
                    {
                        story.getHero.addLoot(lootItem);
                        done = true;
                    }
                    catch (BackPackFullException)
                    {
                        //TODO
                        System.Diagnostics.Debug.WriteLine("LootEvent full backpack, propose choice");
                        MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorInventoryFull"));
                    }
                    catch (WeaponHolderFullException)
                    {
                        //TODO
                        MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("ErrorWeaponHolderFull"));
                        System.Diagnostics.Debug.WriteLine("LootEvent full weapon holder, propose choice");
                    }
                }
            }
            
        }

    }
    public class BuyEvent : Event
    {
        List<Event> payableEvent;
        int price;
        private BuyEvent()
        {
            this.payableEvent = new List<Event>();
        }
        public BuyEvent(Event anEvent, int price, string triggerMessage)
        {
            this.payableEvent = new List<Event>();
            this.payableEvent.Add(anEvent);
            this.price = price;
            this.TriggerMessage = triggerMessage + " (" + price + " "+ GlobalTranslator.Instance.translator.ProvideValue("Gold")+" )";
        }
        public BuyEvent(List<Event> listEvent, int price, string triggerMessage)
        {
            this.price = price;
            this.payableEvent = listEvent;
            this.TriggerMessage = triggerMessage + " (" + price + " " + GlobalTranslator.Instance.translator.ProvideValue("Gold") + " )";
        }
        public override void resolveEvent(Story story)
        {
            try
            {
                story.getHero.removeGold(this.price);
                foreach (Event payedEvent in payableEvent)
                {
                        payedEvent.resolveEvent(story);
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
        int debuff;
        bool alwaysHappen = false;
        Item requieredItem = null;
        bool capacityRequiered = false;
        CapacityType requieredCapacity;
        public DebuffEvent(int debuff)
        {
            alwaysHappen = true;
        }
        public DebuffEvent(Item requieredItem, int debuff)
        {
            this.requieredItem = requieredItem;
            this.debuff = debuff;
        }
        public DebuffEvent(CapacityType requieredCapacity, int debuff)
        {
            this.requieredCapacity = requieredCapacity;
            this.capacityRequiered = true;
            this.debuff = debuff;
        }
        public override void resolveEvent(Story story)
        {
            if(capacityRequiered)
            {
                if (!story.getHero.possesCapacity(requieredCapacity))
                {
                    story.getHero.addTempDebuff(debuff);
                    return;
                }
            }
            if (requieredItem != null)
            {
                if (!story.getHero.possesItem(requieredItem.getName))
                {
                    story.getHero.addTempDebuff(debuff);
                    return;
                }
            }
            if (alwaysHappen)
            {
                story.getHero.addTempDebuff(debuff);
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
        public override void resolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, ennemy));
                story.getHero.removeTempDebuff();
            }
            catch (YouAreDeadException)
            {
                throw;
            }
        }
        private bool ShowMyDialogBox(Story story, Enemy ennemy)
        {

            MessageBoxFight testDialog = new MessageBoxFight(story.getHero, ennemy);

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
        int ranTurn;
        Event runEvent;

        public RunEvent(Enemy ennemy, int ranTurn, Event runEvent)
        {
            this.ennemy = ennemy;
            this.runEvent = runEvent;
            this.ranTurn = ranTurn;
        }
        public RunEvent(int destinationNumber, Enemy ennemy, int ranTurn, Event runEvent)
        {
            this.ennemy = ennemy;
            this.runEvent = runEvent;
            this.DestinationNumber = destinationNumber;
            this.ranTurn = ranTurn;
        }
        public override void resolveEvent(Story story)
        {
            try
            {
                while (!ShowMyDialogBox(story, ennemy, ranTurn, runEvent)) ;
            }
            catch (YouAreDeadException)
            {
                throw;
            }
        }
        private bool ShowMyDialogBox(Story story, Enemy ennemy, int ranTurn, Event runEvent)
        {

            MessageBoxFight testDialog = new MessageBoxFight(story.getHero, ennemy, ranTurn);

            if (testDialog.ShowDialog() == true)
            {
                if (testDialog.DidRanAway)
                {
                    story.getActualParagraph.getListDecision.Clear();
                    story.getActualParagraph.getListDecision.Add(runEvent);
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
        public override void resolveEvent(Story story)
        {
            story.addParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
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
        public override void resolveEvent(Story story)
        {
            story.getHero.mealTime();
            story.addParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
    }
    public class ItemRequieredEvent : Event
    {
        string itemName;
        private ItemRequieredEvent()
        {

        }
        public ItemRequieredEvent(int destinationNumber, string itemName)
        {
            this.DestinationNumber = destinationNumber;
            this.itemName = itemName;
            this.TriggerMessage = GlobalTranslator.Instance.translator.ProvideValue("UseItem") + itemName;
        }
        public override void resolveEvent(Story story)
        {
            story.addParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
            story.Move(this.DestinationNumber);
        }
        public string itemRequiered
        {
            get { return itemName; }
        }
    }
    public class DeathEvent : Event
    {
        string specialMessage = "";
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
            this.specialMessage = specialMessage;
        }
        public override void resolveEvent(Story story)
        {
            story.getHero.kill();
            throw new YouAreDeadException(specialMessage + GlobalTranslator.Instance.translator.ProvideValue("YouDied"));
        }
    }
    public class DammageEvent : Event
    {
        string specialMessage = "";
        int damageAmount;
        public DammageEvent(int damageAmount)
        {
            this.damageAmount = damageAmount;
        }
        public DammageEvent(string triggerMessage, int damageAmount)
        {
            this.damageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
        }
        public DammageEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.damageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
            this.specialMessage = specialMessage;
        }
        public override void resolveEvent(Story story)
        {
            if (this.specialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("TakeDamage")+ " " + specialMessage);
            story.getHero.takeDamage(damageAmount);
        }
    }
    public class DammageAgilityEvent : Event
    {
        string specialMessage = "";
        int damageAmount;
        public DammageAgilityEvent(int damageAmount)
        {
            this.damageAmount = damageAmount;
        }
        public DammageAgilityEvent(string triggerMessage, int damageAmount)
        {
            this.damageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
        }
        public DammageAgilityEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.damageAmount = damageAmount;
            this.TriggerMessage = triggerMessage;
            this.specialMessage = specialMessage;
        }
        public override void resolveEvent(Story story)
        {
            if (this.specialMessage != "")
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("DebuffAgility") +" " + specialMessage);
            story.getHero.decreaseAgility(damageAmount);
        }
    }
    public class LinkedEvent : Event
    {
        List<Event> linkedEvent;
        public LinkedEvent(int destinationNumber)
        {
            this.DestinationNumber = destinationNumber;
            linkedEvent = new List<Event>();
        }
        public LinkedEvent(int destinationNumber, string triggerMessage)
        {
            this.DestinationNumber = destinationNumber;
            this.TriggerMessage = triggerMessage;
            linkedEvent = new List<Event>();
        }
        public void addEvent(Event newEvent)
        {
            this.linkedEvent.Add(newEvent);
        }
        public override void resolveEvent(Story story)
        {
            foreach(Event linkEvent in this.linkedEvent)
            {
                linkEvent.resolveEvent(story);
            }
            story.addParagraph(CreateParagraph.CreateAParagraph(this.DestinationNumber));
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
        public override void resolveEvent(Story story)
        {
            story.getHero.removeBackPack();
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
        public override void resolveEvent(Story story)
        {
            story.getHero.removeWeaponHolder();
        }
    }

}
