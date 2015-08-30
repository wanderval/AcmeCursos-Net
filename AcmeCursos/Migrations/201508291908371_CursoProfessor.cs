namespace AcmeCursos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoProfessor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Curso", "ProfessorId", "dbo.Professor");
            DropIndex("dbo.Curso", new[] { "ProfessorId" });
            CreateTable(
                "dbo.CursoProfessor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        professorId = c.Int(nullable: false),
                        cursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curso", t => t.cursoId, cascadeDelete: true)
                .ForeignKey("dbo.Professor", t => t.professorId, cascadeDelete: true)
                .Index(t => t.professorId)
                .Index(t => t.cursoId);
            
            AlterColumn("dbo.Curso", "ProfessorId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CursoProfessor", "professorId", "dbo.Professor");
            DropForeignKey("dbo.CursoProfessor", "cursoId", "dbo.Curso");
            DropIndex("dbo.CursoProfessor", new[] { "cursoId" });
            DropIndex("dbo.CursoProfessor", new[] { "professorId" });
            AlterColumn("dbo.Curso", "ProfessorId", c => c.Int(nullable: false));
            DropTable("dbo.CursoProfessor");
            CreateIndex("dbo.Curso", "ProfessorId");
            AddForeignKey("dbo.Curso", "ProfessorId", "dbo.Professor", "Id", cascadeDelete: true);
        }
    }
}
