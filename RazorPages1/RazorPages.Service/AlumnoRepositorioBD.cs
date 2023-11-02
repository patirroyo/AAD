using System;
namespace RazorPages.Service
{
	public class AlumnoRepositorioBD
	{
        private readonly ColegioDbContext context;

        public AlumnoRepositorioBD(ColegioDbContext context)
		{
            this.context = context;
        }
	}
}

