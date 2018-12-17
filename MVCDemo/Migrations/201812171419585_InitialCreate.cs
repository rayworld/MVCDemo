namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TUserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TUserID = c.Int(nullable: false),
                        TRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TRole", t => t.TRoleID, cascadeDelete: true)
                .ForeignKey("dbo.TUser", t => t.TUserID, cascadeDelete: true)
                .Index(t => t.TUserID)
                .Index(t => t.TRoleID);
            
            CreateTable(
                "dbo.TUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        EMail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TUserRole", "TUserID", "dbo.TUser");
            DropForeignKey("dbo.TUserRole", "TRoleID", "dbo.TRole");
            DropIndex("dbo.TUserRole", new[] { "TRoleID" });
            DropIndex("dbo.TUserRole", new[] { "TUserID" });
            DropTable("dbo.TUser");
            DropTable("dbo.TUserRole");
            DropTable("dbo.TRole");
        }
    }
}
