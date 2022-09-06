using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp3
{
    internal class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
