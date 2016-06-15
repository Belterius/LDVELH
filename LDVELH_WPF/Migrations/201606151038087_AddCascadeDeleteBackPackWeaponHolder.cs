namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCascadeDeleteBackPackWeaponHolder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Heroes", "BackPackID", "dbo.BackPacks");
            DropForeignKey("dbo.Heroes", "WeaponHolderID", "dbo.WeaponHolders");
            DropIndex("dbo.Heroes", new[] { "WeaponHolderID" });
            DropIndex("dbo.Heroes", new[] { "BackPackID" });
            AddColumn("dbo.Heroes", "backPack_BackPackID", c => c.Int());
            AddColumn("dbo.Heroes", "weaponHolder_WeaponHolderID", c => c.Int());
            CreateIndex("dbo.Heroes", "backPack_BackPackID");
            CreateIndex("dbo.Heroes", "weaponHolder_WeaponHolderID");
            AddForeignKey("dbo.Heroes", "backPack_BackPackID", "dbo.BackPacks", "BackPackID", cascadeDelete: true);
            AddForeignKey("dbo.Heroes", "weaponHolder_WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "weaponHolder_WeaponHolderID", "dbo.WeaponHolders");
            DropForeignKey("dbo.Heroes", "backPack_BackPackID", "dbo.BackPacks");
            DropIndex("dbo.Heroes", new[] { "weaponHolder_WeaponHolderID" });
            DropIndex("dbo.Heroes", new[] { "backPack_BackPackID" });
            DropColumn("dbo.Heroes", "weaponHolder_WeaponHolderID");
            DropColumn("dbo.Heroes", "backPack_BackPackID");
            CreateIndex("dbo.Heroes", "BackPackID");
            CreateIndex("dbo.Heroes", "WeaponHolderID");
            AddForeignKey("dbo.Heroes", "WeaponHolderID", "dbo.WeaponHolders", "WeaponHolderID", cascadeDelete: true);
            AddForeignKey("dbo.Heroes", "BackPackID", "dbo.BackPacks", "BackPackID", cascadeDelete: true);
        }
    }
}
