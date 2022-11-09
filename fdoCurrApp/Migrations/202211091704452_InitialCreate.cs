namespace fdoCurrApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        lec_id = c.Int(nullable: false, identity: true),
                        lec_pass = c.String(),
                        fdo_id = c.Int(nullable: false),
                        lec_name = c.String(),
                        lec_surname = c.String(),
                        auth_key = c.String(),
                        time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lec_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lecturers");
        }
    }
}
