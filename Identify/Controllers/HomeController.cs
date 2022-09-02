using Identify.Models;
using Identify.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Identify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private IWebHostEnvironment webHost;

        public HomeController(IWebHostEnvironment webHost,ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.webHost = webHost;
        }
        [Authorize]
        public IActionResult Index()
        {
            var user = GetCurrentUserAsync().Result;
            return View(user);
        }
        
        [Authorize]
        public IActionResult Edit()
        {
            var user = GetCurrentUserAsync().Result;
            ProfileEditModel model = new ProfileEditModel()
            {
                Address = user.Address,
                CovorPhoto = user.CovorPhoto,
                ProfilePhoto = user.ProfilePhoto,
                Name = user.FullName,
            };
            return View(model);
        }
        
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(ProfileEditModel editModel)
        {
            if (editModel.ProfilePhotoFile != null)
            {
                string foldername = "images";
                Guid nameguid = Guid.NewGuid();
                string webrootpath = webHost.WebRootPath;
                string filename = nameguid.ToString();
                string extension = Path.GetExtension(editModel.ProfilePhotoFile.FileName);
                filename = filename + extension;
                string path = Path.Combine(webrootpath, foldername, filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    editModel.ProfilePhotoFile.CopyTo(fileStream);
                }
                string pathName = Path.Combine(foldername, filename);
                string fileUrl = "~/" + foldername + "/" + filename;
                editModel.ProfilePhoto = fileUrl;
            }
            if (editModel.CovorPhotoFile != null)
            {
                string foldername = "images";
                Guid nameguid = Guid.NewGuid();
                string webrootpath = webHost.WebRootPath;
                string filename = nameguid.ToString();
                string extension = Path.GetExtension(editModel.CovorPhotoFile.FileName);
                filename = filename + extension;
                string path = Path.Combine(webrootpath, foldername, filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    editModel.ProfilePhotoFile.CopyTo(fileStream);
                }
                string pathName = Path.Combine(foldername, filename);
                string fileUrl = "~/" + foldername + "/" + filename;
                editModel.CovorPhoto = fileUrl;
            }
            ApplicationUser usr =await GetCurrentUserAsync();
            usr.FullName = editModel.Name;
            usr.Address = editModel.Address;
            usr.CovorPhoto = editModel.CovorPhoto;
            usr.ProfilePhoto = editModel.ProfilePhoto;
            var result =await  userManager.UpdateAsync(usr);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
