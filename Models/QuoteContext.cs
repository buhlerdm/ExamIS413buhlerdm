using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamIS413.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {

        }

        public DbSet<Quote> quotes { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Quote>().HasData(


                new Quote
                {
                    QuoteID = 1,
                    QuoteSentence = "this is a test",
                    Author = "Mitch",
                    Date = "Today"
                }


                );
        }
    }



    // Seed Data

   

}
