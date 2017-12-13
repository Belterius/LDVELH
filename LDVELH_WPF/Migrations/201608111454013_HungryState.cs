namespace LDVELH_WPF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class HungryState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "BackPack_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Heroes", "WeaponHolder_ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "WeaponHolder_ID");
            DropColumn("dbo.Heroes", "BackPack_ID");
        }
    }
}
