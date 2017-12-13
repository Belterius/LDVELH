using System;

namespace LDVELH_WPF
{

    public sealed class DiceRoll
    {
        private DiceRoll()
        {

        }
        public static DiceRoll Instance { get; } = new DiceRoll();

        public Random Random = new Random();
        /// <summary>
        /// Simulate a D6 roll
        /// </summary>
        /// <returns>a value from 1 to 6</returns>
        public static int D6Roll()
        {
            return Instance.Random.Next(1, 7);
        }
        /// <summary>
        /// Simulate a D10 roll
        /// </summary>
        /// <returns>a value from 1 to 10</returns>
        public static int D10Roll()
        {
            return Instance.Random.Next(1, 11);
        }
        /// <summary>
        /// Simulate a D10 roll with 0 as minimum, and 9 as maximum
        /// </summary>
        /// <returns>a value from 0 to 9</returns>
        public static int D10Roll0()
        {
            return Instance.Random.Next(0, 10);
        }
    }
}
