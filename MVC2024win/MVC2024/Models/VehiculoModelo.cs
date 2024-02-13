﻿namespace MVC2024.Models
{
    public class VehiculoModelo
    {
        public int Id { get; set; }
        public String Matricula { get; set; }
        public String Color { get; set; }
        public int SerieId {get; set;}
        public int SucursalId { get; set; }
        public SerieModelo Serie { get; set; }
        public SucursalModelo Sucursal { get; set; }
    }
}
