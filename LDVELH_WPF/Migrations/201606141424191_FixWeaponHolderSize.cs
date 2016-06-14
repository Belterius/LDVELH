namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixWeaponHolderSize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeaponHolders", "weaponHolderSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeaponHolders", "weaponHolderSize");
        }
    }
}
