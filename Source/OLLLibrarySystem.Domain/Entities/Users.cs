using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OLLLibrarySystem.Domain.Entities
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
    }
}
