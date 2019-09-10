using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdajaTelevizora.Models;



namespace ProdajaTelevizora.Controllers
{
    public class KupciController : Controller
    {
        private ApplicationDbContext _context;
        public KupciController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       
        public ActionResult Index()
        {
            var kupac = _context.Kupacs.ToList();
            return View(kupac);
        }
        public ActionResult New()
        {
            return View("KupacForm", new Kupac());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                return View("KupacForm", kupac);
            }

            if (kupac.Id == 0)
            {
                _context.Kupacs.Add(kupac);
            }
            else
            {
                var kupacInDb = _context.Kupacs.Single(i => i.Id == kupac.Id);

                kupacInDb.Ime = kupac.Ime;
                kupacInDb.Adresa = kupac.Adresa;
                kupacInDb.BrojTelefona = kupac.BrojTelefona;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Kupci");
        }

        public ActionResult Edit(int id)
        {
            var kupac = _context.Kupacs.SingleOrDefault(i => i.Id == id);

            if (kupac == null)
            {
                return HttpNotFound();
            }

            return View("KupacForm", kupac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            var kupac = _context.Kupacs.Find(id);

            if (kupac == null)
            {
                return HttpNotFound();
            }

            _context.Kupacs.Remove(kupac);

            _context.SaveChanges();

            return RedirectToAction("Index", "Kupci");
        }
    }


}
