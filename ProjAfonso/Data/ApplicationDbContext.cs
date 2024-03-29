﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjAfonso.Models;

namespace ProjAfonso.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Tclientes { get; set; }
        public DbSet<Funcionario> Tfuncionarios { get; set; }
        public DbSet<Reuniao> Treunioes { get; set; }
    }
}
