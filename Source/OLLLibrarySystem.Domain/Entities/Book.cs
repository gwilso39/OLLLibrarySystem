using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OLLLibrarySystem.Domain.Entities
{
    [Table("Book")]
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int BookID { get; set; }

        [Required(ErrorMessage = "Please enter a Book Title")]
        [Column("Title")]
        public string BookTitle { get; set; }
        [DataType(DataType.MultilineText)]
        
        public int LexileUpper { get; set; }
        public int LexileLower { get; set; }

        [Required(ErrorMessage = "Please enter the book's location")]
        public int LocationID { get; set; }

        public int CheckedOutInID { get; set; }

        public int RecAge { get; set; }

        [Required(ErrorMessage = "Please enter the book's Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter the book's genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Please enter the book's Description")]
        public string Description { get; set; }

        public string Photo { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive dollar amount")]
        public decimal ReplacementCost { get; set; }

        [Required(ErrorMessage = "Please enter an ISBN for this book")]
        public string ISBN { get; set; }
    }
}
