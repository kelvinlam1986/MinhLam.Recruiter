namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesPackageDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesPackageDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SalesPackageId = c.Guid(nullable: false),
                        PackageName = c.String(nullable: false, maxLength: 4000),
                        PackageQuantity = c.Int(nullable: false),
                        PackagePrice = c.Int(nullable: false),
                        PackageType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalesPackages", t => t.SalesPackageId, cascadeDelete: true)
                .Index(t => t.SalesPackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesPackageDetails", "SalesPackageId", "dbo.SalesPackages");
            DropIndex("dbo.SalesPackageDetails", new[] { "SalesPackageId" });
            DropTable("dbo.SalesPackageDetails");
        }
    }
}
