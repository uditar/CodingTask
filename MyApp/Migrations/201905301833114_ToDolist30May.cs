namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDolist30May : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoModels", "Last_Updated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoModels", "Last_Updated");
        }
    }
}
