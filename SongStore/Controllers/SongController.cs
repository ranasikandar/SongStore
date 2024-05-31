using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SongStore.DAL;
using SongStore.Models;
using SongStore.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Controllers
{
    public class SongController : Controller
    {
        private readonly ILogger<SongController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IDBRepo dBRepo;
        private readonly IWebHostEnvironment hostingEnv;

        public SongController(ILogger<SongController> logger,UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager
            , IDBRepo _DBRepo, IWebHostEnvironment _hostingEnv)
        {
            _logger = logger;
            userManager = _userManager;
            roleManager = _roleManager;
            dBRepo = _DBRepo;
            hostingEnv = _hostingEnv;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(int id)
        {
            SongVM songVM = new SongVM();
            songVM.Genres = dBRepo.GetGenres(0);
            songVM.Artists = dBRepo.GetArtists(0);

            if (id>0)
            {
                Song _song=await dBRepo.GetSongAsync(id);
                songVM.SongId = _song.SongId;
                songVM.SongTitle = _song.SongTitle;
                songVM.YearRecorded = _song.YearRecorded;
                songVM.SelectedGenre = _song.GenreId;    
                songVM.SelectedArtist = _song.ArtistId;
                songVM.ImageLocation = _song.ImageLocation;
                songVM.SongFileLocation = _song.SongFileLocation;
            }

            //if (usr<2)
            //{
            //    ViewBag.JavaScriptFunction = $"window.location.replace('{Url.Action("Index", "Home")}');";
            //}

            return View(songVM);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(SongVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.SongId > 0)//update song
                {
                    Song song = await dBRepo.GetSongAsync(model.SongId);
                    if (song!=null)
                    {
                        song.SongTitle = model.SongTitle;
                        song.YearRecorded = model.YearRecorded;
                        song.GenreId = model.SelectedGenre;
                        song.ArtistId = model.SelectedArtist;

                        //rana save img & mp3 file if any. set .audio instead of .img

                        #region uploadPic
                        string @PicURI = song.ImageLocation;
                        if (model.UploadPicture != null && model.UploadPicture.Length > 0)
                        {
                            try
                            {
                                if (model.UploadPicture.ContentType.Contains("image"))
                                {
                                    PicURI = "/img/Song";

                                    string uploadsFolder = Path.Combine(hostingEnv.WebRootPath, "img","Song");
                                    //string uploadFileName = model.UploadPicture.FileName;

                                    string newFileName = Guid.NewGuid().ToString().Replace("-", "");
                                    newFileName += Path.GetExtension(model.UploadPicture.FileName);

                                    PicURI += "/" + newFileName;

                                    //_logger.LogInformation($"saving uploded file: {Path.Combine(uploadsFolder, newFileName)}");
                                    using (Stream fs = new FileStream(Path.Combine(uploadsFolder, newFileName), FileMode.Create))
                                    {
                                        await model.UploadPicture.CopyToAsync(fs);
                                    }
                                    //_logger.LogInformation("uploded file saved");
                                }
                                else
                                {
                                    ModelState.AddModelError("UploadPicture", "Invalid Picture! please upload valid image file");
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex.Message);
                            }
                        }
                        #endregion

                        #region uploadAudio
                        string @AudioURI = song.SongFileLocation;
                        if (model.SongFile != null && model.SongFile.Length > 0)
                        {
                            try
                            {
                                if (model.SongFile.ContentType.Contains("audio"))
                                {
                                    AudioURI = "/Song";

                                    string uploadsFolder = Path.Combine(hostingEnv.WebRootPath, "Song");
                                    //string uploadFileName = model.UploadPicture.FileName;

                                    string newFileName = Guid.NewGuid().ToString().Replace("-", "");
                                    newFileName += Path.GetExtension(model.SongFile.FileName);

                                    AudioURI += "/" + newFileName;

                                    //_logger.LogInformation($"saving uploded file: {Path.Combine(uploadsFolder, newFileName)}");
                                    using (Stream fs = new FileStream(Path.Combine(uploadsFolder, newFileName), FileMode.Create))
                                    {
                                        await model.SongFile.CopyToAsync(fs);
                                    }
                                    //_logger.LogInformation("uploded file saved");
                                }
                                else
                                {
                                    ModelState.AddModelError("SongFile", "Invalid Audio! please upload valid Audio file");
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex.Message);
                            }
                        }
                        #endregion

                        song.ImageLocation = PicURI;
                        song.SongFileLocation = AudioURI;

                        song = await dBRepo.AddUpdateSong(song);
                        if (song==null)
                        {
                            ModelState.AddModelError(string.Empty, "Could not update Song");
                            ViewBag.JavaScriptFunction = @"swal('Could not update Song!', {icon: 'error',timer: 5000,});";
                        }
                        else
                        {
                            ViewBag.JavaScriptFunction = @"swal('Song Updated!', {icon: 'success',timer: 5000,});";
                            return LocalRedirect("/Home/Index");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "This Song with id Not found in any Records");
                    }
                }
                else //new song
                {

                    #region uploadPic
                    string @PicURI = string.Empty;
                    if (model.UploadPicture != null && model.UploadPicture.Length > 0)
                    {
                        try
                        {
                            if (model.UploadPicture.ContentType.Contains("image"))
                            {
                                PicURI = "/img/Song";

                                string uploadsFolder = Path.Combine(hostingEnv.WebRootPath, "img", "Song");
                                //string uploadFileName = model.UploadPicture.FileName;

                                string newFileName = Guid.NewGuid().ToString().Replace("-", "");
                                newFileName += Path.GetExtension(model.UploadPicture.FileName);

                                PicURI += "/" + newFileName;

                                //_logger.LogInformation($"saving uploded file: {Path.Combine(uploadsFolder, newFileName)}");
                                using (Stream fs = new FileStream(Path.Combine(uploadsFolder, newFileName), FileMode.Create))
                                {
                                    await model.UploadPicture.CopyToAsync(fs);
                                }
                                //_logger.LogInformation("uploded file saved");
                            }
                            else
                            {
                                ModelState.AddModelError("UploadPicture", "Invalid Picture! please upload valid image file");
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }
                    }
                    #endregion

                    #region uploadAudio
                    string @AudioURI = string.Empty;
                    if (model.SongFile != null && model.SongFile.Length > 0)
                    {
                        try
                        {
                            if (model.SongFile.ContentType.Contains("audio"))
                            {
                                AudioURI = "/Song";

                                string uploadsFolder = Path.Combine(hostingEnv.WebRootPath, "Song");
                                //string uploadFileName = model.UploadPicture.FileName;

                                string newFileName = Guid.NewGuid().ToString().Replace("-", "");
                                newFileName += Path.GetExtension(model.SongFile.FileName);

                                AudioURI += "/" + newFileName;

                                //_logger.LogInformation($"saving uploded file: {Path.Combine(uploadsFolder, newFileName)}");
                                using (Stream fs = new FileStream(Path.Combine(uploadsFolder, newFileName), FileMode.Create))
                                {
                                    await model.SongFile.CopyToAsync(fs);
                                }
                                //_logger.LogInformation("uploded file saved");
                            }
                            else
                            {
                                ModelState.AddModelError("SongFile", "Invalid Audio! please upload valid Audio file");
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }
                    }
                    #endregion

                    Song song = new Song
                    {
                        SongTitle = model.SongTitle,
                        YearRecorded=model.YearRecorded,
                        GenreId=model.SelectedGenre,
                        ArtistId=model.SelectedArtist,
                        ImageLocation= PicURI,
                        SongFileLocation= AudioURI
                    };

                    song = await dBRepo.AddUpdateSong(song);

                    if (song == null)
                    {
                        ModelState.AddModelError(string.Empty, "Could not Save Song");
                        ViewBag.JavaScriptFunction = @"swal('Could not save Song!', {icon: 'error',timer: 5000,});";
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = @"swal('Song Saved!', {icon: 'success',timer: 5000,});";
                        return LocalRedirect("/Home/Index");
                    }

                }
            }

            model.Genres = dBRepo.GetGenres(0);
            model.Artists = dBRepo.GetArtists(0);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            Song _song = await dBRepo.GetSongAsync(id);
            if (_song!=null)
            {
                _song.IsDeleted = true;

                //remove img audio files
                if (!string.IsNullOrEmpty(_song.ImageLocation))
                {
                    deleteFile(hostingEnv.WebRootPath + _song.ImageLocation.Replace('/', '\\'));
                }
                if (!string.IsNullOrEmpty(_song.SongFileLocation))
                {
                    deleteFile(hostingEnv.WebRootPath + _song.SongFileLocation.Replace('/', '\\'));
                }

                await dBRepo.DeleteSong(_song);
            }

            return LocalRedirect("/Home/Index");
        }

        private bool deleteFile(string fullFilePath)
        {
            if (System.IO.File.Exists(fullFilePath))
            {
                System.IO.File.Delete(fullFilePath);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
