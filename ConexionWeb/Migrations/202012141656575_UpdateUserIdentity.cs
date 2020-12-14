namespace ConexionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String(maxLength: 256));
            AddColumn("dbo.AspNetUsers", "Identificacion", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "Cargo", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Jefatura", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Area", c => c.String(maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Area", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Jefatura", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Cargo", c => c.String());
            DropColumn("dbo.AspNetUsers", "Identificacion");
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
    }
}
