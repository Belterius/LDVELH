using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public class Story 
    {
        [Key]
        public int storyID { get; set; }
        [Column("Hero")]
        Hero playerHero;
        [Column("Title")]
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
            this.actualParagraph.resolve(this);
        }

        public void addParagraph(StoryParagraph paragraph)
        {
            this.content.Add(paragraph);
        }

        public void start()
        {
           setActualParagraph(1);
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
