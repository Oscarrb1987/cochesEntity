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
    public class operacionsController : Controller
    {
        private CochesCutresEntities db = new CochesCutresEntities();

        // GET: operacions
        public ActionResult Index()
        {
            var operacion = db.operacion.Include(o => o.clientes).Include(o => o.empleados);
            return View(operacion.ToList());
        }

        // GET: operacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacion operacion = db.operacion.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // GET: operacions/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.clientes, "id", "nif");
            ViewBag.idEmpleado = new SelectList(db.empleados, "id", "nif");
            return View();
        }

        // POST: operacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipo,idEmpleado,idCliente,precio")] operacion operacion)
        {
            if (ModelState.IsValid)
            {
                db.operacion.Add(operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.clientes, "id", "nif", operacion.idCliente);
            ViewBag.idEmpleado = new SelectList(db.empleados, "id", "nif", operacion.idEmpleado);
            return View(operacion);
        }

        // GET: operacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacion operacion = db.operacion.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.clientes, "id", "nif", operacion.idCliente);
            ViewBag.idEmpleado = new SelectList(db.empleados, "id", "nif", operacion.idEmpleado);
            return View(operacion);
        }

        // POST: operacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipo,idEmpleado,idCliente,precio")] operacion operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.clientes, "id", "nif", operacion.idCliente);
            ViewBag.idEmpleado = new SelectList(db.empleados, "id", "nif", operacion.idEmpleado);
            return View(operacion);
        }

        // GET: operacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacion operacion = db.operacion.Find(id);
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // POST: operacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            operacion operacion = db.operacion.Find(id);
            db.operacion.Remove(operacion);
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
