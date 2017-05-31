using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.DataAccess
{
    public class IluminaContext:DbContext
    {
        public IluminaContext():base("IluminaMVCConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<RoleOption> RoleOption { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Suggestion> Suggestion { get; set; }
        public virtual DbSet<Option> Option { get; set; }
    }
}
