﻿using OLLLibrarySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLLLibrarySystem.WebUI.Models
{
    public struct BookStatusView
    {
        public Book book;
        public string status;
        public string location;
    }
}