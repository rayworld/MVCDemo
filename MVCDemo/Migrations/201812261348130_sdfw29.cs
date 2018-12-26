namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfw29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysDept",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DeptDesc = c.String(maxLength: 50),
                        SortOrder = c.Int(nullable: false),
                        ParantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SysUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        EMail = c.String(nullable: false, maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        TitleID = c.Int(),
                        Dept_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysDept", t => t.Dept_ID)
                .Index(t => t.Dept_ID);
            
            CreateTable(
                "dbo.SysUserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysRole", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.SysUser", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.SysRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        RoleDesc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SysPremission",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PremissionDesc = c.String(),
                        RoleEntity_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysRole", t => t.RoleEntity_ID)
                .Index(t => t.RoleEntity_ID);
            
            CreateTable(
                "dbo.SysModulePremission",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ModuleID = c.Int(nullable: false),
                        PremissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysModule", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.SysPremission", t => t.PremissionID, cascadeDelete: true)
                .Index(t => t.ModuleID)
                .Index(t => t.PremissionID);
            
            CreateTable(
                "dbo.SysModule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ModuleDesc = c.String(maxLength: 50),
                        ParentID = c.Int(nullable: false),
                        PremissionEntity_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysPremission", t => t.PremissionEntity_ID)
                .Index(t => t.PremissionEntity_ID);
            
            CreateTable(
                "dbo.SysRolePremission",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        PremissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysPremission", t => t.PremissionID, cascadeDelete: true)
                .ForeignKey("dbo.SysRole", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.PremissionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysRolePremission", "RoleID", "dbo.SysRole");
            DropForeignKey("dbo.SysRolePremission", "PremissionID", "dbo.SysPremission");
            DropForeignKey("dbo.SysUserRole", "UserID", "dbo.SysUser");
            DropForeignKey("dbo.SysUserRole", "RoleID", "dbo.SysRole");
            DropForeignKey("dbo.SysPremission", "RoleEntity_ID", "dbo.SysRole");
            DropForeignKey("dbo.SysModule", "PremissionEntity_ID", "dbo.SysPremission");
            DropForeignKey("dbo.SysModulePremission", "PremissionID", "dbo.SysPremission");
            DropForeignKey("dbo.SysModulePremission", "ModuleID", "dbo.SysModule");
            DropForeignKey("dbo.SysUser", "Dept_ID", "dbo.SysDept");
            DropIndex("dbo.SysRolePremission", new[] { "PremissionID" });
            DropIndex("dbo.SysRolePremission", new[] { "RoleID" });
            DropIndex("dbo.SysModule", new[] { "PremissionEntity_ID" });
            DropIndex("dbo.SysModulePremission", new[] { "PremissionID" });
            DropIndex("dbo.SysModulePremission", new[] { "ModuleID" });
            DropIndex("dbo.SysPremission", new[] { "RoleEntity_ID" });
            DropIndex("dbo.SysUserRole", new[] { "RoleID" });
            DropIndex("dbo.SysUserRole", new[] { "UserID" });
            DropIndex("dbo.SysUser", new[] { "Dept_ID" });
            DropTable("dbo.SysRolePremission");
            DropTable("dbo.SysModule");
            DropTable("dbo.SysModulePremission");
            DropTable("dbo.SysPremission");
            DropTable("dbo.SysRole");
            DropTable("dbo.SysUserRole");
            DropTable("dbo.SysUser");
            DropTable("dbo.SysDept");
        }
    }
}
