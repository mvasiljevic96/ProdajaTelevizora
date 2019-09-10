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
    public class TelevizoriController : Controller
    {
        private ApplicationDbContext _context;
        public TelevizoriController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       
        public ActionResult Index()
        {
            var televizori = _context.Televizors.Include(t => t.TehnologijaEkrana).ToList();
            return View(televizori);
        }

        public ActionResult New()
        {
            var tehnologijaEkrana = _context.TehnologijaEkranas.ToList();
            var viewModel = new TelevizorFormViewModel
            {
                Televizor= new Televizor(),
                TehnlogijeEkrana = tehnologijaEkrana
            };
            return View("TelevizorForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Televizor televizor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TelevizorFormViewModel
                {
                    Televizor = televizor,
                    TehnlogijeEkrana = _context.TehnologijaEkranas.ToList()
                };
                return View("TelevizorForm", viewModel);
            }
            if (televizor.Id == 0)
            {
                _context.Televizors.Add(televizor);
            }
            else
            {
                var televizorInDb = _context.Televizors.Single(c => c.Id == televizor.Id);

                televizorInDb.Naziv = televizor.Naziv;
                televizorInDb.DijagonalaEkrana = televizor.DijagonalaEkrana;
                televizorInDb.Dimenzije = televizor.Dimenzije;
                televizorInDb.TehnologijaEkrana = televizor.TehnologijaEkrana;
                televizorInDb.Cijena = televizor.Cijena;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Televizori");
        }

        public ActionResult Edit(int id)
        {
            var televizori = _context.Televizors.SingleOrDefault(p => p.Id == id);

            if (televizori == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TelevizorFormViewModel
            {
                Televizor = televizori,
                TehnlogijeEkrana = _context.TehnologijaEkranas.ToList()
            };
            return View("TelevizorForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var televizor = _context.Televizors.Find(id);

            if (televizor == null)
            {
                return HttpNotFound();
            }

            _context.Televizors.Remove(televizor);
            _context.SaveChanges();
            return RedirectToAction("Index", "Televizori");
        }
    }
}