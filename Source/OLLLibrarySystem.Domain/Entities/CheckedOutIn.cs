using System;
using System.Collections.Generic;
using System.Text;

namespace OLLLibrarySystem.Domain.Entities
{
    public class CheckedOutIn
    {
        public int CheckedOutInID { get; set; }
        public string Status { get; set; }
        public int? UserID { get; set; }

        public void ToggleStatusHold ()
        {
            
        }

        public void ToggleStatusOutIn ()
        {
            if (CheckedOutInID == 0)
                {
                    
            }
        }

    }

    
}
