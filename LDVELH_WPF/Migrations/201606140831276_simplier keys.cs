namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simplierkeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecialItems", new[] { "Hero_CharacterID", "Hero_HeroID" }, "dbo.Heroes");
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID", "Hero_HeroID" });
            DropPrimaryKey("dbo.Heroes");
            DropPrimaryKey("dbo.SpecialItems");
            DropPrimaryKey("dbo.Weapons");
            AlterColumn("dbo.Heroes", "CharacterID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SpecialItems", "LootID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Weapons", "LootID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Heroes", "CharacterID");
            AddPrimaryKey("dbo.SpecialItems", "LootID");
            AddPrimaryKey("dbo.Weapons", "LootID");
            CreateIndex("dbo.SpecialItems", "Hero_CharacterID");
            AddForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes", "CharacterID");
            DropColumn("dbo.Heroes", "HeroID");
            DropColumn("dbo.SpecialItems", "SpecialItemID");
            DropColumn("dbo.SpecialItems", "Hero_HeroID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpecialItems", "Hero_HeroID", c => c.Int());
            AddColumn("dbo.SpecialItems", "SpecialItemID", c => c.Int(nullable: false));
            AddColumn("dbo.Heroes", "HeroID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes");
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID" });
            DropPrimaryKey("dbo.Weapons");
            DropPrimaryKey("dbo.SpecialItems");
            DropPrimaryKey("dbo.Heroes");
            AlterColumn("dbo.Weapons", "LootID", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecialItems", "LootID", c => c.Int(nullable: false));
            AlterColumn("dbo.Heroes", "CharacterID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Weapons", new[] { "LootID", "WeaponID" });
            AddPrimaryKey("dbo.SpecialItems", new[] { "LootID", "SpecialItemID" });
            AddPrimaryKey("dbo.Heroes", new[] { "CharacterID", "HeroID" });
            CreateIndex("dbo.SpecialItems", new[] { "Hero_CharacterID", "Hero_HeroID" });
            AddForeignKey("dbo.SpecialItems", new[] { "Hero_CharacterID", "Hero_HeroID" }, "dbo.Heroes", new[] { "CharacterID", "HeroID" });
        }
    }
}
