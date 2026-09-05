using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Inception",
                    ReleaseDate = DateTime.Parse("2010-07-16"),
                    Genre = "Sci-Fi",
                    Price = 10.00M,
                    Rating = "PG-13"
                },
                new Movie
                {
                    Title = "Avengers: Endgame",
                    ReleaseDate = DateTime.Parse("2019-04-26"),
                    Genre = "Action",
                    Price = 12.00M,
                    Rating = "PG-13"
                },
                new Movie
                {
                    Title = "Interstellar",
                    ReleaseDate = DateTime.Parse("2014-11-07"),
                    Genre = "Sci-Fi",
                    Price = 15.00M,
                    Rating = "PG-13"
                }
            );

            context.SaveChanges();
        }
    }
}