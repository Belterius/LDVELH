namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseDatabase : DbMigration
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
            
            CreateTable(
                "dbo.items",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        healingPower = c.Int(),
                        chargesLeft = c.Int(),
                        chargesLeft1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        BackPack_BackPackID = c.Int(),
                    })
                .PrimaryKey(t => t.LootID)
                .ForeignKey("dbo.BackPacks", t => t.BackPack_BackPackID)
                .Index(t => t.BackPack_BackPackID);
            
            CreateTable(
                "dbo.Capacities",
                c => new
                    {
                        CapacityID = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        Hero_CharacterID = c.Int(),
                    })
                .PrimaryKey(t => t.CapacityID)
                .ForeignKey("dbo.Heroes", t => t.Hero_CharacterID)
                .Index(t => t.Hero_CharacterID);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                        WeaponHolderID = c.Int(nullable: false),
                        BackPackID = c.Int(nullable: false),
                        Gold = c.Int(nullable: false),
                        Paragraph = c.Int(nullable: false),
                        WeaponMastery = c.Int(nullable: false),
                        name = c.String(),
                        maxLife = c.Int(nullable: false),
                        actualLife = c.Int(nullable: false),
                        baseAgility = c.Int(nullable: false),
                        backPack_BackPackID = c.Int(),
                        weaponHolder_WeaponHolderID = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterID)
                .ForeignKey("dbo.BackPacks", t => t.backPack_BackPackID, cascadeDelete: true)
                .ForeignKey("dbo.WeaponHolders", t => t.weaponHolder_WeaponHolderID, cascadeDelete: true)
                .Index(t => t.backPack_BackPackID)
                .Index(t => t.weaponHolder_WeaponHolderID);
            
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
                        Hero_CharacterID = c.Int(),
                        Hero_CharacterID1 = c.Int(),
                    })
                .PrimaryKey(t => t.LootID)
                .ForeignKey("dbo.Heroes", t => t.Hero_CharacterID)
                .ForeignKey("dbo.Heroes", t => t.Hero_CharacterID1)
                .Index(t => t.Hero_CharacterID)
                .Index(t => t.Hero_CharacterID1);
            
            CreateTable(
                "dbo.WeaponHolders",
                c => new
                    {
                        WeaponHolderID = c.Int(nullable: false, identity: true),
                        weaponHolderSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeaponHolderID);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        weaponType = c.Int(nullable: false),
                        WeaponHolder_WeaponHolderID = c.Int(),
                    })
                .PrimaryKey(t => t.LootID)
                .ForeignKey("dbo.WeaponHolders", t => t.WeaponHolder_WeaponHolderID)
                .Index(t => t.WeaponHolder_WeaponHolderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "weaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropForeignKey("dbo.SpecialItems", "Hero_CharacterID1", "dbo.Heroes");
            DropForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes");
            DropForeignKey("dbo.Capacities", "Hero_CharacterID", "dbo.Heroes");
            DropForeignKey("dbo.Heroes", "backPack_BackPackID", "dbo.BackPacks");
            DropForeignKey("dbo.items", "BackPack_BackPackID", "dbo.BackPacks");
            DropIndex("dbo.Weapons", new[] { "WeaponHolder_WeaponHolderID" });
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID1" });
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID" });
            DropIndex("dbo.Heroes", new[] { "weaponHolder_WeaponHolderID" });
            DropIndex("dbo.Heroes", new[] { "backPack_BackPackID" });
            DropIndex("dbo.Capacities", new[] { "Hero_CharacterID" });
            DropIndex("dbo.items", new[] { "BackPack_BackPackID" });
            DropTable("dbo.Weapons");
            DropTable("dbo.WeaponHolders");
            DropTable("dbo.SpecialItems");
            DropTable("dbo.Heroes");
            DropTable("dbo.Capacities");
            DropTable("dbo.items");
            DropTable("dbo.BackPacks");
        }
    }
}
