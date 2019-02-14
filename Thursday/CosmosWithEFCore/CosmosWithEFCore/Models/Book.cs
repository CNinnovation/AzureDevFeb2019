using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosWithEFCore.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
    }
}
