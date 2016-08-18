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
        static Random random = new Random();

        public static int D6Roll()
        {
            return random.Next(1, 7);
        }

        public static int D10Roll()
        {
            return random.Next(1, 11);
        }
        public static int D10Roll0()
        {
            return random.Next(0, 10);
        }
    }
}
