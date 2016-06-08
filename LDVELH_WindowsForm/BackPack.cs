using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class BackPack
    {
        [Key]
        public int BackPackID { get; set; }
        [Column("BackPackSize")]
        private int backPackSize;
        public List<Item> Items;

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

        public void Add(Item backPackItem)
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

        public bool Remove(Item backPackItem)
        {
            return this.Items.Remove(backPackItem);
        }

        public List<Item> getItems
        {
            get { return Items; }
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
