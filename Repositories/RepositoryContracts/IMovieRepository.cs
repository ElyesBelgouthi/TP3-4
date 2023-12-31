﻿using TP3.Models;

namespace TP3.Repositories.RepositoryContracts
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        List<Movie> GetMoviesByGenre(int genreId);
        List<Movie> GetAllMoviesOrderedAscending();
        List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre);

    }
}