using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    public class BackPack
    {
        [Key]
        public int BackPackID { get; set; }


        [Column]
        private int backPackSize{get;set;}

        List<Item> Items;
        public List<Item> GetItems
        {
            get { return Items; }
        }

        private int basicBackPackSize = 8;

        public BackPack()
        {
            this.backPackSize = basicBackPackSize;
            this.Items = new List<Item>();
        }
        public BackPack(int backPackSize)
        {
            this.backPackSize = backPackSize;
            this.Items = new List<Item>();
        }

        public void AddItem(Item backPackItem)
        {
            if (this.Items.Count >= this.backPackSize)
            {
                throw new BackPackFullException("Your backpack is full, throw an item to add a new one !");
            }
            else
            {
                this.Items.Add(backPackItem);
            }
        }

        public bool RemoveItem(Item backPackItem)
        {
            return this.Items.Remove(backPackItem);
        }

        

        

    }
    [Serializable]
    public class BackPackFullException : Exception
    {
        public BackPackFullException()
        { }

        public BackPackFullException(string message)
            : base(message)
        { }

        public BackPackFullException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected BackPackFullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }
}
