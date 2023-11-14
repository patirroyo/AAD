﻿using System;
using Modelos;

namespace Services
{
	public interface IEquipoRepositorio
	{
        IEnumerable<Equipo> GetAllEquipos();
        Equipo GetEquipoById(int id);
        void Update(Equipo equipoActualizado);
        void Add(Equipo equipoNuevo);
        Equipo Delete(int idBorrar);
    }
}

