namespace again.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Reprimand = c.Boolean(nullable: false),
                        Pesel = c.String(),
                        DisabilityLevel = c.Int(nullable: false),
                        HealthStatus = c.Int(nullable: false),
                        AdditionalInformation = c.String(),
                        Interestings = c.String(),
                        Position_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id)
                .Index(t => t.Position_Id);
            
            CreateTable(
                "dbo.Dailies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HourlyRate = c.Double(nullable: false),
                        Bonus = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Daily_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dailies", t => t.Daily_Id)
                .Index(t => t.Daily_Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Day_Id = c.Int(),
                        Employer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .ForeignKey("dbo.Employers", t => t.Employer_Id)
                .Index(t => t.Day_Id)
                .Index(t => t.Employer_Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DayEmployers",
                c => new
                    {
                        Day_Id = c.Int(nullable: false),
                        Employer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Day_Id, t.Employer_Id })
                .ForeignKey("dbo.Days", t => t.Day_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employers", t => t.Employer_Id, cascadeDelete: true)
                .Index(t => t.Day_Id)
                .Index(t => t.Employer_Id);
            
            CreateTable(
                "dbo.DailyEmployers",
                c => new
                    {
                        Daily_Id = c.Int(nullable: false),
                        Employer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Daily_Id, t.Employer_Id })
                .ForeignKey("dbo.Dailies", t => t.Daily_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employers", t => t.Employer_Id, cascadeDelete: true)
                .Index(t => t.Daily_Id)
                .Index(t => t.Employer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Works", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.Employers", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.Positions", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.DailyEmployers", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.DailyEmployers", "Daily_Id", "dbo.Dailies");
            DropForeignKey("dbo.Days", "Daily_Id", "dbo.Dailies");
            DropForeignKey("dbo.Works", "Day_Id", "dbo.Days");
            DropForeignKey("dbo.DayEmployers", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.DayEmployers", "Day_Id", "dbo.Days");
            DropIndex("dbo.DailyEmployers", new[] { "Employer_Id" });
            DropIndex("dbo.DailyEmployers", new[] { "Daily_Id" });
            DropIndex("dbo.DayEmployers", new[] { "Employer_Id" });
            DropIndex("dbo.DayEmployers", new[] { "Day_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Positions", new[] { "Department_Id" });
            DropIndex("dbo.Works", new[] { "Employer_Id" });
            DropIndex("dbo.Works", new[] { "Day_Id" });
            DropIndex("dbo.Days", new[] { "Daily_Id" });
            DropIndex("dbo.Employers", new[] { "Position_Id" });
            DropTable("dbo.DailyEmployers");
            DropTable("dbo.DayEmployers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Departments");
            DropTable("dbo.Positions");
            DropTable("dbo.Works");
            DropTable("dbo.Days");
            DropTable("dbo.Dailies");
            DropTable("dbo.Employers");
        }
    }
}
