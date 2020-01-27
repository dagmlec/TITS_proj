﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiTSproj.Models;

namespace TiTSproj.ViewModels
{
    public class ManageCredentialsViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        //public TiTSproj.Controllers.ManageController.ManageMessageId? Message { get; set; }
        public DaneUzytkownika DaneUzytkownika;
    }
}