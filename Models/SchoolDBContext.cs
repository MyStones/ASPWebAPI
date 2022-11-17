using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Entity;

namespace ASPWebAPI5.Models
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("SchoolDB")
        {
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>()); 
            Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDBContext, EFCodeFirstConsoleApp2.Migrations.Configuration>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Maps all entties to use SPs for Insert, Update and Delete
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }
    }
}
