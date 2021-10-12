namespace MinhLam.Recruiter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLengthForFieldPassword : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RCAccounts", "Password", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RCAccounts", "Password", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
    }
}
