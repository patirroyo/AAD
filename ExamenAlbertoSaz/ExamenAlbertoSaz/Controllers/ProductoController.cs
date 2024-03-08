using ExamenAlbertoSaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace ExamenAlbertoSaz.Controllers
{
    public class ProductoController : Controller
    {
        public Contexto Contexto { get; }
        public ProductoController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            List<ProductoModelo> productos = Contexto.Productos.ToList();
            
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Productos = new SelectList(Contexto.Productos, "Id", "Nombre", id);
            if (id == 0)
            {
                ViewBag.Compras = new List<CompraModelo>();
                ViewBag.Ventas = new List<VentaModelo>();

                return View();
            }
            ProductoModelo producto = Contexto.Productos.Where(p => p.Id == id).FirstOrDefault();
            var compras = Contexto.Compras.Include(c => c.Proveedor).Where(c => c.ProductoId == id).OrderBy(c => c.Fecha);
            ViewBag.cantidadComprada = compras.Sum(c => c.Cantidad);
            var precioTotalCompra = 0;
            foreach (var compra in compras)
            {
                precioTotalCompra += compra.Cantidad * compra.Precio;
            }
            ViewBag.precioCompra = precioTotalCompra;
            ViewBag.Compras = compras;

            var ventas = Contexto.Ventas.Include(v => v.Cliente).Where(v => v.ProductoId == id).OrderBy(v => v.Fecha);
            ViewBag.cantidadVendida = ventas.Sum(v => v.Cantidad);
            var precioTotalVenta = 0;
            foreach (var venta in ventas)
            {
                precioTotalVenta += venta.Cantidad * venta.Precio;
            }
            ViewBag.precioVenta = precioTotalVenta;
            ViewBag.Ventas = ventas;
            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModelo producto)
        {
            Contexto.Productos.Add(producto);
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

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
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

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
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
