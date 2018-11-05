namespace pim8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        fieldName = c.String(),
                        dateTimeStart = c.DateTime(nullable: false),
                        dateTimeEnd = c.DateTime(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
        }
    }
}
