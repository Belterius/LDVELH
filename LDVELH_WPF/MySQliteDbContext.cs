namespace LDVELH_WPF
{
    using SQLite.CodeFirst;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;

    public class MySQLiteDBContext : DbContext
    {
        // Your context has been configured to use a 'StoryContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LDVELH_WindowsForm.StoryContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StoryContext' 
        // connection string in the application configuration file.
        public MySQLiteDBContext()
            : base("HeroSQLiteContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());

            //modelBuilder.Entity<Hero>().HasOptional(p => p.weaponHolder).WithOptionalDependent().WillCascadeOnDelete(true);
            //modelBuilder.Entity<Hero>().HasOptional(p => p.backPack).WithOptionalDependent().WillCascadeOnDelete(true);

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