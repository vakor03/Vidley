namespace Vidley.WebAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
    }
}
