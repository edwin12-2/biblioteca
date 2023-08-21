using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web12.Models;

namespace web12.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            using (DBModels cModel = new DBModels())
            {
                return View(cModel.libros.ToList());
            }
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels cModel = new DBModels())
            {
                return View(cModel.libros.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(libros libro)
        {
            try
            {
                using (DBModels cModel = new DBModels()) {
                    cModel.libros.Add(libro);
                    cModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels cModel = new DBModels())
            {
                return View(cModel.libros.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, libros libro)
        {
            try
            {
                using (DBModels cModel = new DBModels()) {
                    cModel.Entry(libro).State = System.Data.EntityState.Modified;
                    cModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels cModel = new DBModels())
            {
                return View(cModel.libros.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Libro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DBModels cModel = new DBModels()) {
                    libros libro = cModel.libros.Where(x => x.id == id).FirstOrDefault();
                    cModel.libros.Remove(libro);
                    cModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
