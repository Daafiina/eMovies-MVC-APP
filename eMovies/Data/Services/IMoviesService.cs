﻿using eMovies.Data.Base;
using eMovies.Models;
using System.Threading.Tasks;

namespace eMovies.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository <Movie>
    {
        Task<Movie> GetMovieByIdAsync (int id);
    }
}
