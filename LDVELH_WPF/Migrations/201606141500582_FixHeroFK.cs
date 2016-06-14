namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixHeroFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BackPacks", "BackPackID", "dbo.Heroes");
            DropForeignKey("dbo.WeaponHolders", "WeaponHolderID", "dbo.Heroes");
            DropForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks");
            DropForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropIndex("dbo.BackPacks", new[] { "BackPackID" });
            DropIndex("dbo.WeaponHolders", new[] { "WeaponHolderID" });
            DropPrimaryKey("dbo.BackPacks");
            DropPrimaryKey("dbo.WeaponHolders");
            AddColumn("dbo.Heroes", "WeaponHolderID", c => c.Int(nullable: false));
            AddColumn("dbo.Heroes", "BackPackID", c => c.Int(nullable: false));
            AlterColumn("dbo.BackPacks", "BackPackID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.WeaponHolders", "WeaponHolderID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BackPacks", "BackPackID");
            AddPrimaryKey("dbo.WeaponHolders", "WeaponHolderID");
            CreateIndex("dbo.Heroes", "WeaponHolderID");
            CreateIndex("dbo.Heroes", "BackPackID");
            AddForeignKey("dbo.Heroes", "BackPackID", "dbo.BackPacks", "BackPackID", cascadeDelete: true);
            AddForeignKey("dbo.Heroes", "WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID", cascadeDelete: true);
            AddForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks", "BackPackID");
            AddForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks");
            DropForeignKey("dbo.Heroes", "WeaponHolderID", "dbo.WeaponHolders");
            DropForeignKey("dbo.Heroes", "BackPackID", "dbo.BackPacks");
            DropIndex("dbo.Heroes", new[] { "BackPackID" });
            DropIndex("dbo.Heroes", new[] { "WeaponHolderID" });
            DropPrimaryKey("dbo.WeaponHolders");
            DropPrimaryKey("dbo.BackPacks");
            AlterColumn("dbo.WeaponHolders", "WeaponHolderID", c => c.Int(nullable: false));
            AlterColumn("dbo.BackPacks", "BackPackID", c => c.Int(nullable: false));
            DropColumn("dbo.Heroes", "BackPackID");
            DropColumn("dbo.Heroes", "WeaponHolderID");
            AddPrimaryKey("dbo.WeaponHolders", "WeaponHolderID");
            AddPrimaryKey("dbo.BackPacks", "BackPackID");
            CreateIndex("dbo.WeaponHolders", "WeaponHolderID");
            CreateIndex("dbo.BackPacks", "BackPackID");
            AddForeignKey("dbo.Weapons", "WeaponHolder_WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID");
            AddForeignKey("dbo.Items", "BackPack_BackPackID", "dbo.BackPacks", "BackPackID");
            AddForeignKey("dbo.WeaponHolders", "WeaponHolderID", "dbo.Heroes", "CharacterID");
            AddForeignKey("dbo.BackPacks", "BackPackID", "dbo.Heroes", "CharacterID");
        }
    }
}
