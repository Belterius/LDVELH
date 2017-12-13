using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LDVELH_WPF
{
    public class Character : INotifyPropertyChanged
    {
        //Basics getter and setter are REQUIRED on any property used by SQLite, else it won't be able to properly generate and update the values. 

        [Key]
        public int CharacterID { get; set; }
        [Column("Name")]
        // ReSharper disable once InconsistentNaming : Requiered for Database
        private string _Name { get; set; }
        /// <summary>
        /// The Name of the character
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        [Column("MaxHitPoint")]
        // ReSharper disable once InconsistentNaming : Requiered for Database
        private int _MaxHitPoint { get; set; }
        /// <summary>
        /// The Max Number of Health Point the character can have
        /// </summary>
        public int MaxHitPoint
        {
            get
            {
                return _MaxHitPoint;
            }
            protected set
            {
                if (_MaxHitPoint != value)
                {
                    _MaxHitPoint = value;
                    RaisePropertyChanged("MaxHitPoint");
                }
            }
        }
        [Column("ActualLife")]
        // ReSharper disable once InconsistentNaming : Requiered for Database
        int _ActualHitPoint { get; set; }
        /// <summary>
        /// The current number of HealthPoint the character have
        /// </summary>
        public int ActualHitPoint
        {
            get
            {
                return _ActualHitPoint;
            }
            protected set
            {
                if (_ActualHitPoint != value)
                {
                    _ActualHitPoint = value;
                    RaisePropertyChanged("ActualHitPoint");
                }
            }
        }
        [Column("BaseAgility")]
        // ReSharper disable once InconsistentNaming : Requiered for Database
        int _BaseAgility { get; set; }
        /// <summary>
        /// The Agility the character have, before factoring in bonuses
        /// </summary>
        public int BaseAgility
        {
            get
            {
                return _BaseAgility;
            }
            protected set
            {
                if (_BaseAgility != value)
                {
                    _BaseAgility = value;
                    RaisePropertyChanged("BaseAgility");
                }
            }
        }
        /// <summary>
        /// Kill the character
        /// </summary>
        public void Kill()
        {
            TakeDamage(ActualHitPoint);
        }

        /// <summary>
        /// Inflict an amount of damage to the character
        /// </summary>
        /// <param name="damage">The amount of damage inflicted</param>
        public void TakeDamage(int damage)
        {
            if (damage >= ActualHitPoint)
            {
                ActualHitPoint = 0;
                if (this is Hero)
                {
                    throw new YouAreDeadException("You are dead");
                }
            }
            else
            {
                ActualHitPoint -= damage;
            }
        }

        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
