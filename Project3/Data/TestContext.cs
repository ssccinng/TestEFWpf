using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Data
{
    public class TestContext : DbContext
    {
        private const string connectString = @"Server=(localdb)\MSSQLLocalDB;Database=TestDB_Project3;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;Connect Timeout=500";


        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
        //public TestContext()
        //{
            
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectString);

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}