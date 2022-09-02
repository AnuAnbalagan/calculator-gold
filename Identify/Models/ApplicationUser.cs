using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identify.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string ProfilePhoto { get; set; }
        public string CovorPhoto { get; set; }

    }
}
