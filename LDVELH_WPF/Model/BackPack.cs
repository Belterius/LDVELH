using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace LDVELH_WPF
{
    public class BackPack : INotifyPropertyChanged
    {
        [Key]
        public int BackPackID { get; set; }


        [Column("BackPackSize")]
        private int _BackPackSize{get;set;}
        /// <summary>
        /// The number of Items the BackPack can contain
        /// </summary>
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

        ObservableCollection<Item> Items;
        /// <summary>
        /// An ObservableCollection of the BackPack's Items
        /// </summary>
        public ObservableCollection<Item> GetItems
        {
            get { return Items; }
        }

        public static readonly int BasicBackPackSize = 8;

        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Create a BackPack
        /// </summary>
        public BackPack()
        {
            this.BackPackSize = BasicBackPackSize;
            this.Items = new ObservableCollection<Item>();
        }
        /// <summary>
        /// Create a BackPack of a specified size
        /// </summary>
        /// <param name="backPackSize">The size of the BackPack</param>
        public BackPack(int backPackSize)
        {
            this.BackPackSize = backPackSize;
            this.Items = new ObservableCollection<Item>();
        }

        /// <summary>
        /// Add an item to the BackPack.
        /// <para /> Throw a BackPackFullException if the BackPack is already full
        /// </summary>
        /// <param name="backPackItem">The item to add to the BackPack</param>
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

        /// <summary>
        /// Remove an item from the BackPack
        /// </summary>
        /// <param name="backPackItem">The item to remove from the BackPack</param>
        /// <returns>True if correct, false if the item wasn't present</returns>
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
