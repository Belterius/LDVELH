using LDVELH_WPF.Helpers;
using System;

namespace LDVELH_WPF.ViewModel
{
    public class FightViewModel : ViewModelBase
    {
        public event FightEnded FightEndedChanged;
        public delegate void FightEnded(object sender, EventArgs e);
        public void FightHasEnded()
        {
            FightEnded handler = FightEndedChanged;
            handler?.Invoke(this, null);
        }

        private Hero _hero;
        public Hero Hero
        {
            get
            {
                return _hero;
            }
            set
            {
                if (_hero != value)
                {
                    _hero = value;
                    RaisePropertyChanged("Hero");
                }
            }
        }

        private Enemy _enemy;
        public Enemy Enemy
        {
            get
            {
                return _enemy;
            }
            set
            {
                if (_enemy != value)
                {
                    _enemy = value;
                    RaisePropertyChanged("Enemy");
                }
            }
        }
        int _heroDamageTaken=0;
        int _heroOldHp = -1;
        public int HeroDamageTaken
        {
            get
            {
                return _heroDamageTaken;
            }
            set
            {
                if (_heroOldHp == -1)
                {
                    _heroOldHp = value;
                }
                else
                {
                    _heroDamageTaken = _heroOldHp - value;
                    _heroOldHp = value;
                }
                RaisePropertyChanged("HeroDamageTaken");
            }
        }

        private int _enemyDamageTaken = 0;
        private int _enemyOldHp = -1;
        public int EnemyDamageTaken
        {
            get
            {
                return _enemyDamageTaken;
            }
            set
            {
                if (_enemyOldHp == -1)
                {
                    _enemyOldHp = value;
                }
                else
                {
                    _enemyDamageTaken = _enemyOldHp - value;
                    _enemyOldHp = value;
                }
                RaisePropertyChanged("EnemyDamageTaken");
            }
        }

        string _escapeText = GlobalTranslator.Instance.Translator.ProvideValue("Escape");
        public string EscapeText
        {
            get
            {
                return _escapeText;
            }
            set
            {
                if (_escapeText != value)
                {
                    _escapeText = value;
                    RaisePropertyChanged("EscapeText");
                }
            }
        }
        string _nextRoundText = GlobalTranslator.Instance.Translator.ProvideValue("StartFight");
        public string NextRoundText
        {
            get
            {
                return _nextRoundText;
            }
            set
            {
                if(_nextRoundText != value)
                {
                    _nextRoundText = value;
                    RaisePropertyChanged("NextRoundText");
                }
            }
        }

        private bool _fightOver = false;
        private int _roundNumber = 0;
        public int RoundNumber
        {
            get
            {
                return _roundNumber;
            }
            set
            {
                if (_roundNumber != value)
                {
                    _roundNumber = value;
                    RaisePropertyChanged("RoundNumber");
                }
            }
        }
        int _runRoundNumber = 9999;
        public int RunRoundNumber
        {
            get
            {
                return _runRoundNumber;
            }
            set
            {
                if (_runRoundNumber != value)
                {
                    _runRoundNumber = value;
                    RaisePropertyChanged("RunRoundNumber");
                }
            }
        }
        string _roundNumberText = GlobalTranslator.Instance.Translator.ProvideValue("YouMustFight");
        public string RoundNumberText
        {
            get
            {
                return _roundNumberText;
            }
            set
            {
                if (_roundNumberText != value)
                {
                    _roundNumberText = value;
                    RaisePropertyChanged("RoundNumberText");
                }
            }
        }
        System.Windows.Visibility _canRun = System.Windows.Visibility.Hidden;
        public System.Windows.Visibility CanRun
        {
            get
            {
                return _canRun;
            }
            set
            {
                if (_canRun != value)
                {
                    _canRun = value;
                    RaisePropertyChanged("CanRun");
                }
            }
        }
        bool _ranAway = false;
        public bool RanAway
        {
            get
            {
                return _ranAway;
            }
            set
            {
                if (_ranAway != value)
                {
                    _ranAway = value;
                    RaisePropertyChanged("RanAway");
                }
            }
        }
        
        public string HeroFightAgility => Hero.GetHeroAgilityInBattle(Enemy).ToString();

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
            if (_fightOver)
            {
                FightHasEnded();
            }
            NextRoundText = GlobalTranslator.Instance.Translator.ProvideValue("NextRound");
            try
            {
                _fightOver = Hero.Fight(Enemy);
            }
            catch (YouAreDeadException)
            {
                FightHasEnded();
                throw;
            }
            if (_fightOver)
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
