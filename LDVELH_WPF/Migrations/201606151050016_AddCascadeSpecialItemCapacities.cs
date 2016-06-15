namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCascadeSpecialItemCapacities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialItems", "Hero_CharacterID1", c => c.Int());
            CreateIndex("dbo.SpecialItems", "Hero_CharacterID1");
            AddForeignKey("dbo.SpecialItems", "Hero_CharacterID1", "dbo.Heroes", "CharacterID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialItems", "Hero_CharacterID1", "dbo.Heroes");
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID1" });
            DropColumn("dbo.SpecialItems", "Hero_CharacterID1");
        }
    }
}
