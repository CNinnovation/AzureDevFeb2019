using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithEFCore.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [MaxLength(80)]
        public string Title { get; set; }
        [MaxLength(40)]
        public string Publisher { get; set; }
    }
}
