using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChequeSYs.Models;

namespace ChequeSYs.Data
{
    public class ChequeSYsContext : DbContext
    {
        public ChequeSYsContext (DbContextOptions<ChequeSYsContext> options)
            : base(options)
        {
        }

        public DbSet<ChequeSYs.Models.Amount> Amount { get; set; }
    }
}
