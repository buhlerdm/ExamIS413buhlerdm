using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamIS413.Models
{
    public interface IProjectRepository
    {
        IQueryable<Quote> Quotes { get; }

    }
}
