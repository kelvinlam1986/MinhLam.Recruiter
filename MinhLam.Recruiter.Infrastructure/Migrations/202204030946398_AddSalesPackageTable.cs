namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesPackageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesPackages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RecruiterId = c.Guid(nullable: false),
                        ContactName = c.String(nullable: false, maxLength: 100),
                        OrderDate = c.DateTime(nullable: false),
                        PaymentCurrency = c.String(maxLength: 50),
                        PaymentBy = c.String(),
                        PaidStatus = c.Boolean(),
                        PaidDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RCAccounts", t => t.RecruiterId, cascadeDelete: true)
                .Index(t => t.RecruiterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesPackages", "RecruiterId", "dbo.RCAccounts");
            DropIndex("dbo.SalesPackages", new[] { "RecruiterId" });
            DropTable("dbo.SalesPackages");
        }
    }
}
