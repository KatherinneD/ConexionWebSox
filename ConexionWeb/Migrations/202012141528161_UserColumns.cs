namespace ConexionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Cargo", c => c.String());
            AddColumn("dbo.AspNetUsers", "Jefatura", c => c.String());
            AddColumn("dbo.AspNetUsers", "Area", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Area");
            DropColumn("dbo.AspNetUsers", "Jefatura");
            DropColumn("dbo.AspNetUsers", "Cargo");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
