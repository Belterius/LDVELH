namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeapon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LootID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weapons");
        }
    }
}
