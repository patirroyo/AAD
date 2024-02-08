using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class VehiculoController : Controller
    {
        public class VehiculoTotal //una clase dentro de otra clase, para poder hacer una consulta con datos de varias tablas
        {
            public string Nom_Marca { get; set; }
            public string NomSerie { get; set; }
            public string Matricula { get; set; }
            public string Color { get; set; }
        }
        public Contexto Contexto { get; } //Se crea un objeto de la clase contexto, para poder usar sus métodos (acceder a la base de datos)

        public VehiculoController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: VehiculoController
        public ActionResult Index()
        {
            /*
            ViewBag.marcas = Contexto.Marcas.ToList();
            var lista = Contexto.Vehiculos.Include(v => v.Serie).ToList(); */
            List<VehiculoModelo> lista = Contexto.Vehiculos.Include(v => v.Serie).Include(v => v.Serie.Marca).ToList(); //crea una lista de vehiculos y la rellena con los datos de la tabla serie. El include especificamos que le añadimos un objeto de otra clase
           
            return View(lista); //devuelve la vista
        }

        public ActionResult Listado2()
        {
            List<VehiculoTotal> lista = Contexto.VistaTotal.ToList();
            return View(lista); //devuelve la vista
        }

        public ActionResult Busqueda(string searchFor ="")
        {
            ViewBag.searchFor = searchFor;
            var list = from v in Contexto.Vehiculos.Include(v =>v.Serie)
                           where v.Matricula.Contains(searchFor)
                           select v;      

            return View(list); //devuelve la vista
        }
        public ActionResult Busqueda2(string searchFor = "")
        {
            ViewBag.matriculas = new SelectList(Contexto.Vehiculos, "Matricula", "Matricula", searchFor);
            var list = from v in Contexto.Vehiculos.Include(v => v.Serie)
                       where v.Matricula.Equals(searchFor)
                       select v;

            return View(list); //devuelve la vista
        }

        public ActionResult Busqueda3(int searchMarca = 0, int searchModelo = 0)
        {
            ViewBag.marcas = new SelectList(Contexto.Marcas, "Id", "Nom_Marca", searchMarca);
            
            if (searchMarca != 0 && searchMarca != null) {
               // var marca = Contexto.Marcas.FirstOrDefault(m => m.Id == searchMarca);
                IEnumerable<SerieModelo> modelos = from m in Contexto.Series
                                                   where m.MarcaId == searchMarca
                                                   select m;

                ViewBag.modelos = new SelectList(modelos, "Id", "NomSerie", searchModelo);
            }
            var list = from v in Contexto.Vehiculos.Include(v => v.Serie).Include(v => v.Serie.Marca)
                       where v.Serie.Marca.Id.Equals(searchMarca) && v.Serie.Id.Equals(searchModelo)
                       select v;

            return View(list); //devuelve la vista
        }

        // GET: VehiculoController/Details/5
        public ActionResult Details(int id)
        {
            VehiculoModelo vehiculo = Contexto.Vehiculos.Include("Serie.Marca").FirstOrDefault(v => v.Id == id);//incluimos Serie y Marca de una vez, no hace falta usar el ViewBag
            //ViewBag.Serie = Contexto.Series.Find(vehiculo.SerieId);
            //ViewBag.Marca = Contexto.Marcas.Find(ViewBag.MarcaId);
            return View(vehiculo);
        }

        // GET: VehiculoController/Create
        public ActionResult Create()
        {
            ViewBag.SerieId = new SelectList(Contexto.Series, "Id", "NomSerie");
            return View();
        }

        // POST: VehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehiculoModelo vehiculo)
        {
            Contexto.Vehiculos.Add(vehiculo);
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

        // GET: VehiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SerieId = new SelectList(Contexto.Series, "Id", "NomSerie");
            VehiculoModelo vehiculo = Contexto.Vehiculos.Find(id);
            return View(vehiculo);
        }

        // POST: VehiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehiculoModelo cocheDatosNew)
        {
            VehiculoModelo cocheDatosOld = Contexto.Vehiculos.Find(id);
            cocheDatosOld.Matricula = cocheDatosNew.Matricula;
            cocheDatosOld.Color = cocheDatosNew.Color;
            cocheDatosOld.SerieId = cocheDatosNew.SerieId;
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

        // GET: VehiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            VehiculoModelo vehiculo = Contexto.Vehiculos.Include("Serie.Marca").FirstOrDefault(v => v.Id == id);
            return View(vehiculo);
        }

        // POST: VehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            VehiculoModelo cocheBorrar = Contexto.Vehiculos.Find(id);
            Contexto.Vehiculos.Remove(cocheBorrar);
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
    }
}
