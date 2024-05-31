using SongStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.DAL
{
    public interface IDBRepo
    {
        IQueryable<Song> LoadSongs(int pageIndex, int pageSize, string searchTxt, int artist, int genre, int year);
        List<Artist> GetArtists(int id);
        List<Genre> GetGenres(int id);
        List<short?> GetYearRecordedDist();
        Task<Song> GetSongAsync(int id);
        Task<Song> AddUpdateSong(Song SongChanges);
        Task<Song> DeleteSong(Song song);
        Task<Artist> GetArtistAsync(int id);
        Task<Artist> DeleteArtist(Artist artist);
        Task<Artist> AddUpdateArtist(Artist ArtistChanges);
        Task<Genre> GetGenreAsync(int id);
        Task<Genre> DeleteGenre(Genre genre);
        Task<Genre> AddUpdateGenre(Genre GenreChanges);

    }
}
