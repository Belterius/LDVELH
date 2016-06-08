namespace LDVELH_WindowsForm
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoryContext : DbContext
    {
        // Your context has been configured to use a 'StoryContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LDVELH_WindowsForm.StoryContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StoryContext' 
        // connection string in the application configuration file.
        public StoryContext() : base("name=StoryContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Story> MyStories { get; set; } //done
        public DbSet<BackPack> MyBackPacks { get; set; }//done
        public DbSet<Character> MyCharacters { get; set; }//done
        public DbSet<Ennemy> MyEnnemies { get; set; }//done
        public DbSet<Event> MyEvents { get; set; }
        public DbSet<Hero> MyHeroes { get; set; }//done
        public DbSet<Item> MyItems { get; set; }
        public DbSet<Paragraph> MyParagraphs { get; set; }
        public DbSet<SpecialItem> SpecialItems { get; set; }
        public DbSet<Weapon> MyWeapons { get; set; }
        public DbSet<WeaponHolder> MyWeaponHolders { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}