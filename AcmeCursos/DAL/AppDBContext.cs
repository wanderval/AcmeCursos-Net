﻿using AcmeCursos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AcmeCursos.DAL
{
    public class AppDBContext:DbContext
    {
        public AppDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Inscricao> Inscricaos { get; set; }

        public DbSet<Professor> Professor { get; set; }

        public DbSet<CursoProfessor> CursoProfessor { get; set; }

    }
}