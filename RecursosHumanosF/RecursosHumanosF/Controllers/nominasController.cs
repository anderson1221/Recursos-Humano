﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecursosHumanosF.Models;

namespace RecursosHumanosF.Controllers
{
    public class nominasController : Controller
    {
        private ModulosEntities db = new ModulosEntities();

        // GET: nominas
        public ActionResult Index(string searchString)
        {
            var movies = from m in db.nomina
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Mes.Contains(searchString));
            }

            return View(movies);
        }
        public ActionResult Lista()
        {
            return View(db.Permiso.ToList());
        }

        // GET: nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nomina nomina = db.nomina.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: nominas/Create
        public ActionResult Create()
        {
            var tom = db.Empleados.Where(x => x.Estatus == "Activo").Sum(x => x.Salario);
            ViewBag.Nomina = tom;
            return View();
        }

        // POST: nominas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ano,Mes,Monto_Total")] nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.nomina.Add(nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nomina);
        }

        // GET: nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nomina nomina = db.nomina.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: nominas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ano,Mes,Monto_Total")] nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nomina);
        }

        // GET: nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nomina nomina = db.nomina.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nomina nomina = db.nomina.Find(id);
            db.nomina.Remove(nomina);
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
