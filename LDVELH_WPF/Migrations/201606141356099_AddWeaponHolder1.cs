namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeaponHolder1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeaponHolders",
                c => new
                    {
                        WeaponHolderID = c.Int(nullable: false, identity: true),
                        Hero_CharacterID = c.Int(),
                    })
                .PrimaryKey(t => t.WeaponHolderID)
                .ForeignKey("dbo.Heroes", t => t.Hero_CharacterID)
                .Index(t => t.Hero_CharacterID);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CharacterID);
            
            CreateTable(
                "dbo.SpecialItems",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Hero_CharacterID = c.Int(),
                    })
                .PrimaryKey(t => t.LootID)
                .ForeignKey("dbo.Heroes", t => t.Hero_CharacterID)
                .Index(t => t.Hero_CharacterID);
            
            AddColumn("dbo.Weapons", "WeaponHolder_WeaponHolderID", c => c.Int());
            CreateIndex("dbo.Weapons", "WeaponHolder_WeaponHolderID");
            AddForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeaponHolders", "Hero_CharacterID", "dbo.Heroes");
            DropForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes");
            DropForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID" });
            DropIndex("dbo.Weapons", new[] { "WeaponHolder_WeaponHolderID" });
            DropIndex("dbo.WeaponHolders", new[] { "Hero_CharacterID" });
            DropColumn("dbo.Weapons", "WeaponHolder_WeaponHolderID");
            DropTable("dbo.SpecialItems");
            DropTable("dbo.Heroes");
            DropTable("dbo.WeaponHolders");
        }
    }
}
