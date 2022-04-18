using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamIS413.Models
{
    public class EFProjectRepository : IProjectRepository
    {
        private QuoteContext context {get; set;}


        public EFProjectRepository(QuoteContext temp)
        {
            context = temp;
        }

        public IQueryable<Quote> Quotes => context.quotes;

    }
}
