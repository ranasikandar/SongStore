using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SongStore.DAL;
using SongStore.Models;
using SongStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Controllers
{
    public class GenreController : Controller
    {
        private readonly IDBRepo dBRepo;
        public GenreController(IDBRepo _DBRepo)
        {
            dBRepo = _DBRepo;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(int id)
        {
            GenreVM genreVM = new GenreVM
            {
                GenreList = dBRepo.GetGenres(0)
            };

            if (id > 0)
            {
                Genre genre = await dBRepo.GetGenreAsync(id);
                if (genre != null)
                {
                    genreVM.Id = genre.GenreId;
                    genreVM.GenreName = genre.GenreName;
                }
            }

            return View(genreVM);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            Genre _genre = await dBRepo.GetGenreAsync(id);
            if (_genre != null)
            {
                _genre.IsDeleted = true;

                //await dBRepo.DeleteGenre(_genre);
                await dBRepo.AddUpdateGenre(_genre);
            }

            return RedirectToAction("Index", "Genre");
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(GenreVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)//update
                {
                    Genre genre = await dBRepo.GetGenreAsync(model.Id);
                    if (genre != null)
                    {
                        genre.GenreName = model.GenreName;

                        genre = await dBRepo.AddUpdateGenre(genre);
                        if (genre == null)
                        {
                            ModelState.AddModelError(string.Empty, "Could not update Genre");
                            ViewBag.JavaScriptFunction = @"swal('Could not update Genre!', {icon: 'error',timer: 5000,});";
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = @"swal('Genre Updated!', {icon: 'success',timer: 5000,});";
                            return LocalRedirect("/Genre/Index");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "This Genre with id Not found in any Records");
                    }
                }
                else //new
                {
                    Genre genre = new Genre
                    {
                        GenreName = model.GenreName
                    };

                    genre = await dBRepo.AddUpdateGenre(genre);

                    if (genre == null)
                    {
                        ModelState.AddModelError(string.Empty, "Could not Save Genre");
                        ViewBag.JavaScriptFunction = @"swal('Could not save Genre!', {icon: 'error',timer: 5000,});";
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = @"swal('Genre Saved!', {icon: 'success',timer: 5000,});";
                        return LocalRedirect("/Genre/Index");
                    }

                }
            }

            model.GenreList = dBRepo.GetGenres(0);

            return View(model);
        }

    }
}
