namespace LDVELH_WPF
{
    public static class CreateMonster
    {
        public static Enemy Bear()
        {
            return new Enemy("Bear", 12, 12, EnnemyTypes.Beast);
        }
        
    }
}
