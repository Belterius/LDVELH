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
        /// <summary>
        /// Simulate a D6 roll
        /// </summary>
        /// <returns>a value from 1 to 6</returns>
        public static int D6Roll()
        {
            return Instance.random.Next(1, 7);
        }
        /// <summary>
        /// Simulate a D10 roll
        /// </summary>
        /// <returns>a value from 1 to 10</returns>
        public static int D10Roll()
        {
            return Instance.random.Next(1, 11);
        }
        /// <summary>
        /// Simulate a D10 roll with 0 as minimum, and 9 as maximum
        /// </summary>
        /// <returns>a value from 0 to 9</returns>
        public static int D10Roll0()
        {
            return Instance.random.Next(0, 10);
        }
    }
}
