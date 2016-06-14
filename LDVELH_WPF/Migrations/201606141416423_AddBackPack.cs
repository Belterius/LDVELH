namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBackPack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackPacks",
                c => new
                    {
                        BackPackID = c.Int(nullable: false, identity: true),
                        backPackSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BackPackID);
            
            AddColumn("dbo.Items", "BackPack_BackPackID", c => c.Int());
            CreateIndex("dbo.Items", "BackPack_BackPackID");
            AddForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks", "BackPackID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks");
            DropIndex("dbo.Items", new[] { "BackPack_BackPackID" });
            DropColumn("dbo.Items", "BackPack_BackPackID");
            DropTable("dbo.BackPacks");
        }
    }
}
