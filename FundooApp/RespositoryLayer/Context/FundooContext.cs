using Microsoft.EntityFrameworkCore;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespositoryLayer.Context
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users
        {
            get; set;
        }
        public DbSet<Notes> NotesTable { get; set; }
    }
}