using System;
using System.Collections.Generic;
using System.Linq;

namespace LDVELH_WPF
{
    /// <summary>
    /// A Paragraph that contain a Text, a list of Main Event and a list of Decision
    /// </summary>
    public class StoryParagraph
    {
        /// <summary>
        /// The text that will describe what's happening to the Hero
        /// </summary>
        public string ContentText { get; private set; }

        /// <summary>
        /// A List of Events that the Player can choose to Resolve
        /// </summary>
        private readonly List<Event> _decision;

        public int ParagraphNumber { get; private set; }

        /// <summary>
        /// A List of Events that will happen as soon as the Hero reach the Paragraph
        /// </summary>
        private readonly List<Event> _mainEvents;

        /// <summary>
        /// Create a new Paragraph
        /// </summary>
        /// <param name="contentText">The text that will describe what's happening to the Hero </param>
        /// <param name="paragraphNumber">The number that will correspond to the Paragraph</param>
        public StoryParagraph(string contentText, int paragraphNumber)
        {
            ContentText = contentText;
            ParagraphNumber = paragraphNumber;
            _decision = new List<Event>();
            _mainEvents = new List<Event>();
        }

        /// <summary>
        /// Add an Event to the Paragraph that will be available for the Player to choose when reaching the Paragraph
        /// </summary>
        /// <param name="decision"></param>
        public void AddDecision(Event decision){
            _decision.Add(decision);
        }
        /// <summary>
        /// Add an Event to the Paragraph that will be resolved as soon as the Player reaches the Paragraph
        /// </summary>
        /// <param name="mainEvent"></param>
        public void AddMainEvent(Event mainEvent)
        {
            _mainEvents.Add(mainEvent);
        }
        
        public List<Event> GetListDecision => _decision;

        /// <summary>
        /// Resolve all the Paragraph Mains Events
        /// </summary>
        /// <param name="story"></param>
        public void Resolve(Story story)
        {
            foreach (Event mainEvent in _mainEvents)
            {
                try
                {
                    mainEvent.ResolveEvent(story);
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
            if(!_mainEvents.OfType<FightEvent>().Any())
            {
                story.PlayerHero.Rest();
            }
        }
    }
}
