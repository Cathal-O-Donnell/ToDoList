namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskUpdateModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskUpdates", "UpdateText", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskUpdates", "UpdateText", c => c.String());
        }
    }
}
