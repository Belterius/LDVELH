using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WindowsForm
{
    public class Ennemy : Character
    {
        private EnnemyTypes ClassType;

        public Ennemy(String name, int agility, int hitPoint,EnnemyTypes ennemyType)
        {
            this.name = name;
            this.baseAgility = agility;
            this.actualHitPoint = hitPoint;
            this.maxHitPoint = hitPoint;
            this.ClassType = ennemyType;
        }

        public bool isWeakToPhychic(){
            if (ClassType == EnnemyTypes.Human || ClassType == EnnemyTypes.Beast)
            {
                return true;
            }
            return false;
        }
    }

    public enum EnnemyTypes
    {
        Human,
        Beast,
        Orc
    }
}
