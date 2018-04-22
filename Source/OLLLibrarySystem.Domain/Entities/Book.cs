using System;
using System.Collections.Generic;
using System.Text;

namespace OLLLibrarySystem.Domain.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public int UpperLexile { get; set; }
        public int LowerLexile { get; set; }
        public int Location { get; set; }
        public int CheckedOutIn { get; set; }
        public int RecAge { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal ReplacementCost { get; set; }
        public int ISBN { get; set; }
    }
}
