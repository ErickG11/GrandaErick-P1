using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GrandaErick_P1.Models;

    public class GrandaErickContext : DbContext
    {
        public GrandaErickContext (DbContextOptions<GrandaErickContext> options)
            : base(options)
        {
        }

        public DbSet<GrandaErick_P1.Models.EGranda> EGranda { get; set; } = default!;

public DbSet<GrandaErick_P1.Models.Celular> Celular { get; set; } = default!;
    }
