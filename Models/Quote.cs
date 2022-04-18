using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamIS413.Models
{
    public class Quote
    {
        [Key]
        public int QuoteID { get; set; }

        [Required(ErrorMessage = "Please Enter Quote.")]
        public string QuoteSentence { get; set; }

        [Required(ErrorMessage = "Please Enter Authoer")]
        public string Author { get; set; }

        public string Date { get; set; }

        public string Subject { get; set; }

        public string Citation { get; set; }


    }
}
