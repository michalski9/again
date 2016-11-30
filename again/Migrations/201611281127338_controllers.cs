namespace again.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class controllers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DailyEmployers", newName: "EmployerDailies");
            RenameTable(name: "dbo.DayEmployers", newName: "EmployerDays");
            DropPrimaryKey("dbo.EmployerDailies");
            DropPrimaryKey("dbo.EmployerDays");
            AddPrimaryKey("dbo.EmployerDailies", new[] { "Employer_Id", "Daily_Id" });
            AddPrimaryKey("dbo.EmployerDays", new[] { "Employer_Id", "Day_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EmployerDays");
            DropPrimaryKey("dbo.EmployerDailies");
            AddPrimaryKey("dbo.EmployerDays", new[] { "Day_Id", "Employer_Id" });
            AddPrimaryKey("dbo.EmployerDailies", new[] { "Daily_Id", "Employer_Id" });
            RenameTable(name: "dbo.EmployerDays", newName: "DayEmployers");
            RenameTable(name: "dbo.EmployerDailies", newName: "DailyEmployers");
        }
    }
}
