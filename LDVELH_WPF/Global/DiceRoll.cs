using System;

namespace LDVELH_WPF
{

    public sealed class DiceRoll
    {
        static readonly DiceRoll INSTANCE = new DiceRoll();
        private DiceRoll()
        {

        }
        public static DiceRoll Instance
        {
            get
            {
                return INSTANCE;
            }
        }
        public Random random = new Random();

        public static int D6Roll()
        {
            return Instance.random.Next(1, 7);
        }

        public static int D10Roll()
        {
            return Instance.random.Next(1, 11);
        }
        public static int D10Roll0()
        {
            return Instance.random.Next(0, 10);
        }
    }
}
