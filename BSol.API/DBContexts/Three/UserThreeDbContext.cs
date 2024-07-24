using BSol.API.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BSol.API.DBContexts.Three
{
    public class UserThreeDbContext : IdentityDbContext<UserThree>
    {
        public UserThreeDbContext(DbContextOptions<UserThreeDbContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(300);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserThree>()
            .ToTable("UserThree");

            builder.Ignore<IdentityRole>();
            builder.Ignore<IdentityUser>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
        }
    }
}
