namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "UserGuid", c => c.String());
            DropColumn("dbo.Tasks", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Tasks", "UserGuid");
        }
    }
}
