namespace LDVELH_WPF
{
    public static class CreateLoot
    {
        public static class CreateGold
        {
            /// <summary>
            /// Create Golds.
            /// </summary>
            /// <param name="amount">The amount of Gold created</param>
            /// <returns></returns>
            public static Gold Gold(int amount)
            {
                return new Gold(amount);
            }
        }
        public static class CreateConsumable
        {
            public static Consumable MinorHealthPotion()
            {
                return new Consumable("minor health potion", 4, 3);
            }
            public static Consumable PotionDeGuerison()
            {
                return new Consumable("minor health potion", 4, 1);
            }
            public static Consumable PotionDeLampsur(int healingPower = 3, int charges = 2)
            {
                return new Consumable("potion De Lampsur", healingPower, charges);
            }
        }
        public static class CreateFood
        {
            public static Food Ration(int charges = 1)
            {
                return new Food("ration", charges);
            }
        }
        public static class CreateMiscellaneous
        {

        }
        public static class CreateWeapon
        {
            public static Weapon Sword(){
                return new Weapon("Sword", WeaponTypes.Sword);

            }
            public static Weapon Sabre()
            {
                return new Weapon("Sabre", WeaponTypes.Sabre);
            }
            public static Weapon MarteauDeGuerre()
            {
                return new Weapon("WarHammer", WeaponTypes.WarHammer);
            }
            public static Weapon Spear()
            {
                return new Weapon("Spear", WeaponTypes.Spear);
            }
            public static Weapon MasseDArme()
            {
                return new Weapon("Mace", WeaponTypes.Mace);
            }
            public static Weapon Baton()
            {
                return new Weapon("Baton", WeaponTypes.Baton);
            }
            public static Weapon Lance()
            {
                return new Weapon("Spear", WeaponTypes.Spear);
            }
            public static Weapon Glaive()
            {
                return new Weapon("TwoEdgedSword", WeaponTypes.TwoEdgedSword);
            }
            public static Weapon Hache()
            {
                return new Weapon("Axe", WeaponTypes.Axe);
            }
            public static Weapon Poignard()
            {
                return new Weapon("Dagger", WeaponTypes.Dagger);
            }
        }
        public static class CreateSpecialItem
        {
            public static SpecialItem Buckler()
            {
                return new SpecialItemCombat("Buckler", 2, 0);
            }
            public static SpecialItem ChainMail()
            {
                return new SpecialItemAlways("ChainMail", 0, 4);
            }
            public static SpecialItem Helmet()
            {
                return new SpecialItemAlways("ChainMail", 0, 2);
            }
        }
        
    }
}
