namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateDateToTUser1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TUser", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TUser", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.TUser", "EMail", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TUser", "EMail", c => c.String(nullable: false));
            AlterColumn("dbo.TUser", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.TUser", "Name", c => c.String(nullable: false));
        }
    }
}
