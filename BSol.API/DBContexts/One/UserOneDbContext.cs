using BSol.API.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BSol.API.DBContexts.One
{
    public class UserOneDbContext : IdentityDbContext<UserOne>
    {
        public UserOneDbContext(DbContextOptions<UserOneDbContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(300);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserOne>()
            .ToTable("UserOne");
        }
    }
}
