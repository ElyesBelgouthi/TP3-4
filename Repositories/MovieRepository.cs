using TP3.Models;
using TP3.Repositories.RepositoryContracts;

namespace TP3.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Movie> GetAllMovies()
        {
            return _db.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movies.Find(id);
        }

        public void CreateMovie(Movie movie)
        {
            if (movie.ImageFile != null && movie.ImageFile.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                movie.Photo = $"/images/{movie.ImageFile.FileName}";
            }

            _db.Movies.Add(movie);
            _db.SaveChanges();
        }


        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _db.Movies
                .Where(m => m.genre_id == genreId)
                .ToList();
        }

        public List<Movie> GetAllMoviesOrderedAscending()
        {
            return _db.Movies
                .OrderBy(m => m.Name)
                .ToList();
        }

        public List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            return _db.Movies
                .Where(m => m.Genre.GenreName == userDefinedGenre)
                .ToList();
        }
    }
}