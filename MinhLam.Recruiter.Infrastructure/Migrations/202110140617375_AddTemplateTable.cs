namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTemplateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Templates");
        }
    }
}
