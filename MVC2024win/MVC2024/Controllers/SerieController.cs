using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class SerieController : Controller
    {
        public Contexto Contexto { get; } //Se crea un objeto de la clase contexto, para poder usar sus métodos (acceder a la base de datos)

        public SerieController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: SerieController
        public ActionResult Index()
        {
            List<SerieModelo> lista = Contexto.Series.Include(s => s.Marca).ToList(); //crea una lista de marcas y la rellena con los datos de la tabla marcas. El include especificamos que le añadimos un objeto de otra clase, el campo Marca de SerieModelo.cs
            return View(lista); //devuelve la vista
        }

        public ActionResult Listado(int id)
        {
            //Contexto.Marcas.Find(id).LasSeries = Contexto.Series.Where(s => s.MarcaId == id).ToList();
            //return View(Contexto.Marcas.Find(id)); //devuelve la vista
            return View(Contexto.Marcas.Include(m => m.LasSeries).FirstOrDefault(m => m.Id == id));
        }

        // GET: SerieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SerieController/Create
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(Contexto.Marcas, "Id", "Nom_Marca");
            return View();
        }

        // POST: SerieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SerieModelo serie)
        {
            Contexto.Series.Add(serie);
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

        // GET: SerieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SerieController/Edit/5
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

        // GET: SerieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SerieController/Delete/5
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
