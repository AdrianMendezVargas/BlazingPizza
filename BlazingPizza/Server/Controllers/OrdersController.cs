using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BlazingPizza.Server.Models;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<List<OrderWithStatus>>> GetOrders() {
            var Orders = await Context.Orders
                .Include(o => o.DeliveryLocation)
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                .OrderByDescending(o => o.CreatedTime)
                .ToListAsync();

            return Orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderWithStatus>> GetOrderWithStatus(int orderId) {

            var order = await Context.Orders.Where(o => o.OrderId == orderId)
                .Include(o => o.DeliveryLocation)
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                .SingleOrDefaultAsync();

            if (order == null) {
                return NotFound();
            } else {
                return OrderWithStatus.FromOrder(order);
            }

        }
       

    }
}
