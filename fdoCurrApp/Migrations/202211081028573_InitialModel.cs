namespace fdoCurrApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.lecturerInfo",
                c => new
                {
                    lec_id = c.Int(nullable: false, identity: true),
                    fdo_id = c.Int(nullable: false),
                    lec_name = c.String(nullable:false,128),
                    lec_surname = c.String(nullable: false, 128),
                    lec_pass = c.String(nullable: false, 32),
                    auth_key = c.String(nullable: false, 128),
                    time= c.Int(nullable: false),
                })
                .PrimaryKey(t => t.lec_id)
                .Index(t => t.lec_id)
                .Index(t => t.fdo_id);

        }

        public override void Down()
        {
        }
    }
}
