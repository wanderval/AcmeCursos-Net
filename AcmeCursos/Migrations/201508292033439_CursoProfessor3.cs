namespace AcmeCursos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoProfessor3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Curso", "Professor_Id", "dbo.Professor");
            DropIndex("dbo.Curso", new[] { "Professor_Id" });
            DropColumn("dbo.Curso", "ProfessorId");
            DropColumn("dbo.Curso", "Professor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Curso", "Professor_Id", c => c.Int());
            AddColumn("dbo.Curso", "ProfessorId", c => c.String());
            CreateIndex("dbo.Curso", "Professor_Id");
            AddForeignKey("dbo.Curso", "Professor_Id", "dbo.Professor", "Id");
        }
    }
}
