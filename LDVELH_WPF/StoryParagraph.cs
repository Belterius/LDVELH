using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public class StoryParagraph
    {
        String contentText;
        List<Event> decision;
        int paragraphNumber;
        List<Event> mainEvents;

        public StoryParagraph(string contentText, int paragraphNumber)
        {
            this.contentText = contentText;
            this.paragraphNumber = paragraphNumber;
            decision = new List<Event>();
            mainEvents = new List<Event>();
        }

        public void addDecision(Event decision){
            this.decision.Add(decision);
        }
        public void addDecision(List<Event> decision)
        {
            foreach (Event eventDecision in decision)
            {
                this.decision.Add(eventDecision);
            }
        }
        public void addMainEvent(Event mainEvent)
        {
            this.mainEvents.Add(mainEvent);
        }
        public int getParagraphNumber
        {
            get { return paragraphNumber; }
        }
        public string getContent
        {
            get { return contentText; }
        }
        public List<Event> getListDecision
        {
            get { return decision; }
        }
        public void resolve(Story story)
        {
            foreach (Event mainEvent in mainEvents)
            {
                try
                {
                    mainEvent.resolveEvent(story);
                }
                catch(YouAreDeadException)
                {
                    throw;
                }
                catch (WeaponHolderFullException)
                {
                    //TODO
                    throw;
                }
                catch(BackPackFullException)
                {
                    //TODO
                    throw;
                }
            }
            if(!mainEvents.OfType<FightEvent>().Any())
            {
                story.getHero.rest();
            }
        }
    }
}
