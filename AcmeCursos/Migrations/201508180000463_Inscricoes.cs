namespace AcmeCursos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inscricoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inscricaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        EstudanteId = c.Int(nullable: false),
                        DateInscricao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curso", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Estudantes", t => t.EstudanteId, cascadeDelete: true)
                .Index(t => t.CursoId)
                .Index(t => t.EstudanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscricaos", "EstudanteId", "dbo.Estudantes");
            DropForeignKey("dbo.Inscricaos", "CursoId", "dbo.Curso");
            DropIndex("dbo.Inscricaos", new[] { "EstudanteId" });
            DropIndex("dbo.Inscricaos", new[] { "CursoId" });
            DropTable("dbo.Inscricaos");
        }
    }
}
