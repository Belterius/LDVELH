namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "WeaponMastery", c => c.Int(nullable: false));
            AddColumn("dbo.Capacities", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Capacities", "Capacity");
            DropColumn("dbo.Heroes", "WeaponMastery");
        }
    }
}
