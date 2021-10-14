namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRCFolderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RCFolders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RecruiterId = c.Guid(nullable: false),
                        FolderName = c.String(nullable: false, maxLength: 50, unicode: false),
                        FolderDescription = c.String(maxLength: 100),
                        FolderManager = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RCAccounts", t => t.RecruiterId, cascadeDelete: true)
                .Index(t => t.RecruiterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RCFolders", "RecruiterId", "dbo.RCAccounts");
            DropIndex("dbo.RCFolders", new[] { "RecruiterId" });
            DropTable("dbo.RCFolders");
        }
    }
}
