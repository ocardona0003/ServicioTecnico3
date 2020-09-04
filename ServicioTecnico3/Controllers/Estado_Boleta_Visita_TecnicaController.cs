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
    public class Estado_Boleta_Visita_TecnicaController : Controller
    {
        private herracentroV2Entities1 db = new herracentroV2Entities1();

        // GET: Estado_Boleta_Visita_Tecnica
        public ActionResult Index()
        {
            return View(db.Estado_Boleta_Visita_Tecnica.ToList());
        }

        // GET: Estado_Boleta_Visita_Tecnica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Boleta_Visita_Tecnica estado_Boleta_Visita_Tecnica = db.Estado_Boleta_Visita_Tecnica.Find(id);
            if (estado_Boleta_Visita_Tecnica == null)
            {
                return HttpNotFound();
            }
            return View(estado_Boleta_Visita_Tecnica);
        }

        // GET: Estado_Boleta_Visita_Tecnica/Create
        public ActionResult Create()
        {
            var max = db.Estado_Boleta_Visita_Tecnica.ToList().Max(r => r.id);
            Estado_Boleta_Visita_Tecnica estado = new Estado_Boleta_Visita_Tecnica();
            estado.id = max + 1;
            return View(estado);
        }

        // POST: Estado_Boleta_Visita_Tecnica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Estado_Boleta_Visita_Tecnica estado_Boleta_Visita_Tecnica)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Boleta_Visita_Tecnica.Add(estado_Boleta_Visita_Tecnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Boleta_Visita_Tecnica);
        }

        // GET: Estado_Boleta_Visita_Tecnica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Boleta_Visita_Tecnica estado_Boleta_Visita_Tecnica = db.Estado_Boleta_Visita_Tecnica.Find(id);
            if (estado_Boleta_Visita_Tecnica == null)
            {
                return HttpNotFound();
            }
            return View(estado_Boleta_Visita_Tecnica);
        }

        // POST: Estado_Boleta_Visita_Tecnica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] Estado_Boleta_Visita_Tecnica estado_Boleta_Visita_Tecnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Boleta_Visita_Tecnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Boleta_Visita_Tecnica);
        }

        // GET: Estado_Boleta_Visita_Tecnica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Boleta_Visita_Tecnica estado_Boleta_Visita_Tecnica = db.Estado_Boleta_Visita_Tecnica.Find(id);
            if (estado_Boleta_Visita_Tecnica == null)
            {
                return HttpNotFound();
            }
            return View(estado_Boleta_Visita_Tecnica);
        }

        // POST: Estado_Boleta_Visita_Tecnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Boleta_Visita_Tecnica estado_Boleta_Visita_Tecnica = db.Estado_Boleta_Visita_Tecnica.Find(id);
            db.Estado_Boleta_Visita_Tecnica.Remove(estado_Boleta_Visita_Tecnica);
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
