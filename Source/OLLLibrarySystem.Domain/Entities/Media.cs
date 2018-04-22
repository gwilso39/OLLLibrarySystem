using System;
using System.Collections.Generic;
using System.Text;

namespace OLLLibrarySystem.Domain.Entities
{
    public class Media
    {
        public int MediaID { get; set; }
        public int Location { get; set; }
        public int Subject { get; set; }
        public int CheckedOutIn { get; set; }
        public int RecAge { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Producer { get; set; }
        public string Rating { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public decimal ReplacementCost { get; set; }
    }
}
