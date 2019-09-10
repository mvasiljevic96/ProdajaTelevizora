using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdajaTelevizora.Models;
using System.Data.Entity;
using ProdajaTelevizora.ViewModels;

namespace ProdajaTelevizora.Controllers
{
    public class FaktureController : Controller
    {
        private ApplicationDbContext _context;
        public FaktureController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var faktura = _context.Fakturas.Include(f => f.Kupac).Include(f => f.Televizor).ToList();
            return View(faktura);
        }

        public ActionResult New()
        {
            var viewModel = new FakturaFormViewModel()
            {
                Fakture = new Faktura(),
                Televizori = _context.Televizors.ToList(),
                Kupci = _context.Kupacs.ToList()
            };
            return View("FakturaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Faktura faktura)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FakturaFormViewModel()
                {
                    Fakture = faktura,
                    Televizori = _context.Televizors.ToList(),
                    Kupci = _context.Kupacs.ToList()
                };

                return View("FakturaForm", viewModel);
            }

            if (faktura.Id == 0)
            {
                _context.Fakturas.Add(faktura);
            }
            else
            {
                var fakturaInDb = _context.Fakturas.Single(r => r.Id == faktura.Id);

                fakturaInDb.DatumKupovine = faktura.DatumKupovine;
                fakturaInDb.Kupac = faktura.Kupac;
                faktura.Televizor = faktura.Televizor;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Fakture");
        }

        public ActionResult Edit(int id)
        {
            var faktura = _context.Fakturas.SingleOrDefault(r => r.Id == id);
            if (faktura == null)
            {
                return HttpNotFound();
            }
            var viewModel = new FakturaFormViewModel()
            {
                Fakture = faktura,
                Kupci = _context.Kupacs.ToList(),
                Televizori = _context.Televizors.ToList()
            };
            return View("FakturaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var faktura = _context.Fakturas.Find(id);

            if (faktura == null)
            {
                return HttpNotFound();
            }

            _context.Fakturas.Remove(faktura);
            _context.SaveChanges();
            return RedirectToAction("Index", "Fakture");
        }
    }
}
