using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcmeCursos.DAL;
using AcmeCursos.Models;

namespace AcmeCursos.Controllers
{
    public class CursoesController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Cursoes
        public ActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        // GET: Cursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursoes/Create
        public ActionResult Create()
        {
            var professores = db.Professor.ToList();

            List<SelectListItem> selectProfessores = professores.Select(e => new SelectListItem()
            {
                Text = string.Format("{0} {1}", e.Nome, e.Sobrenome),
                Value = e.Id.ToString()
            }).ToList();

            ViewBag.ProfessorId = selectProfessores;

            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,DataLimiteInscricao,ProfessorId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();

                int primaryKey = curso.Id;

                CursoProfessor professor = new CursoProfessor();

                for (int i = 0; i < curso.ProfessorId.Count(); i++)
                {
                    professor.cursoId = primaryKey;
                    professor.professorId = Convert.ToInt32(curso.ProfessorId[i]);
                    db.CursoProfessor.Add(professor);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }

            var professores = db.Professor.ToList();
            var professoresSelecionados = db.CursoProfessor.Where(x => x.cursoId == id).ToList();

            
           /* int[] ids = new int[cursosMinistrados.Count()+1];
            ids[0] = 0;

            for (int i = 0; i < cursosMinistrados.Count(); i++)
            {
                ids[i+1] = cursosMinistrados[i].cursoId;
            }

            List<SelectListItem> selectProfessores = professores.Select(e => new SelectListItem()
            {
                Text = string.Format("{0} {1}", e.Nome, e.Sobrenome),
                Value = e.Id.ToString(),
                Selected = ids.Contains(e.Id)
            }).ToList();*/


            List<SelectListItem> selectProfessores = new List<SelectListItem>();
            bool isValid = false;
            
           foreach(Professor professor in professores)
            {

                if (professoresSelecionados.Count() > 0)
                {
                    for (var i = 0; i < professoresSelecionados.Count(); i++)
                    {
                        if (professoresSelecionados.ElementAt(i).professorId.Equals(professor.Id))
                        {
                            isValid = true;
                            break;
                        }
                    }
                } 
                SelectListItem selectItemProfessor = new SelectListItem {
                    Value = professor.Id.ToString(),
                    Text = string.Format("{0} {1}", professor.Nome, professor.Sobrenome),
                    Selected =  isValid 
                };

                selectProfessores.Add(selectItemProfessor);
                isValid = false;
                

                //selected != null && selected.Contains(idx.ToString())
            }
            
            ViewBag.ProfessorId = selectProfessores;

            if (professores == null)
            {
                return HttpNotFound();
            }

            return View(curso);
        }
        private string SelectedItem() { 
            return "teste";
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,DataLimiteInscricao, ProfessorId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                //deletando os cursos
                var professores = db.CursoProfessor.Where(x => x.cursoId == curso.Id);
                foreach (var p in professores)
                {
                    db.CursoProfessor.Remove(p);
                }
                db.SaveChanges();

                if (curso.ProfessorId != null)
                {
                    //inserindo os cursos
                    CursoProfessor prof = new CursoProfessor();

                    for (int i = 0; i < curso.ProfessorId.Count(); i++)
                    {
                        prof.cursoId = curso.Id;
                        prof.professorId = Convert.ToInt32(curso.ProfessorId[i]);
                        db.CursoProfessor.Add(prof);
                        db.SaveChanges();
                    }

                }

                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Edit/" + curso.Id);

                /*db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");*/
            }
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
