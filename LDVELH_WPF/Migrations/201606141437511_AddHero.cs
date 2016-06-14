namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHero : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks");
            DropForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropPrimaryKey("dbo.BackPacks");
            DropPrimaryKey("dbo.WeaponHolders");
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                        Gold = c.Int(nullable: false),
                        name = c.String(),
                        maxLife = c.Int(nullable: false),
                        actualLife = c.Int(nullable: false),
                        baseAgility = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterID);
            
            AddColumn("dbo.SpecialItems", "Hero_CharacterID", c => c.Int());
            AlterColumn("dbo.BackPacks", "BackPackID", c => c.Int(nullable: false));
            AlterColumn("dbo.WeaponHolders", "WeaponHolderID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BackPacks", "BackPackID");
            AddPrimaryKey("dbo.WeaponHolders", "WeaponHolderID");
            CreateIndex("dbo.BackPacks", "BackPackID");
            CreateIndex("dbo.SpecialItems", "Hero_CharacterID");
            CreateIndex("dbo.WeaponHolders", "WeaponHolderID");
            AddForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes", "CharacterID");
            AddForeignKey("dbo.BackPacks", "BackPackID", "dbo.Heroes", "CharacterID");
            AddForeignKey("dbo.WeaponHolders", "WeaponHolderID", "dbo.Heroes", "CharacterID");
            AddForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks", "BackPackID");
            AddForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks");
            DropForeignKey("dbo.WeaponHolders", "WeaponHolderID", "dbo.Heroes");
            DropForeignKey("dbo.BackPacks", "BackPackID", "dbo.Heroes");
            DropForeignKey("dbo.SpecialItems", "Hero_CharacterID", "dbo.Heroes");
            DropIndex("dbo.WeaponHolders", new[] { "WeaponHolderID" });
            DropIndex("dbo.SpecialItems", new[] { "Hero_CharacterID" });
            DropIndex("dbo.BackPacks", new[] { "BackPackID" });
            DropPrimaryKey("dbo.WeaponHolders");
            DropPrimaryKey("dbo.BackPacks");
            AlterColumn("dbo.WeaponHolders", "WeaponHolderID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.BackPacks", "BackPackID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.SpecialItems", "Hero_CharacterID");
            DropTable("dbo.Heroes");
            AddPrimaryKey("dbo.WeaponHolders", "WeaponHolderID");
            AddPrimaryKey("dbo.BackPacks", "BackPackID");
            AddForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID");
            AddForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks", "BackPackID");
        }
    }
}
