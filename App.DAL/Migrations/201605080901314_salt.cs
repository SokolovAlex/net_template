namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Salt");
        }
    }
}
