using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace LDVELH_WPF
{
    public class Story : INotifyPropertyChanged
    {
        
        Hero _PlayerHero;
        public Hero PlayerHero
        {
            get
            {
                return _PlayerHero;
            }
            set
            {
                if (_PlayerHero != value)
                {
                    _PlayerHero = value;

                    RaisePropertyChanged("PlayerHero");
                }
            }
        }
        public string Title{get;set;}
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
                    PlayerHero.CurrentParagraph = value.ParagraphNumber;
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
            this.Title = title;
            this.PlayerHero = hero;
            this.content = new ObservableCollection<StoryParagraph>();
        }

        public void ResolveActualParagraph()
        {
            try
            {
                this.ActualParagraph.Resolve(this);
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

        public void AddParagraph(StoryParagraph paragraph)
        {
            this.content.Add(paragraph);
        }

        public void Start()
        {
           SetActualParagraph(1);
        }
        public void Start(int paragraph)
        {
            SetActualParagraph(paragraph);
        }
        private void SetActualParagraph(int paragraphNumber)
        {
            try
            {
                this.ActualParagraph = GetParagraph(paragraphNumber);
            }
            catch (ParagraphNotFoundException)
            {

            }
        }
        public void Move(int paragraphNumber)
        {
            this.SetActualParagraph(paragraphNumber);
        }
        public StoryParagraph GetParagraph(int paragraphNumber)
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
