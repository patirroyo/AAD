using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class ExtraController : Controller
    {
        public Contexto Contexto { get; }
        public ExtraController(Contexto contexto)
        {
            Contexto = contexto;
        }
        public ActionResult Index()
        {
            var lista = Contexto.Extras.ToList();
            return View(lista);
        }

        // GET: ExtraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExtraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExtraModelo extra)
        {
            Contexto.Extras.Add(extra);
            Contexto.Database.EnsureCreated();
            Contexto.SaveChanges();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExtraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExtraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExtraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExtraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
