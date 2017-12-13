namespace LDVELH_WPF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUselessColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Heroes", "WeaponHolderID");
            DropColumn("dbo.Heroes", "BackPackID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Heroes", "BackPackID", c => c.Int(nullable: false));
            AddColumn("dbo.Heroes", "WeaponHolderID", c => c.Int(nullable: false));
        }
    }
}
