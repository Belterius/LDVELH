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
        List<Event> Decision;
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
        List<Event> MainEvents;

        public StoryParagraph(string contentText, int paragraphNumber)
        {
            this.ContentText = contentText;
            this.ParagraphNumber = paragraphNumber;
            Decision = new List<Event>();
            MainEvents = new List<Event>();
        }

        public void AddDecision(Event decision){
            this.Decision.Add(decision);
        }
        public void AddDecision(List<Event> decision)
        {
            foreach (Event EventDecision in decision)
            {
                this.Decision.Add(EventDecision);
            }
        }
        public void AddMainEvent(Event mainEvent)
        {
            this.MainEvents.Add(mainEvent);
        }
        
        public List<Event> GetListDecision
        {
            get { return Decision; }
        }
        public void Resolve(Story story)
        {
            foreach (Event MainEvent in MainEvents)
            {
                try
                {
                    MainEvent.ResolveEvent(story);
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
            if(!MainEvents.OfType<FightEvent>().Any())
            {
                story.PlayerHero.Rest();
            }
        }
    }
}
