namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        healingPower = c.Int(),
                        chargesLeft = c.Int(),
                        chargesLeft1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LootID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}
