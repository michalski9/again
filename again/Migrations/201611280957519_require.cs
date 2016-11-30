namespace again.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class require : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "Interestings", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employers", "Interestings", c => c.String());
            AlterColumn("dbo.Employers", "LastName", c => c.String());
            AlterColumn("dbo.Employers", "FirstName", c => c.String());
        }
    }
}
