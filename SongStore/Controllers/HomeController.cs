using SongStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SongStore.DAL;
using SongStore.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace SongStore.Controllers
{
    public class HomeController : Controller
    {
        #region CTOR
        private readonly ILogger<HomeController> _logger;
        private readonly IDBRepo DBRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, IDBRepo _DBRepo, UserManager<ApplicationUser> _userManager
            , RoleManager<IdentityRole> _roleManager)
        {
            _logger = logger;
            DBRepo = _DBRepo;
            userManager = _userManager;
            roleManager = _roleManager;
        }
        #endregion

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            bool isAdmin=false;

            ApplicationUser currentUser = await userManager.GetUserAsync(HttpContext.User);
            if (currentUser != null)
            {
                IdentityRole role = await roleManager.FindByNameAsync("admin");
                if (await userManager.IsInRoleAsync(currentUser, role.Name))
                {
                    isAdmin = true;
                }
            }

            HomeVM homeVM = new HomeVM
            {
                Artists = DBRepo.GetArtists(0),
                Genres = DBRepo.GetGenres(0),
                YearRecorded = DBRepo.GetYearRecordedDist(),
                IsAdmin=isAdmin
            };

            return View(homeVM);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadSongs(int pageIndex, int pageSize,string searchTxt,int artist,int genre,int year)
        {
            IQueryable<Song> data = DBRepo.LoadSongs(pageIndex, pageSize, searchTxt, artist, genre, year);

            var jData = data.Select(x => new { Id = x.SongId, x.SongTitle, x.YearRecorded, x.Artist.ArtistName, x.Genre.GenreName, x.ImageLocation, x.SongFileLocation});

            if (jData.Any())
            {
                return Json(jData);
            }
            else
            {
                return Json(new[] { new { server_Res = "EOTL" } });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
