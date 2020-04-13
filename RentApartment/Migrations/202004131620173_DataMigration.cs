namespace RentApartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        Area = c.String(),
                        City = c.String(),
                        District = c.String(),
                        Street = c.String(),
                        House = c.Int(nullable: false),
                        Apartment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Florr = c.Int(nullable: false),
                        Num_Floors = c.Int(nullable: false),
                        Num_Rooms = c.Int(nullable: false),
                        Total_Area = c.Int(nullable: false),
                        LivingArea = c.Int(nullable: false),
                        KitchenArea = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        rf_UsersId = c.String(maxLength: 128),
                        rf_TypeHomeId = c.Int(nullable: false),
                        rf_AdressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.rf_AdressId, cascadeDelete: true)
                .ForeignKey("dbo.TypeHomes", t => t.rf_TypeHomeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.rf_UsersId)
                .Index(t => t.rf_UsersId)
                .Index(t => t.rf_TypeHomeId)
                .Index(t => t.rf_AdressId);
            
            CreateTable(
                "dbo.TypeHomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Apartments", "rf_UsersId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Apartments", "rf_TypeHomeId", "dbo.TypeHomes");
            DropForeignKey("dbo.Apartments", "rf_AdressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Apartments", new[] { "rf_AdressId" });
            DropIndex("dbo.Apartments", new[] { "rf_TypeHomeId" });
            DropIndex("dbo.Apartments", new[] { "rf_UsersId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TypeHomes");
            DropTable("dbo.Apartments");
            DropTable("dbo.Addresses");
        }
    }
}
