using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF.ViewModel
{
    public class FightViewModel : ViewModelBase
    {
        public event FightEnded FightEndedChanged;
        public delegate void FightEnded();
        public void FightHasEnded()
        {
            FightEnded Handler = FightEndedChanged;
            if (Handler != null)
            {
                Handler();
            }
        }
        Hero _Hero;
        public Hero Hero
        {
            get
            {
                return _Hero;
            }
            set
            {
                if (_Hero != value)
                {
                    _Hero = value;
                    RaisePropertyChanged("Hero");
                }
            }
        }
        Enemy _Enemy;
        public Enemy Enemy
        {
            get
            {
                return _Enemy;
            }
            set
            {
                if (_Enemy != value)
                {
                    _Enemy = value;
                    RaisePropertyChanged("Enemy");
                }
            }
        }
        int _HeroDamageTaken=0;
        int _HeroOldHP = -1;
        public int HeroDamageTaken
        {
            get
            {
                return _HeroDamageTaken;
            }
            set
            {
                if (_HeroOldHP == -1)
                {
                    _HeroOldHP = value;
                }
                else
                {
                    _HeroDamageTaken = _HeroOldHP - value;
                    _HeroOldHP = value;
                }
                RaisePropertyChanged("HeroDamageTaken");
            }
        }
        int _EnemyDamageTaken = 0;
        int _EnemyOldHP = -1;
        public int EnemyDamageTaken
        {
            get
            {
                return _EnemyDamageTaken;
            }
            set
            {
                if (_EnemyOldHP == -1)
                {
                    _EnemyOldHP = value;
                }
                else
                {
                    _EnemyDamageTaken = _EnemyOldHP - value;
                    _EnemyOldHP = value;
                }
                RaisePropertyChanged("EnemyDamageTaken");
            }
        }

        string _EscapeText = GlobalTranslator.Instance.Translator.ProvideValue("Escape");
        public string EscapeText
        {
            get
            {
                return _EscapeText;
            }
            set
            {
                if (_EscapeText != value)
                {
                    _EscapeText = value;
                    RaisePropertyChanged("EscapeText");
                }
            }
        }
        string _NextRoundText = GlobalTranslator.Instance.Translator.ProvideValue("StartFight");
        public string NextRoundText
        {
            get
            {
                return _NextRoundText;
            }
            set
            {
                if(_NextRoundText != value)
                {
                    _NextRoundText = value;
                    RaisePropertyChanged("NextRoundText");
                }
            }
        }
        bool FightOver = false;
        int _RoundNumber = 0;
        public int RoundNumber
        {
            get
            {
                return _RoundNumber;
            }
            set
            {
                if (_RoundNumber != value)
                {
                    _RoundNumber = value;
                    RaisePropertyChanged("RoundNumber");
                }
            }
        }
        int _RunRoundNumber = 9999;
        public int RunRoundNumber
        {
            get
            {
                return _RunRoundNumber;
            }
            set
            {
                if (_RunRoundNumber != value)
                {
                    _RunRoundNumber = value;
                    RaisePropertyChanged("RunRoundNumber");
                }
            }
        }
        string _RoundNumberText = GlobalTranslator.Instance.Translator.ProvideValue("YouMustFight");
        public string RoundNumberText
        {
            get
            {
                return _RoundNumberText;
            }
            set
            {
                if (_RoundNumberText != value)
                {
                    _RoundNumberText = value;
                    RaisePropertyChanged("RoundNumberText");
                }
            }
        }
        System.Windows.Visibility _CanRun = System.Windows.Visibility.Hidden;
        public System.Windows.Visibility CanRun
        {
            get
            {
                return _CanRun;
            }
            set
            {
                if (_CanRun != value)
                {
                    _CanRun = value;
                    RaisePropertyChanged("CanRun");
                }
            }
        }
        bool _RanAway = false;
        public bool RanAway
        {
            get
            {
                return _RanAway;
            }
            set
            {
                if (_RanAway != value)
                {
                    _RanAway = value;
                    RaisePropertyChanged("RanAway");
                }
            }
        }
        
        public string HeroFightAgility
        {
            get
            {
                return Hero.GetHeroAgilityInBattle(Enemy).ToString();
            }
        }
       
        public FightViewModel(Hero hero, Enemy enemy)
        {
            Hero = hero;
            Enemy = enemy;
            Initialize();
        }
        public FightViewModel(Hero hero, Enemy enemy, int runTurn)
        {
            Hero = hero;
            Enemy = enemy;
            RunRoundNumber = runTurn;
            Initialize();
            
        }
        private void Initialize()
        {
            EnemyDamageTaken = Enemy.ActualHitPoint;
            HeroDamageTaken = Hero.ActualHitPoint;
            Hero.PropertyChanged += Hero_PropertyChanged;
            Enemy.PropertyChanged += Enemy_PropertyChanged;
            RunCommand = new RelayCommand(Run);
            NextRoundCommand = new RelayCommand(NextRound);
        }
        public RelayCommand NextRoundCommand { get; set; }
        public RelayCommand RunCommand { get; set; }
        private void Enemy_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName== "ActualHitPoint")
            {
                EnemyDamageTaken = Enemy.ActualHitPoint;
            }
        }

        private void Hero_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ActualHitPoint")
            {
                HeroDamageTaken = Hero.ActualHitPoint;
            }
        }


        private void NextRound(object e)
        {
            if (FightOver)
            {
                FightHasEnded();
            }
            NextRoundText = GlobalTranslator.Instance.Translator.ProvideValue("NextRound");
            try
            {
                FightOver = Hero.Fight(Enemy);
            }
            catch (YouAreDeadException)
            {
                FightHasEnded();
                throw;
            }
            if (FightOver)
            {
                NextRoundText = GlobalTranslator.Instance.Translator.ProvideValue("Victory") + " !";
                RoundNumberText = GlobalTranslator.Instance.Translator.ProvideValue("Victory").ToUpper() + "!";
            }
            else
            {
                RoundNumber++;
                RoundNumberText = GlobalTranslator.Instance.Translator.ProvideValue("RoundNumber") + " " + RoundNumber;
            }
            if (RoundNumber >= RunRoundNumber)
            {
                CanRun = System.Windows.Visibility.Visible;
            }
        }

        private void Run(object e)
        {
            RanAway = true;
            FightHasEnded();
        }
    }
}
