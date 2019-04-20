namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskUpdateListinTaskModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TaskUpdates", "TaskId");
            AddForeignKey("dbo.TaskUpdates", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskUpdates", "TaskId", "dbo.Tasks");
            DropIndex("dbo.TaskUpdates", new[] { "TaskId" });
        }
    }
}
