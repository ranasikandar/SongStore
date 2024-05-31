using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SongStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.DAL
{
    public class DBRepo : IDBRepo
    {
        #region ctor
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public DBRepo(AppDbContext context, UserManager<ApplicationUser> _userManager)
        {
            this.context = context;
            this.userManager = _userManager;
        }
        #endregion


        public IQueryable<Song> LoadSongs(int pageIndex, int pageSize, string searchTxt, int artist, int genre, int year)
        {
            IQueryable<Song> _songs= context.Songs.OrderByDescending(x => x.SongId).Where(x=> x.IsDeleted==false).Skip(pageIndex * pageSize)
                .Take(pageSize).Include(x => x.Artist).Include(x => x.Genre);

            if (!string.IsNullOrEmpty(searchTxt))
            {
                _songs = _songs.Where(x => x.SongTitle.Contains(searchTxt));
            }

            if (artist>0)
            {
                _songs = _songs.Where(x => x.ArtistId==artist);
            }

            if (genre > 0)
            {
                _songs = _songs.Where(x => x.GenreId == genre);
            }

            if (year > 0)
            {
                _songs = _songs.Where(x => x.YearRecorded == year);
            }

            return _songs;

        }

        public async Task<Song> GetSongAsync(int id)
        {
            return await context.Songs.Where(x => x.SongId == id && x.IsDeleted == false).FirstOrDefaultAsync();

        }

        public async Task<Song> AddUpdateSong(Song SongChanges)
        {
            //chk wather update or add new
            if (SongChanges.SongId > 0)
            {
                var song = context.Songs.Attach(SongChanges);
                song.State = EntityState.Modified;
            }
            else
            {
                context.Songs.Add(SongChanges);
            }

            await context.SaveChangesAsync();
            return SongChanges;
        }

        public async Task<Song> DeleteSong(Song song)
        {
            context.Songs.Remove(song);
            await context.SaveChangesAsync();
            return song;
        }


        public List<Artist> GetArtists(int id)
        {
            if (id>0)
            {
                return context.Artists.Where(x => x.ArtistId == id).Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                return context.Artists.Where(x => x.IsDeleted == false).ToList();
            }
            
        }

        public List<Genre> GetGenres(int id)
        {
            if (id > 0)
            {
                return context.Genres.Where(x => x.GenreId== id).Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                return context.Genres.Where(x => x.IsDeleted == false).ToList();
            }

        }

        public List<short?> GetYearRecordedDist()
        {
            return context.Songs.Where(x=>x.IsDeleted==false).Select(x => x.YearRecorded).Distinct().ToList();

        }

        public async Task<Artist> GetArtistAsync(int id)
        {
            return await context.Artists.Where(x => x.ArtistId == id && x.IsDeleted == false).FirstOrDefaultAsync();

        }

        public async Task<Artist> DeleteArtist(Artist artist)
        {
            context.Artists.Remove(artist);
            await context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> AddUpdateArtist(Artist ArtistChanges)
        {
            //chk wather update or add new
            if (ArtistChanges.ArtistId > 0)
            {
                var artist = context.Artists.Attach(ArtistChanges);
                artist.State = EntityState.Modified;
            }
            else
            {
                context.Artists.Add(ArtistChanges);
            }

            await context.SaveChangesAsync();
            return ArtistChanges;
        }

        public async Task<Genre> GetGenreAsync(int id)
        {
            return await context.Genres.Where(x => x.GenreId == id && x.IsDeleted == false).FirstOrDefaultAsync();

        }

        public async Task<Genre> DeleteGenre(Genre genre)
        {
            context.Genres.Remove(genre);
            await context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> AddUpdateGenre(Genre GenreChanges)
        {
            //chk wather update or add new
            if (GenreChanges.GenreId > 0)
            {
                var x = context.Genres.Attach(GenreChanges);
                x.State = EntityState.Modified;
            }
            else
            {
                context.Genres.Add(GenreChanges);
            }

            await context.SaveChangesAsync();
            return GenreChanges;
        }

    }
}
