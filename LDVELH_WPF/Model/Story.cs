﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    public class Story 
    {
        
        Hero playerHero;
        public string title{get;set;}
        public List<StoryParagraph> content;
        StoryParagraph actualParagraph;

        public event ActualParagraphHandler ParagraphChanged;
        public delegate void ActualParagraphHandler(Story story, StoryParagraph actualParagraph);

        public Story(string title, Hero hero)
        {
            this.title = title;
            this.playerHero = hero;
            this.content = new List<StoryParagraph>();
        }

        public void resolveActualParagraph()
        {
            try
            {
                this.actualParagraph.resolve(this);
            }
            catch(YouAreDeadException){
                throw;
            }
            catch (WeaponHolderFullException)
            {
                throw;
            }
            catch (BackPackFullException)
            {
                throw;
            }
        }

        public void addParagraph(StoryParagraph paragraph)
        {
            ////acting as in the book where it's possible to exploit loophole, TODO : maybe decide that it's better not to recreate a paragraph
            //StoryParagraph existingParagraph = this.content.Where(s => s.getParagraphNumber == paragraph.getParagraphNumber).FirstOrDefault();
            //this.content.Remove(existingParagraph);

            this.content.Add(paragraph);
        }

        public void start()
        {
           setActualParagraph(1);
        }
        public void start(int paragraph)
        {
            setActualParagraph(paragraph);
        }
        private void setActualParagraph(int paragraphNumber)
        {
            try
            {
                this.actualParagraph = getParagraph(paragraphNumber);
                ActualParagraphHasChanged(this.actualParagraph);
            }
            catch (ParagraphNotFoundException)
            {

            }
        }
        public void Move(int paragraphNumber)
        {
            this.setActualParagraph(paragraphNumber);
        }
        public StoryParagraph getParagraph(int paragraphNumber)
        {
            foreach (StoryParagraph paragraph in this.content)
            {
                if (paragraph.getParagraphNumber == paragraphNumber)
                {
                    return paragraph;
                }
            }
            throw new ParagraphNotFoundException();

        }
        public StoryParagraph getActualParagraph
        {
            get { return actualParagraph;}
        }
        public void ActualParagraphHasChanged(StoryParagraph paragraph)
        {
            ActualParagraphHandler handler = ParagraphChanged;
            if (handler != null)
            {
                handler(this, paragraph);
            }
        }
        public Hero getHero
        {
            get { return playerHero; }
        }
    }

    [Serializable]
    public class ParagraphNotFoundException : Exception
    {
        public ParagraphNotFoundException()
        { }

        public ParagraphNotFoundException(string message)
            : base(message)
        { }

        public ParagraphNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected ParagraphNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }
}