using BSol.API.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BSol.API.DBContexts.Four
{
    public class UserFourDbContext : IdentityDbContext<UserFour>
    {
        public UserFourDbContext(DbContextOptions<UserFourDbContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(300);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFour>()
            .ToTable("UserFour");

            builder.Ignore<IdentityRole>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUser>();
        }
    }
}
