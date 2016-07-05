using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LDVELH_WPF
{
    public abstract class Event
    {
        [Key]
        int EventID { get; set; }

        protected string triggerMessage;
        protected int destinationNumber;
        protected bool done = false;
        public abstract void resolveEvent(Story story);
        public string getTriggerMessage
        {
            get { return triggerMessage; }
        }
    }
    public class CapacityEvent : Event
    {
        CapacityType capacityType;
        private CapacityEvent()
        {

        }
        public CapacityEvent(int destinationNumber, CapacityType capacityType)
        {
            this.destinationNumber = destinationNumber;
            this.capacityType = capacityType;
            this.triggerMessage = "Utiliser votre capacité " + capacityType.ToString();
        }
        public CapacityEvent(int destinationNumber, CapacityType capacityType, string triggerMessage)
        {
            this.destinationNumber = destinationNumber;
            this.capacityType = capacityType;
            this.triggerMessage = triggerMessage;
        }
        public override void resolveEvent(Story story)
        {
            story.addParagraph(CreateParagraph.CreateAParagraph(this.destinationNumber));
            story.Move(this.destinationNumber);
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
            this.triggerMessage = triggerMessage;
            this.loot = new List<Loot>();
            this.loot.Add(item);
        }
        public LootEvent(List<Loot> listItem, string triggerMessage = "")
        {
            this.loot = listItem;
            this.triggerMessage = triggerMessage;
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
                        MessageBox.Show("Votre inventaire est plein ! vous devez vider un objet de votre sac avant de pouvoir récupérer un nouvel item");
                    }
                    catch (WeaponHolderFullException)
                    {
                        //TODO
                        MessageBox.Show("Votre baudrier est plein ! vous devez jeter une arme avant de pouvoir en récupérer une nouvelle");
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
            this.triggerMessage = triggerMessage + " (" + price + " golds )";
        }
        public BuyEvent(List<Event> listEvent, int price, string triggerMessage)
        {
            this.price = price;
            this.payableEvent = listEvent;
            this.triggerMessage = triggerMessage + " (" + price + " golds )";
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
                MessageBox.Show("You don't have enought gold to do that !");
            }
            catch(Exception){

            }
        }

    }
    public class FightEvent : Event
    {
        protected Ennemy ennemy;
        int debuff = 0;

        public FightEvent()
        {
        }
        public FightEvent(Ennemy ennemy)
        {
            this.ennemy = ennemy;
        }
        public FightEvent(Ennemy ennemy, int debuff)
        {
            this.ennemy = ennemy;
            this.debuff = debuff;
        }
        public override void resolveEvent(Story story)
        {
            try
            {
                story.getHero.addTempDebuff(debuff);
                while (!ShowMyDialogBox(story, ennemy));
                story.getHero.removeTempDebuff();
            }
            catch (YouAreDeadException)
            {
                throw;
            }
        }
        private bool ShowMyDialogBox(Story story, Ennemy ennemy)
        {

            MessageBoxFight testDialog = new MessageBoxFight(story.getHero, ennemy);

            if (testDialog.ShowDialog() == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show("You can't escape a fight like that !");
                return false;
            }
            

        }
    }
    public class RunEvent : FightEvent
    {
        int ranTurn;
        Event runEvent;

        public RunEvent(Ennemy ennemy, int ranTurn, Event runEvent)
        {
            this.ennemy = ennemy;
            this.runEvent = runEvent;
        }
        public RunEvent(int destinationNumber, Ennemy ennemy, int ranTurn, Event runEvent)
        {
            this.ennemy = ennemy;
            this.runEvent = runEvent;
            this.destinationNumber = destinationNumber;
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
        private bool ShowMyDialogBox(Story story, Ennemy ennemy, int ranTurn, Event runEvent)
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
                MessageBox.Show("You can't escape a fight like that !");
                return false;
            }


        }
    }
    public class MoveEvent : Event
    {
        public MoveEvent(int destinationNumber)
        {
            this.destinationNumber = destinationNumber;
        }
        public MoveEvent(int destinationNumber, string triggerMessage)
        {
            this.destinationNumber = destinationNumber;
            this.triggerMessage = triggerMessage;
        }
        public override void resolveEvent(Story story)
        {
            story.addParagraph(CreateParagraph.CreateAParagraph(this.destinationNumber));
            story.Move(this.destinationNumber);
        }
    }
    public class MealEvent : Event
    {
        public MealEvent(int destinationNumber)
        {
            this.destinationNumber = destinationNumber;
        }
        public MealEvent(int destinationNumber, string triggerMessage)
        {
            this.destinationNumber = destinationNumber;
            this.triggerMessage = triggerMessage;
        }
        public override void resolveEvent(Story story)
        {
            story.getHero.mealTime();
            story.addParagraph(CreateParagraph.CreateAParagraph(this.destinationNumber));
            story.Move(this.destinationNumber);
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
            this.destinationNumber = destinationNumber;
            this.itemName = itemName;
            this.triggerMessage = "Utiliser votre item " + itemName;
        }
        public override void resolveEvent(Story story)
        {
            story.addParagraph(CreateParagraph.CreateAParagraph(this.destinationNumber));
            story.Move(this.destinationNumber);
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
            this.triggerMessage = triggerMessage;
        }
        public DeathEvent(string triggerMessage, string specialMessage)
        {
            this.triggerMessage = triggerMessage;
            this.specialMessage = specialMessage;
        }
        public override void resolveEvent(Story story)
        {
            story.getHero.kill();
            throw new YouAreDeadException("Vous êtes mort: " + specialMessage);
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
            this.triggerMessage = triggerMessage;
        }
        public DammageEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.damageAmount = damageAmount;
            this.triggerMessage = triggerMessage;
            this.specialMessage = specialMessage;
        }
        public override void resolveEvent(Story story)
        {
            if (this.specialMessage != "")
                MessageBox.Show("Vous subissez des dégats : " + specialMessage);
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
            this.triggerMessage = triggerMessage;
        }
        public DammageAgilityEvent(string triggerMessage, string specialMessage, int damageAmount)
        {
            this.damageAmount = damageAmount;
            this.triggerMessage = triggerMessage;
            this.specialMessage = specialMessage;
        }
        public override void resolveEvent(Story story)
        {
            if (this.specialMessage != "")
                MessageBox.Show("Votre agilité est réduite : " + specialMessage);
            story.getHero.decreaseAgility(damageAmount);
        }
    }
    public class LinkedEvent : Event
    {
        List<Event> linkedEvent;
        public LinkedEvent(int destinationNumber)
        {
            this.destinationNumber = destinationNumber;
            linkedEvent = new List<Event>();
        }
        public LinkedEvent(int destinationNumber, string triggerMessage)
        {
            this.destinationNumber = destinationNumber;
            this.triggerMessage = triggerMessage;
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
            story.addParagraph(CreateParagraph.CreateAParagraph(this.destinationNumber));
            story.Move(this.destinationNumber);
        }
    }
    public class LooseBackPack : Event
    {
        public LooseBackPack()
        {
        }
        public LooseBackPack(int destinationNumber)
        {
            this.destinationNumber = destinationNumber;
        }
        public override void resolveEvent(Story story)
        {
            story.getHero.removeBackPack();
        }
    }
    public class LooseWeaponHolder : Event
    {
        public LooseWeaponHolder()
        {
        }
        public LooseWeaponHolder(int destinationNumber)
        {
            this.destinationNumber = destinationNumber;
        }
        public override void resolveEvent(Story story)
        {
            story.getHero.removeWeaponHolder();
        }
    }

}
