using System;
using BokningSystem.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BokningSystem.API.Data
{
    public class DataContext : IdentityDbContext<User, Role, Guid,
    IdentityUserClaim<Guid>, UserRole,
    IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRole>(userRole =>
                        {
                            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                            userRole.HasOne(ur => ur.Role)
                                .WithMany(r => r.UserRoles)
                                .HasForeignKey(ur => ur.RoleId)
                                .IsRequired();
                            userRole.HasOne(ur => ur.User)
                               .WithMany(r => r.UserRoles)
                               .HasForeignKey(ur => ur.UserId)
                               .IsRequired();
                        });
            builder.Entity<User>().Ignore(c => c.PhoneNumberConfirmed)
                            .Ignore(c => c.TwoFactorEnabled)
                            .Ignore(c => c.EmailConfirmed);
        }
    }


}