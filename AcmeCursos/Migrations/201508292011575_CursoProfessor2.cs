namespace AcmeCursos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoProfessor2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Curso", "Professor_Id", c => c.Int());
            CreateIndex("dbo.Curso", "Professor_Id");
            AddForeignKey("dbo.Curso", "Professor_Id", "dbo.Professor", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curso", "Professor_Id", "dbo.Professor");
            DropIndex("dbo.Curso", new[] { "Professor_Id" });
            DropColumn("dbo.Curso", "Professor_Id");
        }
    }
}
