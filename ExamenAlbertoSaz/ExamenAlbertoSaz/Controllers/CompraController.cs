using ExamenAlbertoSaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace ExamenAlbertoSaz.Controllers
{
    public class CompraController : Controller
    {
        public class Stock //una clase dentro de otra clase, para poder hacer una consulta con datos de varias tablas
        {
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public int PrecioMedio { get; set; }
           
        }
        public Contexto Contexto { get; }
        public CompraController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: CompraController
        public ActionResult Index()
        {
            List<CompraModelo> compras = Contexto.Compras.Include(c => c.Producto).Include(c => c.Proveedor).ToList();
            return View(compras);
        }

        public ActionResult getStock()
        {
            var stock = Contexto.Stock.FromSql($"Execute getStock").ToList();
            return View(stock);
        }


        // GET: CompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompraController/Edit/5
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

        // GET: CompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompraController/Delete/5
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
