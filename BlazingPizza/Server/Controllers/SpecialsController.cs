﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Server.Models;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazingPizza.Server.Controllers {
    [Route("/specials")]
    [ApiController]
    public class SpecialsController : ControllerBase {

        private readonly PizzaStoreContext Context;
        public SpecialsController(PizzaStoreContext context) {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials() {
            return await Context.Specials
                .OrderByDescending(s => s.BasePrice).ToListAsync();
        }

    }
}
