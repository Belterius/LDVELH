using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    public static class CreateMonster
    {
        public static Ennemy Bear()
        {
            return new Ennemy("Bear", 12, 12, EnnemyTypes.Beast);
        }
        
    }
}
