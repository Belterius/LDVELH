﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public static class DiceRoll
    {
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
