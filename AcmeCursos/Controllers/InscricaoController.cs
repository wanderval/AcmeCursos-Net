using AcmeCursos.DAL;
using AcmeCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcmeCursos.Controllers
{
    public class InscricaoController : Controller
    {
        AppDBContext db = new AppDBContext();
        
        // GET: Inscricao
        public ActionResult CadastrarEstudante()
        {
            var estudantes = db.Estudantes.ToList();
            var cursos = db.Cursos.ToList();

            List<SelectListItem> selectEstudantes = estudantes.Select(e => new SelectListItem() { 
                Text = string.Format("{0} {1}",e.Nome, e.Sobrenome),
                Value = e.Id.ToString()
            }).ToList();
            

            List<SelectListItem> selectCursos = cursos.Select(c => new SelectListItem(){
                Text =  c.Nome,
                Value = c.Id.ToString()
            }).ToList();

            ViewBag.CursoId = selectCursos;
            ViewBag.EstudanteId = selectEstudantes;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarEstudante(Inscricao inscricao)
        {

            if (ModelState.IsValid)
            {
                inscricao.DateInscricao = DateTime.Now;

                db.Inscricaos.Add(inscricao);
                db.SaveChanges();

                ViewBag.Mensagem = "Estudante Cadastrado com sucesso.";
                return View("Sucesso");
            }

            return View(inscricao);
        }
    }
}