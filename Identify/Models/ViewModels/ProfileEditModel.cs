using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identify.Models.ViewModels
{
    public class ProfileEditModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CovorPhoto { get; set; }
        public string ProfilePhoto { get; set; }
        public IFormFile CovorPhotoFile { get; set; }
        public IFormFile ProfilePhotoFile { get; set; }
    }
}
