namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateDateToSysUserupdatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TUser", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TUser", "CreateDate");
        }
    }
}
