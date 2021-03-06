﻿using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace LDVELH_WPF
{
    /// <summary>
    /// Contain all the Paragraphs the Hero has taken
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class Story : INotifyPropertyChanged
    {
        
        Hero _playerHero;

        public Hero PlayerHero
        {
            get
            {
                return _playerHero;
            }
            set
            {
                if (_playerHero == value) return;
                _playerHero = value;

                RaisePropertyChanged("PlayerHero");
            }
        }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Title{get;set;}
        /// <summary>
        /// all the Paragraphs the Hero has taken
        /// </summary>
        public ObservableCollection<StoryParagraph> Content;
        StoryParagraph _actualParagraph;
        /// <summary>
        /// The current Paragraph the Hero is at
        /// </summary>
        public StoryParagraph ActualParagraph
        {
            get
            {
                return _actualParagraph;
            }
            set
            {
                if (_actualParagraph != value)
                {
                    _actualParagraph = value;
                    PlayerHero.CurrentParagraph = value.ParagraphNumber;
                    RaisePropertyChanged("ActualParagraph");
                }
            }
        }

        private void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Create a new Story for a Hero
        /// </summary>
        /// <param name="title">The Title of the Story</param>
        /// <param name="hero">The Player Hero</param>
        public Story(string title, Hero hero)
        {
            Title = title;
            PlayerHero = hero;
            Content = new ObservableCollection<StoryParagraph>();
        }

        /// <summary>
        /// Resolve all the Main Action from the current Paragraphs, and make all the Paragraphs's Event available to choose.
        /// </summary>
        public void ResolveActualParagraph()
        {
            try
            {
                ActualParagraph.Resolve(this);
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
        /// <summary>
        /// Add a Paragraph the List Paragraphs the Hero has visited
        /// </summary>
        /// <param name="paragraph"></param>
        public void AddParagraph(StoryParagraph paragraph)
        {
            Content.Add(paragraph);
        }

        /// <summary>
        /// Start the Story, send the Hero to the Paragraph 1
        /// </summary>
        public void Start()
        {
           SetActualParagraph(1);
        }
        /// <summary>
        /// Start the Story, send the Hero to the specified Paragraph
        /// </summary>
        /// <param name="paragraph">The Paragraph number</param>
        public void Start(int paragraph)
        {
            SetActualParagraph(paragraph);
        }
        /// <summary>
        /// Send the Hero to the specified Paragraph
        /// </summary>
        /// <param name="paragraphNumber">The Paragraph number</param>
        private void SetActualParagraph(int paragraphNumber)
        {
            try
            {
                ActualParagraph = GetParagraph(paragraphNumber);
            }
            catch (ParagraphNotFoundException)
            {

            }
        }
        /// <summary>
        /// Send the Hero to the specified Paragraph
        /// </summary>
        /// <param name="paragraphNumber">The Paragraph number</param>
        public void Move(int paragraphNumber)
        {
            SetActualParagraph(paragraphNumber);
        }
        public StoryParagraph GetParagraph(int paragraphNumber)
        {
            foreach (StoryParagraph paragraph in Content)
            {
                if (paragraph.ParagraphNumber == paragraphNumber)
                {
                    return paragraph;
                }
            }
            throw new ParagraphNotFoundException();

        }
        
    }

    /// <summary>
    /// Thrown when it's not possible to find the Paragraph corresponding to the Paragraph Number
    /// </summary>
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
