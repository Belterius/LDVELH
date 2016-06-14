namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeaponColumn2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weapons", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weapons", "name");
        }
    }
}
