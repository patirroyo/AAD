using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class SucursalController : Controller
    {
        public Contexto Contexto { get; } //Se crea un objeto de la clase contexto, para poder usar sus métodos (acceder a la base de datos)

        public SucursalController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: SucursalController
        public ActionResult Index()
        {
            List<SucursalModelo> lista = Contexto.Sucursales.ToList();
            return View(lista);
        }

        // GET: SucursalController/Details/5
        public ActionResult Details(int id)
        {
       
            return View();
        }

        public ActionResult Busqueda(int searchFor = 0)
        {
            ViewBag.sucursales = new SelectList(Contexto.Sucursales, "Id", "Nombre", searchFor);
            var list = from v in Contexto.Vehiculos.Include(v => v.Serie)
                       where v.SucursalId.Equals(searchFor)
                       select v;

            return View(list); //devuelve la vista

        }

        // GET: SucursalController/Create
        public ActionResult Create()
        {
            ViewBag.VehiculoId = new SelectList(Contexto.Vehiculos, "Id", "Matricula");
            return View();
        }

        // POST: SucursalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SucursalModelo sucursal)
        {
            Contexto.Sucursales.Add(sucursal);
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

        // GET: SucursalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SucursalController/Edit/5
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

        // GET: SucursalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SucursalController/Delete/5
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
