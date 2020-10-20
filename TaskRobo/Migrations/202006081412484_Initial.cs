namespace TaskRobo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryTitle = c.String(),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.AppUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskTitle = c.String(),
                        TaskContent = c.String(),
                        TaskStatus = c.String(),
                        UserID = c.String(maxLength: 128),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.AppUsers", t => t.UserID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.UserTasks", "UserID", "dbo.AppUsers");
            DropForeignKey("dbo.Categories", "UserID", "dbo.AppUsers");
            DropIndex("dbo.UserTasks", new[] { "CategoryID" });
            DropIndex("dbo.UserTasks", new[] { "UserID" });
            DropIndex("dbo.Categories", new[] { "UserID" });
            DropTable("dbo.UserTasks");
            DropTable("dbo.Categories");
            DropTable("dbo.AppUsers");
        }
    }
}
