namespace ProjectInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Update = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TeamId = c.Int(nullable: false),
                        ProjectManagerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                        Priority = c.String(nullable: false, maxLength: 10),
                        Effort = c.String(nullable: false, maxLength: 30),
                        DeliveryStatus = c.String(nullable: false, maxLength: 10),
                        Overview = c.String(nullable: false, maxLength: 200),
                        Risks = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectManagers", t => t.ProjectManagerId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.ProjectManagerId);
            
            CreateTable(
                "dbo.ProjectManagers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Projects", "ProjectManagerId", "dbo.ProjectManagers");
            DropForeignKey("dbo.Achievements", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "ProjectManagerId" });
            DropIndex("dbo.Projects", new[] { "TeamId" });
            DropIndex("dbo.Achievements", new[] { "ProjectId" });
            DropTable("dbo.Teams");
            DropTable("dbo.ProjectManagers");
            DropTable("dbo.Projects");
            DropTable("dbo.Achievements");
        }
    }
}
