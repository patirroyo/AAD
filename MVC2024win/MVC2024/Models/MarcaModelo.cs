﻿using System;
namespace MVC2024.Models
{
	public class MarcaModelo
	{
		public int Id { get; set; }
		public string Nom_Marca { get; set; }
		public List<SerieModelo> LasSeries { get; set; }
	}
}

