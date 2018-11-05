namespace pim8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tasks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "fieldName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "fieldName", c => c.String());
        }
    }
}
