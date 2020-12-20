using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazingPizza.Shared;

namespace BlazingPizza.Client.Services {
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider {
        private readonly HttpClient HttpClient;

        public ServerAuthenticationStateProvider(HttpClient httpClient) {
            HttpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {

            var UserInfo = await HttpClient.GetFromJsonAsync<UserInfo>("user");

            var Identity = UserInfo.IsAuthenticaded
                ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name , UserInfo.Name) }, "serverauth")
                : new ClaimsIdentity();

            return new AuthenticationState(new ClaimsPrincipal(Identity));
        }
    }
}
