namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfw21 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SysUser", name: "Dept_ID", newName: "DeptID");
            RenameIndex(table: "dbo.SysUser", name: "IX_Dept_ID", newName: "IX_DeptID");
            DropColumn("dbo.SysUser", "TitleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SysUser", "TitleID", c => c.Int());
            RenameIndex(table: "dbo.SysUser", name: "IX_DeptID", newName: "IX_Dept_ID");
            RenameColumn(table: "dbo.SysUser", name: "DeptID", newName: "Dept_ID");
        }
    }
}
