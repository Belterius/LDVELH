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
        private string _Name { get; set; }

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
        private int _MaxHitPoint { get; set; }
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
        int _ActualHitPoint { get; set; }
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
        int _BaseAgility { get; set; }
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

        public void Kill()
        {
            this.TakeDamage(this.ActualHitPoint);
        }

        public void TakeDamage(int damage)
        {
            this.ActualHitPoint -= damage;
            if (ActualHitPoint <= 0)
            {
                ActualHitPoint = 0;
                if (this is Hero)
                {
                    throw new YouAreDeadException("You are dead");
                }
            }
        }

        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
