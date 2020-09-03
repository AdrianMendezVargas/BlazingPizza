using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BlazingPizza.Server.Models;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Server.Controllers {
    [Route("/orders")]
    [ApiController]
    public class OrdersController : ControllerBase {

        private readonly PizzaStoreContext Context;

        public OrdersController(PizzaStoreContext context) {
            Context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PlaceOrder(Order order) {

            order.CreatedTime = DateTime.Now;
            order.DeliveryLocation = new LatLong() { Latitude = 19.275673 , Longitude = -70.256430 };

            foreach (var Pizza in order.Pizzas) {
                Pizza.SpecialId = Pizza.Special.Id;
                Pizza.Special = null;
                foreach (var Topping in Pizza.Toppings) {
                    Topping.ToppingId = Topping.Topping.Id;
                    Topping.Topping = null;
                }
            }

            Context.Orders.Attach(order);
            await Context.SaveChangesAsync();

            return order.OrderId;
        }
       

    }
}
