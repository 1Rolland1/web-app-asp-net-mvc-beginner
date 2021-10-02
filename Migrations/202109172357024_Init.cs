namespace laba1_Raspisanie_zanyatiy_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonName = c.String(nullable: false),
                        Teacher = c.String(nullable: false),
                        SequentialNumber = c.Int(nullable: false),
                        Group = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lessons");
        }
    }
}
