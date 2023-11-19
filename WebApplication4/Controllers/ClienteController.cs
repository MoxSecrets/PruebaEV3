using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DbModel context = new DbModel())
            {
                return View(context.Clientes.ToList());
            }
                
        }

        // GET: Cliente/Details/5
        public ActionResult Details(string Rut)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.Clientes.Where(x => x.Rut == Rut).FirstOrDefault());
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Clientes clientes)
        {
            try
            {
                using (DbModel context = new DbModel())
                {
                    context.Clientes.Add(clientes);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(string Rut)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.Clientes.Where(x => x.Rut == Rut).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clientes clientes)
        {
            try
            {
                using (DbModel context = new DbModel())
                {
                    context.Entry(clientes).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(string Rut)
        {
            using (DbModel context = new DbModel())
            {
                return View(context.Clientes.Where(x => x.Rut == Rut).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(string Rut, FormCollection collection)
        {
            try
            {
                using (DbModel context = new DbModel())
                {
                    Clientes clientes = context.Clientes.Where(x => x.Rut == Rut).FirstOrDefault();
                    context.Clientes.Remove(clientes);
                    context.SaveChanges();
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
