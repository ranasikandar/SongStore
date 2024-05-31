using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SongStore.DAL;
using SongStore.ViewModels;
using SongStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IDBRepo dBRepo;
        public ArtistController(IDBRepo _DBRepo)
        {
            dBRepo = _DBRepo;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(int id)
        {
            ArtistVM artistVM = new ArtistVM
            {
                ArtistList = dBRepo.GetArtists(0)
            };

            if (id>0)
            {
               Artist artist= await dBRepo.GetArtistAsync(id);
                if (artist!=null)
                {
                    artistVM.Id = artist.ArtistId;
                    artistVM.ArtistName = artist.ArtistName;
                }
            }

            return View(artistVM);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            Artist _artist = await dBRepo.GetArtistAsync(id);
            if (_artist != null)
            {
                _artist.IsDeleted = true;

                //await dBRepo.DeleteArtist(_artist);
                await dBRepo.AddUpdateArtist(_artist);
            }

            return RedirectToAction("Index", "Artist");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(ArtistVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)//update
                {
                    Artist artist = await dBRepo.GetArtistAsync(model.Id);
                    if (artist != null)
                    {
                        artist.ArtistName = model.ArtistName;
                        
                        artist = await dBRepo.AddUpdateArtist(artist);
                        if (artist == null)
                        {
                            ModelState.AddModelError(string.Empty, "Could not update Artist");
                            ViewBag.JavaScriptFunction = @"swal('Could not update Artist!', {icon: 'error',timer: 5000,});";
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = @"swal('Artist Updated!', {icon: 'success',timer: 5000,});";
                            return LocalRedirect("/Artist/Index");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "This Artist with id Not found in any Records");
                    }
                }
                else //new
                {
                    Artist artist = new Artist
                    {
                        ArtistName=model.ArtistName
                    };

                    artist = await dBRepo.AddUpdateArtist(artist);

                    if (artist == null)
                    {
                        ModelState.AddModelError(string.Empty, "Could not Save Artist");
                        ViewBag.JavaScriptFunction = @"swal('Could not save Artist!', {icon: 'error',timer: 5000,});";
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = @"swal('Artist Saved!', {icon: 'success',timer: 5000,});";
                        return LocalRedirect("/Artist/Index");
                    }

                }
            }

            model.ArtistList = dBRepo.GetArtists(0);

            return View(model);
        }

    }
}
