namespace LDVELH_WPF
{
    using SQLite.CodeFirst;
    using System.Data.Entity;

    public class MySQLiteDBContext : DbContext
    {
        public MySQLiteDBContext()
            : base("HeroSQLiteContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MySQLiteDBContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);


        }

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