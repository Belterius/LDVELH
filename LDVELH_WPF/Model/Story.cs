﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace LDVELH_WPF
{
    public class Story : INotifyPropertyChanged
    {
        
        Hero playerHero;
        public string title{get;set;}
        public ObservableCollection<StoryParagraph> content;
        StoryParagraph _ActualParagraph;
        public StoryParagraph ActualParagraph
        {
            get
            {
                return _ActualParagraph;
            }
            set
            {
                if (_ActualParagraph != value)
                {
                    _ActualParagraph = value;
                    RaisePropertyChanged("ActualParagraph");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Story(string title, Hero hero)
        {
            this.title = title;
            this.playerHero = hero;
            this.content = new ObservableCollection<StoryParagraph>();
        }

        public void resolveActualParagraph()
        {
            try
            {
                this.ActualParagraph.resolve(this);
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
                this.ActualParagraph = getParagraph(paragraphNumber);
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
                if (paragraph.ParagraphNumber == paragraphNumber)
                {
                    return paragraph;
                }
            }
            throw new ParagraphNotFoundException();

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
