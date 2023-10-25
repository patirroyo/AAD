using System;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Service
{
	internal class ColegioBDContext : DbContext
	{
        public ColegioBDContext(DbContextOptions options) : base(options)
        {
        }
    }
}

