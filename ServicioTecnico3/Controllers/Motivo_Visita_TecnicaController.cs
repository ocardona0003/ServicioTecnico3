using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServicioTecnico3.Models;

namespace ServicioTecnico_v2.Controllers
{
    public class Motivo_Visita_TecnicaController : Controller
    {
        private herracentroV2Entities1 db = new herracentroV2Entities1();

        // GET: Motivo_Visita_Tecnica
        public ActionResult Index()
        {
            return View(db.Motivo_Visita_Tecnica.ToList());
        }

        // GET: Motivo_Visita_Tecnica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Visita_Tecnica motivo_Visita_Tecnica = db.Motivo_Visita_Tecnica.Find(id);
            if (motivo_Visita_Tecnica == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Visita_Tecnica);
        }

        // GET: Motivo_Visita_Tecnica/Create
        public ActionResult Create()
        {
            var max = db.Motivo_Visita_Tecnica.Max(r => r.id);
            Motivo_Visita_Tecnica motivo_Visita_Tecnica = new Motivo_Visita_Tecnica();
            motivo_Visita_Tecnica.id = max + 1;
            return View(motivo_Visita_Tecnica);
        }

        // POST: Motivo_Visita_Tecnica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Motivo_Visita_Tecnica motivo_Visita_Tecnica)
        {
            if (ModelState.IsValid)
            {
                db.Motivo_Visita_Tecnica.Add(motivo_Visita_Tecnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motivo_Visita_Tecnica);
        }

        // GET: Motivo_Visita_Tecnica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Visita_Tecnica motivo_Visita_Tecnica = db.Motivo_Visita_Tecnica.Find(id);
            if (motivo_Visita_Tecnica == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Visita_Tecnica);
        }

        // POST: Motivo_Visita_Tecnica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] Motivo_Visita_Tecnica motivo_Visita_Tecnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motivo_Visita_Tecnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motivo_Visita_Tecnica);
        }

        // GET: Motivo_Visita_Tecnica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Visita_Tecnica motivo_Visita_Tecnica = db.Motivo_Visita_Tecnica.Find(id);
            if (motivo_Visita_Tecnica == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Visita_Tecnica);
        }

        // POST: Motivo_Visita_Tecnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motivo_Visita_Tecnica motivo_Visita_Tecnica = db.Motivo_Visita_Tecnica.Find(id);
            db.Motivo_Visita_Tecnica.Remove(motivo_Visita_Tecnica);
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
