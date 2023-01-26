using APIIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIIdentity.Data
{
    public class ApiContext : IdentityDbContext<CustomUser>
    {
        public ApiContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomUserToken> CustomUserTokens { get; set; }
    }
}
