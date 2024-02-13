using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class MarcaController : Controller
    {
        //Aqui se crean los metodos que se van a llamar desde las vistas

        //Los metodos tendran el mismo nombre que las vistas


        public Contexto Contexto { get; } //Se crea un objeto de la clase contexto, para poder usar sus métodos (acceder a la base de datos)

        public MarcaController(Contexto contexto)
        {
            Contexto = contexto;
            
        }



        // GET: marcaController
        public ActionResult Index() //metodo que devuelve una vista
        {
            List<MarcaModelo> lista = Contexto.Marcas.ToList(); //crea una lista de marcas y la rellena con los datos de la tabla marcas
            return View(lista); //devuelve la vista
        }

        public ActionResult Listado() //metodo que devuelve una vista
        {
            List<MarcaModelo> lista = Contexto.Marcas.ToList(); //crea una lista de marcas y la rellena con los datos de la tabla marcas
            return View(lista); //devuelve la vista
        }

        public ActionResult Desplegable()
        {
            ViewBag.Marcas = new SelectList(Contexto.Marcas, "Id", "Nom_Marca") ;//ViewBag Es un contenedor que existe y gracias a esto guardamos cosas
            ViewBag.Marcas2 = Contexto.Marcas.ToList();
            return View();
        }

        // GET: marcaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //El método create esta declarado 2 veces, a la página del create se puede acceder a su método de dos maneras. A través del onGet o del onPost
        //Si se reciben parametros se accede al onPost, si no se reciben parametros se accede al onGet
        //Es decir, si se recibe un formulario se accede al onPost, si no se recibe un formulario se accede al onGet

        // GET: marcaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: marcaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaModelo marca)
        {
            Contexto.Marcas.Add(marca); //añade la marca a la tabla marcas
            Contexto.Database.EnsureCreated(); //asegura que la base de datos se ha creado
            Contexto.SaveChanges(); //guarda los cambios en la base de datos
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: marcaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: marcaController/Edit/5
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

        // GET: marcaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: marcaController/Delete/5
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