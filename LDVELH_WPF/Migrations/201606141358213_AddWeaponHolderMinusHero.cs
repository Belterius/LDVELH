namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeaponHolderMinusHero : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes");
            DropForeignKey("dbo.WeaponHolders", "Hero_CharacterID", "dbo.Heroes");
            DropIndex("dbo.WeaponHolders", new[] { "Hero_CharacterID" });
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID" });
            DropColumn("dbo.WeaponHolders", "Hero_CharacterID");
            DropTable("dbo.Heroes");
            DropTable("dbo.SpecialItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpecialItems",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Hero_CharacterID = c.Int(),
                    })
                .PrimaryKey(t => t.LootID);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CharacterID);
            
            AddColumn("dbo.WeaponHolders", "Hero_CharacterID", c => c.Int());
            CreateIndex("dbo.SpecialItems", "Hero_CharacterID");
            CreateIndex("dbo.WeaponHolders", "Hero_CharacterID");
            AddForeignKey("dbo.WeaponHolders", "Hero_CharacterID", "dbo.Heroes", "CharacterID");
            AddForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes", "CharacterID");
        }
    }
}
