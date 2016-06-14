﻿using System;
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
        [Key]
        public int ParagraphID { get; set; }
        [Column("contentText")]
        String contentText;
        List<Event> decision;
        [Column("paragraphNumber")]
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
                mainEvent.resolveEvent(story);
            }
        }
    }
}