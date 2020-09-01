using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Shared;

namespace BlazingPizza.Server.Models {
    public class PizzaStoreContext : DbContext {

        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options) {

        } 

        public DbSet<PizzaSpecial> Specials { get; set; }

    }
}
