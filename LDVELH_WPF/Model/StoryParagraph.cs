using System;
using System.Collections.Generic;
using System.Linq;

namespace LDVELH_WPF
{
    public class StoryParagraph
    {
        String _ContentText;
        public string ContentText
        {
            get
            {
                return _ContentText;
            }
            private set
            {
                if (_ContentText != value)
                {
                    _ContentText = value;
                }
            }
        }
        List<Event> decision;
        int _ParagraphNumber;
        public int ParagraphNumber
        {
            get
            {
                return _ParagraphNumber;
            }
            private set
            {
                if (_ParagraphNumber != value)
                {
                    _ParagraphNumber = value;
                }
            }
        }
        List<Event> mainEvents;

        public StoryParagraph(string contentText, int paragraphNumber)
        {
            this.ContentText = contentText;
            this.ParagraphNumber = paragraphNumber;
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
                    throw;
                }
                catch(BackPackFullException)
                {
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
