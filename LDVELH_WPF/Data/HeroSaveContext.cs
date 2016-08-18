namespace LDVELH_WPF
{
    using System.Data.Entity;

    public class HeroSaveContext : DbContext
    {
        public HeroSaveContext() : base("name=HeroSaveContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());

            modelBuilder.Entity<Hero>().HasOptional(p => p.weaponHolder).WithOptionalDependent().WillCascadeOnDelete(true);
            modelBuilder.Entity<Hero>().HasOptional(p => p.backPack).WithOptionalDependent().WillCascadeOnDelete(true);


        }
        //modelBuilder.Entity<Hero>().HasOptional(p => p.capacities).WithOptionalDependent().WillCascadeOnDelete(true);
        //modelBuilder.Entity<Hero>().HasOptional(p => p.specialItems).WithOptionalDependent().WillCascadeOnDelete(true);

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<Weapon> MyWeapons { get; set; }
        public DbSet<Capacity> MyCapacities { get; set; }
        public DbSet<WeaponHolder> MyWeaponHolders { get; set; }
        public DbSet<Item> MyItems { get; set; }
        public DbSet<BackPack> MyBackPack { get; set; }
        public DbSet<SpecialItem> MySpecialItem { get; set; }
        public DbSet<Hero> MyHero { get; set; }
    }
}