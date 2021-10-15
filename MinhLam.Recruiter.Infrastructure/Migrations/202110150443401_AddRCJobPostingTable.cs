namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRCJobPostingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RCJobPostings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RecruiterId = c.Guid(nullable: false),
                        JobTitle = c.String(nullable: false, maxLength: 100),
                        JobNo = c.String(maxLength: 10, unicode: false),
                        RequiredNumber = c.Int(nullable: false),
                        JobSummary = c.String(nullable: false, storeType: "ntext"),
                        WorkingTypeId = c.Guid(nullable: false),
                        ExperienceLevelId = c.Guid(nullable: false),
                        YearExperience = c.Int(),
                        RangeOfAge = c.String(maxLength: 50),
                        RecruitmentType = c.String(maxLength: 50),
                        SalaryFrom = c.Int(),
                        SalaryTo = c.Int(),
                        Currency = c.String(maxLength: 3, fixedLength: true, unicode: false),
                        ShowSalary = c.Boolean(nullable: false),
                        SalaryNegotive = c.Boolean(nullable: false),
                        ClosedDate = c.DateTime(nullable: false),
                        CompanyLogo = c.Boolean(nullable: false),
                        AdvName = c.String(maxLength: 1000),
                        JobSkill = c.String(storeType: "ntext"),
                        JobIndustryId = c.Guid(nullable: false),
                        JobCategoryId = c.Guid(nullable: false),
                        CertificateId = c.Guid(nullable: false),
                        WorkLocation = c.String(maxLength: 100),
                        ProvinceId = c.Guid(),
                        TemplateId = c.Guid(nullable: false),
                        FolderId = c.Guid(),
                        EnableApplyOnline = c.Boolean(nullable: false),
                        OnlyApplyUrl = c.String(maxLength: 100, unicode: false),
                        ContactEmail = c.String(nullable: false, maxLength: 50, unicode: false),
                        ContactPerson = c.String(nullable: false, maxLength: 50),
                        ContactTel = c.String(nullable: false, maxLength: 10, unicode: false),
                        ViewedNo = c.Int(),
                        PostedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Activate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JSCertificates", t => t.CertificateId, cascadeDelete: true)
                .ForeignKey("dbo.ExperienceLevels", t => t.ExperienceLevelId, cascadeDelete: true)
                .ForeignKey("dbo.JobCategory", t => t.JobCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.JobIndustry", t => t.JobIndustryId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .ForeignKey("dbo.RCFolders", t => t.FolderId)
                .ForeignKey("dbo.RCAccounts", t => t.RecruiterId, cascadeDelete: true)
                .ForeignKey("dbo.Templates", t => t.TemplateId, cascadeDelete: true)
                .ForeignKey("dbo.WorkingTypes", t => t.WorkingTypeId, cascadeDelete: true)
                .Index(t => t.RecruiterId)
                .Index(t => t.WorkingTypeId)
                .Index(t => t.ExperienceLevelId)
                .Index(t => t.JobIndustryId)
                .Index(t => t.JobCategoryId)
                .Index(t => t.CertificateId)
                .Index(t => t.ProvinceId)
                .Index(t => t.TemplateId)
                .Index(t => t.FolderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RCJobPostings", "WorkingTypeId", "dbo.WorkingTypes");
            DropForeignKey("dbo.RCJobPostings", "TemplateId", "dbo.Templates");
            DropForeignKey("dbo.RCJobPostings", "RecruiterId", "dbo.RCAccounts");
            DropForeignKey("dbo.RCJobPostings", "FolderId", "dbo.RCFolders");
            DropForeignKey("dbo.RCJobPostings", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.RCJobPostings", "JobIndustryId", "dbo.JobIndustry");
            DropForeignKey("dbo.RCJobPostings", "JobCategoryId", "dbo.JobCategory");
            DropForeignKey("dbo.RCJobPostings", "ExperienceLevelId", "dbo.ExperienceLevels");
            DropForeignKey("dbo.RCJobPostings", "CertificateId", "dbo.JSCertificates");
            DropIndex("dbo.RCJobPostings", new[] { "FolderId" });
            DropIndex("dbo.RCJobPostings", new[] { "TemplateId" });
            DropIndex("dbo.RCJobPostings", new[] { "ProvinceId" });
            DropIndex("dbo.RCJobPostings", new[] { "CertificateId" });
            DropIndex("dbo.RCJobPostings", new[] { "JobCategoryId" });
            DropIndex("dbo.RCJobPostings", new[] { "JobIndustryId" });
            DropIndex("dbo.RCJobPostings", new[] { "ExperienceLevelId" });
            DropIndex("dbo.RCJobPostings", new[] { "WorkingTypeId" });
            DropIndex("dbo.RCJobPostings", new[] { "RecruiterId" });
            DropTable("dbo.RCJobPostings");
        }
    }
}
