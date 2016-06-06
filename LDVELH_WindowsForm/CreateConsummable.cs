using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public static class CreateConsummable
    {
        public static Consummable minorHealthPotion()
        {
            return new Consummable("minor health potion", 4, 3);
        }
    }
}
