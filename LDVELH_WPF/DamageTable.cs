using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF
{
    class DamageTable
    {
        public static int ennemyDamageTaken(int strenghtDifference, int rollD10)
        {
            if (strenghtDifference > 0)
            {
                int damage = ((int)((strenghtDifference - 1) / 2) + 3) + rollD10;

                if (damage <= 12){
                    return damage;
                }
                else
                {
                    int bonusDamage = damage - 12;
                    int totalDamage = 12 + bonusDamage * 2;
                    if (totalDamage <= 18){
                        return totalDamage;
                    }
                    else
                    {
                        return 9999;//instant kill
                    }
                }

            }
            if (strenghtDifference == 0)
            {
                int damage = 2 + rollD10;
                return damage;

            }
            if (strenghtDifference < 0)
            {
                int damage = ((int)((strenghtDifference +1) / 2) + 1 ) + rollD10;
                if (damage <= 0){
                    return 0;
                }
                else
                {
                    return damage;
                }
            }
            throw new Exception("Error in damage table");
        }

        public static int heroDamageTaken(int strenghtDifference, int rollD10)
        {
            if(strenghtDifference >= 11){
                switch (rollD10)
                {
                    case 1:
                        return 3;
                    case 2:
                        return 2;
                    case 3:
                        return 2;
                    case 4:
                        return 2;
                    case 5:
                        return 1;
                    case 6:
                        return 1;
                    case 7:
                        return 0;
                    case 8:
                        return 0;
                    case 9:
                        return 0;
                    case 10:
                        return 0;
                    default :
                        throw new Exception("Error in damage table");

                }
            }
            
            if (strenghtDifference <= -11)
            {
                switch (rollD10)
                {
                    case 1:
                        return 9999;//instant death
                    case 2:
                        return 9999;//instant death
                    case 3:
                        return 8;
                    case 4:
                        return 8;
                    case 5:
                        return 7;
                    case 6:
                        return 6;
                    case 7:
                        return 5;
                    case 8:
                        return 4;
                    case 9:
                        return 2;
                    case 10:
                        return 1;
                    default :
                        throw new Exception("Error in damage table");

                }
            }
            switch (rollD10)
            {
                case 1 :
                    switch (strenghtDifference)
                    {
                        case -10 : case -9:
                            return 9999;//instant death
                        case -8:
                        case -7:
                            return 8;
                        case -6:
                        case -5:
                            return 6;
                        case -4:
                        case -3:
                            return 6;
                        case -2:
                        case -1:
                            return 5;
                        case 0:
                            return 5;
                        case 1:
                        case 2:
                            return 5;
                        case 3:
                        case 4:
                            return 4;
                        case 5:
                        case 6:
                            return 4;
                        case 7:
                        case 8:
                            return 4;
                        case 9:
                        case 10:
                            return 3;
                        default: 
                            throw new Exception("Error in damage table");
                    }
                case 2:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 8;
                        case -8:
                        case -7:
                            return 7;
                        case -6:
                        case -5:
                            return 6;
                        case -4:
                        case -3:
                            return 5;
                        case -2:
                        case -1:
                            return 5;
                        case 0:
                            return 4;
                        case 1:
                        case 2:
                            return 4;
                        case 3:
                        case 4:
                            return 3;
                        case 5:
                        case 6:
                            return 3;
                        case 7:
                        case 8:
                            return 3;
                        case 9:
                        case 10:
                            return 3;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 3:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 7;
                        case -8:
                        case -7:
                            return 6;
                        case -6:
                        case -5:
                            return 5;
                        case -4:
                        case -3:
                            return 5;
                        case -2:
                        case -1:
                            return 4;
                        case 0:
                            return 4;
                        case 1:
                        case 2:
                            return 3;
                        case 3:
                        case 4:
                            return 3;
                        case 5:
                        case 6:
                            return 3;
                        case 7:
                        case 8:
                            return 2;
                        case 9:
                        case 10:
                            return 2;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 4:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 7;
                        case -8:
                        case -7:
                            return 6;
                        case -6:
                        case -5:
                            return 5;
                        case -4:
                        case -3:
                            return 4;
                        case -2:
                        case -1:
                            return 4;
                        case 0:
                            return 3;
                        case 1:
                        case 2:
                            return 3;
                        case 3:
                        case 4:
                            return 2;
                        case 5:
                        case 6:
                            return 2;
                        case 7:
                        case 8:
                            return 2;
                        case 9:
                        case 10:
                            return 2;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 5:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 6;
                        case -8:
                        case -7:
                            return 5;
                        case -6:
                        case -5:
                            return 4;
                        case -4:
                        case -3:
                            return 4;
                        case -2:
                        case -1:
                            return 3;
                        case 0:
                            return 2;
                        case 1:
                        case 2:
                            return 2;
                        case 3:
                        case 4:
                            return 2;
                        case 5:
                        case 6:
                            return 2;
                        case 7:
                        case 8:
                            return 2;
                        case 9:
                        case 10:
                            return 2;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 6:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 6;
                        case -8:
                        case -7:
                            return 5;
                        case -6:
                        case -5:
                            return 4;
                        case -4:
                        case -3:
                            return 3;
                        case -2:
                        case -1:
                            return 2;
                        case 0:
                            return 2;
                        case 1:
                        case 2:
                            return 2;
                        case 3:
                        case 4:
                            return 2;
                        case 5:
                        case 6:
                            return 1;
                        case 7:
                        case 8:
                            return 1;
                        case 9:
                        case 10:
                            return 1;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 7:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 5;
                        case -8:
                        case -7:
                            return 4;
                        case -6:
                        case -5:
                            return 3;
                        case -4:
                        case -3:
                            return 2;
                        case -2:
                        case -1:
                            return 2;
                        case 0:
                            return 1;
                        case 1:
                        case 2:
                            return 1;
                        case 3:
                        case 4:
                            return 1;
                        case 5:
                        case 6:
                            return 0;
                        case 7:
                        case 8:
                            return 0;
                        case 9:
                        case 10:
                            return 0;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 8:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 4;
                        case -8:
                        case -7:
                            return 3;
                        case -6:
                        case -5:
                            return 2;
                        case -4:
                        case -3:
                            return 1;
                        case -2:
                        case -1:
                            return 1;
                        case 0:
                            return 0;
                        case 1:
                        case 2:
                            return 0;
                        case 3:
                        case 4:
                            return 0;
                        case 5:
                        case 6:
                            return 0;
                        case 7:
                        case 8:
                            return 0;
                        case 9:
                        case 10:
                            return 0;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 9:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 3;
                        case -8:
                        case -7:
                            return 2;
                        case -6:
                        case -5:
                            return 0;
                        case -4:
                        case -3:
                            return 0;
                        case -2:
                        case -1:
                            return 0;
                        case 0:
                            return 0;
                        case 1:
                        case 2:
                            return 0;
                        case 3:
                        case 4:
                            return 0;
                        case 5:
                        case 6:
                            return 0;
                        case 7:
                        case 8:
                            return 0;
                        case 9:
                        case 10:
                            return 0;
                        default:
                            throw new Exception("Error in damage table");
                    }
                case 10:
                    switch (strenghtDifference)
                    {
                        case -10:
                        case -9:
                            return 0;
                        case -8:
                        case -7:
                            return 0;
                        case -6:
                        case -5:
                            return 0;
                        case -4:
                        case -3:
                            return 0;
                        case -2:
                        case -1:
                            return 0;
                        case 0:
                            return 0;
                        case 1:
                        case 2:
                            return 0;
                        case 3:
                        case 4:
                            return 0;
                        case 5:
                        case 6:
                            return 0;
                        case 7:
                        case 8:
                            return 0;
                        case 9:
                        case 10:
                            return 0;
                        default:
                            throw new Exception("Error in damage table");
                    }
                default :
                    throw new Exception("Error in damage table");
            }
        }    
    }
}
