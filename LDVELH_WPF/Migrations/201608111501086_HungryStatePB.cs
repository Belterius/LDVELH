namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HungryStatePB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "HungryState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "HungryState");
        }
    }
}
