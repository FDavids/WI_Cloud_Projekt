namespace MiniCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateit : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        FileSizeInByte = c.String(),
                        Uri = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        FileOwner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Files", "FileOwner_Id");
            AddForeignKey("dbo.Files", "FileOwner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
