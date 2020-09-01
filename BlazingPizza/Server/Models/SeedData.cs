using BlazingPizza.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Server.Models {
    public static class SeedData {

        public static void Initialize(PizzaStoreContext context) {

            var Specials = new PizzaSpecial[]
            {
                new PizzaSpecial()
                {
                    //Id = 1,
                    Name = "Basic Cheese Pizza",
                    Description = "It's cheesy and delicious. Why wouldn't you want one?",
                    BasePrice = 9.99m,
                    ImageUrl = "images/pizzas/cheese.jpg",
                },
                new PizzaSpecial()
                {
                    //Id = 2,
                    Name = "The Baconatorizor",
                    Description = "It has EVERY kind of bacon",
                    BasePrice = 11.99m,
                    ImageUrl = "images/pizzas/bacon.jpg",
                },
                new PizzaSpecial()
                {
                    //Id = 3,
                    Name = "Classic pepperoni",
                    Description = "It's the pizza you grew up with, but Blazing hot!",
                    BasePrice = 10.50m,
                    ImageUrl = "images/pizzas/pepperoni.jpg",
                },
                new PizzaSpecial()
                {
                    //Id = 4,
                    Name = "Buffalo chicken",
                    Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                    BasePrice = 12.75m,
                    ImageUrl = "images/pizzas/meaty.jpg",
                },
                new PizzaSpecial()
                {
                    //Id = 5,
                    Name = "Mushroom Lovers",
                    Description = "It has mushrooms. Isn't that obvious?",
                    BasePrice = 11.00m,
                    ImageUrl = "images/pizzas/mushroom.jpg",
                },
                new PizzaSpecial()
                {
                    //Id = 6,
                    Name = "The Brit",
                    Description = "When in London...",
                    BasePrice = 10.25m,
                    ImageUrl = "images/pizzas/hawaiian.jpg",
                },
                new PizzaSpecial()
                {
                    //Id = 7,
                    Name = "Veggie Delight",
                    Description = "It's like salad, but on a pizza",
                    BasePrice = 11.50m,
                    ImageUrl = "images/pizzas/salad.jpg",
                },
                new PizzaSpecial()
                {
                    //Id = 8,
                    Name = "Margherita",
                    Description = "Traditional Italian pizza with tomatoes and basil",
                    BasePrice = 9.99m,
                    ImageUrl = "images/pizzas/margherita.jpg",
                },
            };

            context.AddRange(Specials);
            context.SaveChanges();

        }
    }
}
