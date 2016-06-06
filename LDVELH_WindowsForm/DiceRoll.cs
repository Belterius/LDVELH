using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public static class DiceRoll
    {
        public static int D6Roll()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public static int D10Roll()
        {
            Random random = new Random();
            return random.Next(1, 11);
        }
    }
}
