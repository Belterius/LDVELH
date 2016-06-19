namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNameProblem : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Heroes", name: "WeaponMastery", newName: "WeaponMastery");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Heroes", name: "WeaponMastery", newName: "WeaponMastery");
        }
    }
}
