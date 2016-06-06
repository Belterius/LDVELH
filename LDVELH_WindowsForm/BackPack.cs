using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class BackPack : List<Item>
    {
        private int basicBackPackSize = 8;
        private int backPackSize;

        public BackPack()
        {
            this.backPackSize = basicBackPackSize;
        }
        public BackPack(int backPackSize)
        {
            this.backPackSize = backPackSize;
        }

        public new void Add(Item backPackItem)
        {
            if (this.Count >= this.backPackSize)
            {
                throw new BackPackFullException("Your backpack is full, throw an item to add a new one !");
            }
            else
            {
                base.Add(backPackItem);
            }
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
