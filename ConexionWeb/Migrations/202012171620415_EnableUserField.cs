namespace ConexionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableUserField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Habilitado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Habilitado");
        }
    }
}
