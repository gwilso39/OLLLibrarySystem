using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OLLLibrarySystem.Domain.Entities
{
    [Table("Book")]
    public class Book
    {
        public int BookID { get; set; }
        public int LexileUpper { get; set; }
        public int LexileLower { get; set; }
        public int LocationID { get; set; }
        public int CheckedOutInID { get; set; }
        public int RecAge { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal ReplacementCost { get; set; }
        public string ISBN { get; set; }
    }
}
