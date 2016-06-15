namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCapacities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Capacities",
                c => new
                    {
                        CapacityID = c.Int(nullable: false, identity: true),
                        Hero_CharacterID = c.Int(),
                    })
                .PrimaryKey(t => t.CapacityID)
                .ForeignKey("dbo.Heroes", t => t.Hero_CharacterID)
                .Index(t => t.Hero_CharacterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Capacities", "Hero_CharacterID", "dbo.Heroes");
            DropIndex("dbo.Capacities", new[] { "Hero_CharacterID" });
            DropTable("dbo.Capacities");
        }
    }
}
