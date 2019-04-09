using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace GuildCarsUI.Models
{
    public class GuildCarsDbContext : IdentityDbContext<AppUser>
    {
        public GuildCarsDbContext() : base("GuildCars")
        {
        }
    }
}
