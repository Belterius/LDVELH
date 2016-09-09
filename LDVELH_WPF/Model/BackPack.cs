using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace LDVELH_WPF
{
    public class BackPack : INotifyPropertyChanged
    {
        [Key]
        public int BackPackID { get; set; }


        [Column("BackPackSize")]
        private int _BackPackSize{get;set;}
        public int BackPackSize
        {
            get
            {
                return _BackPackSize;
            }
            private set
            {
                if (_BackPackSize != value)
                {
                    _BackPackSize = value;
                    RaisePropertyChanged("BackPackSize");
                }
            }
        }

        List<Item> Items;
        public List<Item> GetItems
        {
            get { return Items; }
        }

        public static readonly int basicBackPackSize = 8;

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public BackPack()
        {
            this.BackPackSize = basicBackPackSize;
            this.Items = new List<Item>();
        }
        public BackPack(int backPackSize)
        {
            this.BackPackSize = backPackSize;
            this.Items = new List<Item>();
        }

        public void AddItem(Item backPackItem)
        {
            if (this.Items.Count >= this.BackPackSize)
            {
                throw new BackPackFullException("Error BackBack Full !");
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
