namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixWeaponType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weapons", "weaponType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weapons", "weaponType");
        }
    }
}
