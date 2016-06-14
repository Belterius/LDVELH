namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialItems",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        agilityBonus = c.Int(),
                        LifePointBonus = c.Int(),
                        agilityBonus1 = c.Int(),
                        hitPointBonus = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LootID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpecialItems");
        }
    }
}
