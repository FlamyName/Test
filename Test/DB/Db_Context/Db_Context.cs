using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DB.Models;

namespace Test.DB.Db_Context
{
    internal class Db_Context : DbContext
    {
        SqlConnection _connection = new SqlConnection(@"Data Source=DESKTOP-95OBH0L\SQLEXPRESS;Initial Catalog=Database;Database=Example;Integrated Security=true;TrustServerCertificate=true");
        //SqlConnection _connection1 = new SqlConnection(@"Data Source=DESKTOP-95OBH0L\SQLEXPRESS;User Id=stud; Password=stud;Initial Catalog=Database;Database=Example;TrustServerSertificate=true");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }


        public DbSet<Master> Masters { get; set; }
        public DbSet<OrderClient> OrderClients { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuss { get; set; }

    }
}
