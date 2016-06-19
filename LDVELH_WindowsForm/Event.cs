using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public abstract class Event
    {
        [Key]
        int EventID { get; set; }

        protected string triggerMessage;
        protected int destinationNumber;
        public abstract void resolveEvent(Story story);
        public string getTriggerMessage
        {
            get { return triggerMessage; }
        }
    }
    public class LootEvent : Event
    {
        List<Loot> loot;
        bool moveAction { get; set; }

        public LootEvent()
        {
            this.loot = new List<Loot>();
        }
        public LootEvent(Loot item)
        {
            this.loot = new List<Loot>();
            this.loot.Add(item);
        }
        public LootEvent(List<Loot> listItem)
        {
            this.loot = listItem;
        }
        public override void resolveEvent(Story story)
        {
            foreach (Loot lootItem in loot)
            {
                try
                {
                    story.getHero.addLoot(lootItem);
                }
                catch (BackPackFullException)
                {
                    //TODO
                    System.Diagnostics.Debug.WriteLine("LootEvent full backpack, propose choice");
                }
                catch (WeaponHolderFullException)
                {
                    //TODO
                    System.Diagnostics.Debug.WriteLine("LootEvent full weapon holder, propose choice");
                }
            }
        }

    }
    public class FightEvent : Event
    {
        Ennemy ennemy;

        public FightEvent(Ennemy ennemy)
        {
            this.ennemy = ennemy;
        }
        public FightEvent(int destinationNumber, Ennemy ennemy)
        {
            this.ennemy = ennemy;
            this.destinationNumber = destinationNumber;
        }
        public override void resolveEvent(Story story)
        {
            throw new NotImplementedException();
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
            story.Move(this.destinationNumber);
        }
    }
}
