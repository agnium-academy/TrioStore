﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStoreWA.Infrastructure.Identity
{
    public class StoreIdentityDbContext : IdentityDbContext<StoreUser>
    {
        public StoreIdentityDbContext() : base("SportsStoreIdentityDb")
        {
            Database.SetInitializer<StoreIdentityDbContext>(new
            StoreIdentityDbInitializer());
        }
        public static StoreIdentityDbContext Create()
        {
            return new StoreIdentityDbContext();
        }
    }
}