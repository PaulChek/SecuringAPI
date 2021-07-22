using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer {
    public static class Config {
        public static IEnumerable<Client> Clients => new Client[] {
          new() {
            ClientId = "MovieClient",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = { "Movie.API" }
          }
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] { new("Movie.API") };
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] { };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] { };
        public static IEnumerable<TestUser> TestUsers => new TestUser[] { };
    }
}
