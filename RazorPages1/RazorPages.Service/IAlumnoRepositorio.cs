﻿using RazorPages.Modelos; //el import de Java

namespace RazorPages.Service
{
    public interface IAlumnoRepositorio
        /*botón derecho en dependencias y agregar dependencias del proyecto
         * elegimos el Razor.Pages.Modelos y así tendremos acceso a las clases
         * de ese proyecto (ahora curso y alumnos)
         * 
         * Un repositorio es un lugar de donde se cogen datos, leyéndolo (base de datos, xml...)
         * puede haber funciones, métodos...
         * en nuestro caso serán métodos que obtengan datos de otro lado y los devuelvan transformados.
         * 
         * En un Interfaz se declaran los encabezados de las funciones que luego tendremos que implementar
         * Como el Runnable, luego te obliga a implementar las funciones que le pertenecen.
         * */
    {
        //vamos a crear un método que devuelva todos los alumnos y los devuelva en una lista, en este caso 
        //utilizamos la clase IEnumerable, actúa como la clase list
        IEnumerable<Alumno> GetAllAlumnos();
    }
}