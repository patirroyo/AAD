using System;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Services;

namespace ProjectFutbol.Components
{
	public class ProvinciasComunidadViewComponent : ViewComponent
	{
        public IProvinciaRepositorio ProvinciaRepositorio { get; }

        public ProvinciasComunidadViewComponent(IProvinciaRepositorio provinciaRepositorio)
		{
            ProvinciaRepositorio = provinciaRepositorio;
        }

        public IViewComponentResult Invoke(Comunidad? comunidad= null) //puede recibir un objto categoria o no, en ese caso será null
        {

            var resultado = ProvinciaRepositorio.ProvinciasPorComunidad(comunidad);
            return View(resultado);
        }
    }
}

