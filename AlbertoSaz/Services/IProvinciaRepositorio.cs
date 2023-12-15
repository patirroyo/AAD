using System;
using Modelos;

namespace Services
{
	public interface IProvinciaRepositorio
	{
        IEnumerable<Provincia> GetAllProvincias();
        Provincia GetProvinciaById(int id);
        IEnumerable<ComunidadCuantos> ProvinciasPorComunidad(Comunidad? comunidad);
        public IEnumerable<Provincia> FindProvinciasByComunidad(Comunidad elementoABuscar);
    }
}

