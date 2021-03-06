﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using OLLLibrarySystem.WebUI.Infrastructure.Abstract;

namespace OLLLibrarySystem.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {

            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                //something else here???
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}