using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            //SEED ROLES
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "972cda86-389e-443c-a9e1-06fb0ef7f62e",
                Name = "admin",
                NormalizedName = "admin"
            }
            ,
            new IdentityRole
            {
                Id = "772cda87-389e-443c-a7e1-05fb0ef7f67c",
                Name = "user",
                NormalizedName = "user"
            }
            );
            //SEED ROLES END

            //SEED USER
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                UserName = "admin1",
                NormalizedUserName = "admin1",
                Email = "admin1@example.com",
                NormalizedEmail = "admin1@example.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Summer_2023"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "972cda86-389e-443c-a9e1-06fb0ef7f62e",
                UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
            });
            //SEED USER END

            //SEED GENRE
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                GenreId = 1,
                GenreName = "Rock",
            }
            ,
            new Genre
            {
                GenreId = 2,
                GenreName = "Pop",
            },
            new Genre
            {
                GenreId = 3,
                GenreName = "Hip-Hop",
            }
            );
            //SEED GENRE END

            //SEED ARTIST
            modelBuilder.Entity<Artist>().HasData(new Artist
            {
                ArtistId = 1,
                ArtistName = "Elvis Presley", //rock
            }
            ,
            new Artist
            {
                ArtistId = 2,
                ArtistName = "Michael Jackson", //pop
            },
            new Artist
            {
                ArtistId = 3,
                ArtistName = "Eminem", //Hip-Hop
            }
            );
            //SEED ARTIST END

            //SEED SONG
            modelBuilder.Entity<Song>().HasData(new Song
            {
                SongId = 1,
                SongTitle = "Jailhouse Rock", // Elvis Presley rock
                //YearRecorded= new DateTime(2000, 1, 1),
                YearRecorded = 1957,
                ImageLocation = "/img/Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.jpeg",
                GenreId=1,
                ArtistId=1,
                SongFileLocation= "/Song/Elvis_Presley_Jailhouse_Rock_Single_Cover.mp3"
            }
            ,
            new Song
            {
                SongId = 2,
                SongTitle = "Billie Jean", //Michael Jackson pop
                YearRecorded=1982,
                ImageLocation = "/img/Song/Michael-Jackson-Billie-Jean.jpg",
                GenreId = 2,
                ArtistId = 2,
                SongFileLocation = "/Song/Michael-Jackson-Billie-Jean.mp3"
            },
            new Song
            {
                SongId = 3,
                SongTitle = "Lose Yourself", //Eminem Hip-Hop
                YearRecorded = 2002,
                ImageLocation = "/img/Song/Eminem_Lose-Yourself.jpg",
                GenreId = 3,
                ArtistId = 3,
                SongFileLocation = "/Song/Eminem_Lose-Yourself.mp3"
            }
            ,
            new Song
            {
                SongId = 4,
                SongTitle = "They Don't Care About Us", //Michael Jackson pop
                YearRecorded = 1995,
                ImageLocation = "/img/Song/Michael_Jackson_TheyDontCareAboutUs.jpg",
                GenreId = 2,
                ArtistId = 2,
                SongFileLocation = "/Song/TheyDontCareAboutUs.mp3"
            },
            new Song
            {
                SongId = 5,
                SongTitle = "watch me burn", //Eminem Hip-Hop
                YearRecorded = 2010,
                ImageLocation = "/img/Song/eminem-love-the-way-you-lie.jpg",
                GenreId = 3,
                ArtistId = 3,
                SongFileLocation = "/Song/eminem-love-the-way-you-lie.mp3"
            }
            );
            //SEED SONG END
        }
    }
}