﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Server.Controllers {

    [ApiController]
    public class UserController : ControllerBase {

        private static UserInfo LoggedOutUser = new UserInfo { IsAuthenticaded = false };

        [HttpGet("user")]
        public UserInfo GetUser() {
            return User.Identity.IsAuthenticated
                ? new UserInfo { IsAuthenticaded = true , Name = User.Identity.Name }
                : LoggedOutUser;
        }

        [HttpGet("user/signin")]
        public async Task SignIn(string redirectUri) {

            if (string.IsNullOrEmpty(redirectUri) ) {
                redirectUri = "/";
            }

            await HttpContext.ChallengeAsync(TwitterDefaults.AuthenticationScheme ,
                new AuthenticationProperties { RedirectUri = redirectUri });

        }

        [HttpGet("user/signout")]
        public async Task<ActionResult> SignOut() {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/");
        }

    }
}
