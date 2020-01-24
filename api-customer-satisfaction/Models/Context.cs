using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_customer_satisfaction.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>().HasData(new Evaluation
            {
                Id = 1,
                Email = "ryesquen@gmail.com",
                FirstName = "Renzo",
                LastName = "Yesquén Herrera",
                Qualification = 10,
                EvaluationDate = new DateTime(2019, 03, 21)
            }, new Evaluation
            {
                Id = 2,
                Email = "nayeska.gonzales@gmail.com",
                FirstName = "Nayeska",
                LastName = "Gonzales Mauricio",
                Qualification = 5,
                EvaluationDate = new DateTime(2019, 06, 18)
            });
        }
    }
}