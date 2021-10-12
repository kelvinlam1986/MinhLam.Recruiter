namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Area = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RCAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 20, unicode: false),
                        CompanyName = c.String(maxLength: 50),
                        EnglishName = c.String(maxLength: 50, unicode: false),
                        AccountType = c.Boolean(nullable: false),
                        Newsletter = c.Boolean(nullable: false),
                        ResumeAlert = c.Boolean(nullable: false),
                        Promotion = c.Boolean(nullable: false),
                        Logo = c.Boolean(nullable: false),
                        JobPostingBalance = c.Int(nullable: false),
                        ResumeViewingBalance = c.Int(nullable: false),
                        Activate = c.Boolean(nullable: false),
                        Agency = c.Boolean(nullable: false),
                        AvailableForPosting = c.Int(nullable: false),
                        AvailableForViewing = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(),
                        HitViewed = c.Int(nullable: false),
                        DefaultLanguage = c.Boolean(nullable: false),
                        Contact = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Country = c.String(maxLength: 30),
                        Tel = c.String(maxLength: 20, unicode: false),
                        Fax = c.String(maxLength: 20, unicode: false),
                        ProvinceId = c.Guid(),
                        City = c.String(maxLength: 50),
                        OpenDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RCAccounts", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.RCAccounts", new[] { "ProvinceId" });
            DropTable("dbo.RCAccounts");
            DropTable("dbo.Provinces");
        }
    }
}
