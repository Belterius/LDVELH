namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseWorking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "saveActualParagraph", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "saveActualParagraph");
        }
    }
}
