using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class GamesContext : IdentityDbContext<IdentityUser>
    {
        public GamesContext(DbContextOptions<GamesContext> opt) : base(opt) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
