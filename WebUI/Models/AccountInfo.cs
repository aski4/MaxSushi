using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Abstract;
using Domain.Enities;

namespace WebUI.Models
{
    public class AccountInfo
    {
        public IEnumerable<Account> Accounts { get; set; }
    }

    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}