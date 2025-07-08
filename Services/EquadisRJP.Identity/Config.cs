// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4.Models;

namespace EquadisRJP.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("equadisrjpapi"),
                //new ApiScope("EquadisRJPgateway")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                //List of Microservices.
                new ApiResource("EquadisRJP", "EquadisRJP.API")
                {
                    Scopes = { "equadisrjpapi"}
                },
               
                //new ApiResource("EquadisRJPGateway", "EquadisRJP Gateway")
                //{
                //    Scopes = {"EquadisRJPgateway", "basketapi"}
                //},
                
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //m2m flow 
                new Client
                {
                    ClientName = "EquadisRJP API Client",
                    ClientId = "EquadisRJPApiClient",
                    ClientSecrets = {new Secret("5c6eb3b4-61a7-4668-ac57-2b4591ec26d2".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "equadisrjpapi" }
                },


                //new Client
                //{
                //    ClientName = "EquadisRJP Gateway Client",
                //    ClientId = "EquadisRJPGatewayClient",
                //    ClientSecrets = {new Secret("5c7fd5c5-61a7-4668-ac57-2b4591ec26d2".Sha256())},
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    AllowedScopes = {"EquadisRJPgateway", "basketapi"}
                //},

            };
    };
}