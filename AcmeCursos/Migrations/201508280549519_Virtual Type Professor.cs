namespace AcmeCursos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualTypeProfessor : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Curso", "ProfessorId");
            AddForeignKey("dbo.Curso", "ProfessorId", "dbo.Professor", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curso", "ProfessorId", "dbo.Professor");
            DropIndex("dbo.Curso", new[] { "ProfessorId" });
        }
    }
}
