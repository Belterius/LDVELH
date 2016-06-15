namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCpacities : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Heroes", name: "saveActualParagraph", newName: "Paragraph");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Heroes", name: "Paragraph", newName: "saveActualParagraph");
        }
    }
}
