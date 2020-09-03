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
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }


        //TODO: Usar notacion en las entidades para no tener que hacer las relaciones manualmente

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Fluent API
            modelBuilder.Entity<PizzaTopping>()
                .HasKey(pst => new { pst.PizzaId , pst.ToppingId });
            
            modelBuilder.Entity<PizzaTopping>()
                .HasOne<Pizza>().WithMany(ps => ps.Toppings);

            modelBuilder.Entity<PizzaTopping>()
                .HasOne(ps => ps.Topping).WithMany();

            modelBuilder.Entity<Order>().OwnsOne(o => o.DeliveryLocation);


        }

    }
}
