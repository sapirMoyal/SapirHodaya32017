namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        UserPassword = c.String(nullable: false),
                        UserEmail = c.String(),
                        win = c.Int(nullable: false),
                        lose = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
