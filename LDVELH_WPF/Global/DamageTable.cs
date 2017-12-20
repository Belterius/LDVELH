using System;

namespace LDVELH_WPF
{
    internal static class DamageTable
    {
        //Rule of the DamageTable are corresponding to the rule in the CYOA Book Lone Wolf.
        //While it was possible to deduct some logic from the EnemyDamageTaken table, it was not possible for the HeroDamageTaken table, hence why it's arbitrary and not determined by an arithmetical function.


        /// <summary>
        /// Calculate the amount of damage the ennemy should take, corresponding to the CYOA Lone Wolf rule book
        /// </summary>
        /// <param name="strenghtDifference">The strength of the Enemy minus the Hero's</param>
        /// <param name="rollD10">The value of a D10 roll</param>
        /// <returns>the amount of damage the Enemy should take</returns>
        public static int EnemyDamageTaken(int strenghtDifference, int rollD10)
        {
            if (strenghtDifference > 0)
            {
                int damage = ((strenghtDifference - 1) / 2) + 3 + rollD10;
                if (damage <= 12){
                    return damage;
                }
                int bonusDamage = damage - 12;
                int totalDamage = 12 + bonusDamage * 2;
                return totalDamage <= 18 ? totalDamage : 9999;

            }
            if (strenghtDifference == 0)
            {
                int damage = 2 + rollD10;
                return damage;

            }
            if (strenghtDifference >= 0) throw new Exception("Error in damage table");
            {
                int damage = ((int)((strenghtDifference +1) / 2) + 1 ) + rollD10;
                return damage <= 0 ? 0 : damage;
            }
        }
        /// <summary>
        /// Calculate the amount of damage the Hero should take, corresponding to the CYOA Lone Wolf rule book
        /// </summary>
        /// <param name="strenghtDifference">The strength of the Hero minus the Enemy's</param>
        /// <param name="rollD10">The value of a D10 roll</param>
        /// <returns>the amount of damage the Hero should take</returns>
        public static int HeroDamageTaken(int strenghtDifference, int rollD10)
        {
            if(strenghtDifference >= 11){
                switch (rollD10)
                {
                    case 1:
                        return 3;
                    case 2:
                    case 3:
                    case 4:
                        return 2;
                    case 5:
                    case 6:
                        return 1;
                    case 7:
                    case 8:
                    case 9:
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
                    case 2:
                        return 9999;//instant death
                    case 3:
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
                        case -10 :
                        case -9:
                            return 9999;//instant death
                        case -8:
                        case -7:
                            return 8;
                        case -6:
                        case -5:
                        case -4:
                        case -3:
                            return 6;
                        case -2:
                        case -1:
                        case 0:
                        case 1:
                        case 2:
                            return 5;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
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
                        case -2:
                        case -1:
                            return 5;
                        case 0:
                        case 1:
                        case 2:
                            return 4;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        case -4:
                        case -3:
                            return 5;
                        case -2:
                        case -1:
                        case 0:
                            return 4;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            return 3;
                        case 7:
                        case 8:
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
                        case -2:
                        case -1:
                            return 4;
                        case 0:
                        case 1:
                        case 2:
                            return 3;
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        case -4:
                        case -3:
                            return 4;
                        case -2:
                        case -1:
                            return 3;
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            return 2;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        case -2:
                        case -1:
                            return 2;
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            return 1;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        case -2:
                        case -1:
                            return 1;
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        case -4:
                        case -3:
                        case -2:
                        case -1:
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        case -8:
                        case -7:
                        case -6:
                        case -5:
                        case -4:
                        case -3:
                        case -2:
                        case -1:
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
