using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cochesEntity;

namespace cochesEntity.Controllers
{
    public class vehiculosController : Controller
    {
        private CochesCutresEntities db = new CochesCutresEntities();

        // GET: vehiculos
        public ActionResult Index()
        {
            return View(db.vehiculos.ToList());
        }

        // GET: vehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = db.vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // GET: vehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vehiculos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,marca,modelo,numPuertas,color,kilometros,tipoVehiculo,garantia,stock,fotografia")] vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.vehiculos.Add(vehiculos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiculos);
        }

        // GET: vehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = db.vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // POST: vehiculos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,marca,modelo,numPuertas,color,kilometros,tipoVehiculo,garantia,stock,fotografia")] vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiculos);
        }

        // GET: vehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = db.vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // POST: vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehiculos vehiculos = db.vehiculos.Find(id);
            db.vehiculos.Remove(vehiculos);
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
