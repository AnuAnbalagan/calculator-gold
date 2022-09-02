using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identify.Models.ViewModels
{
    public class PasswordVM
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string BaseCode { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string Errormessage { get; set; }
    }
}
