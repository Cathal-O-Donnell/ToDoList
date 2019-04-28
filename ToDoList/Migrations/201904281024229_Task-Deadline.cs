namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskDeadline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "DeadlineDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "DeadlineDate");
        }
    }
}
