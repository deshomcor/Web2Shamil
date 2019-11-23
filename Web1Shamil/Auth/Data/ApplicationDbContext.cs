using System;
using System.Collections.Generic;
using System.Text;
using Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<ErrorViewModel> ErrorViewModel;
        DbSet<Users> Users;
        public DbSet<Auth.Models.Users> Users_1 { get; set; }
    }
}
