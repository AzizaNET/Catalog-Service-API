using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.DAL.Contracts.Entities;

namespace Catalog.DAL.Implementation
{
    public class DataContext:DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ItemEntity> Items { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync(); 
        }
        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}
