namespace LDVELH_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class problemName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Heroes", name: "MaitriseDesArmes", newName: "WeaponMastery");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Heroes", name: "WeaponMastery", newName: "MaitriseDesArmes");
        }
    }
}
