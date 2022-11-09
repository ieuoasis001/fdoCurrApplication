namespace fdoCurrApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Lecturers", newName: "lecturerInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.lecturerInfo", newName: "Lecturers");
        }
    }
}
