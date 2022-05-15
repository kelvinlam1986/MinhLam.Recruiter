namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPackageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Program = c.String(maxLength: 50),
                        Name = c.String(maxLength: 100),
                        MinQuantity = c.Int(),
                        MaxQuantity = c.Int(),
                        Price = c.Int(),
                        Discount = c.Int(),
                        Currency = c.String(maxLength: 3, fixedLength: true, unicode: false),
                        Type = c.Boolean(),
                        Activate = c.Boolean(),
                        EntryDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Packages");
        }
    }
}
