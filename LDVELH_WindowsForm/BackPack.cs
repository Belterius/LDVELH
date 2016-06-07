using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class BackPack
    {
        private int basicBackPackSize = 8;
        private int backPackSize;
        List<Item> Items;

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

        public void Remove(Item backPackItem)
        {
            this.Items.Remove(backPackItem);
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
