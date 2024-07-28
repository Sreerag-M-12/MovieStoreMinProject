using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreLibrary.Exceptions;
using MovieStoreLibrary.Models;
using MovieStoreLibrary.Services;

namespace MovieStoreLibrary.Repository
{
    public class MovieManager
    {
        static List<Movie> movies = new List<Movie>();
        public MovieManager()
        {
            movies = DataSerializer.DeserializeObject();
        }
        public static void Start()
        {
            movies = DataSerializer.DeserializeObject();
        }
        public static void AddMovie(int movieId, string movieName, int year, string genre)
        {
            if (movies.Count > 4)
                throw new ListCapacityFullException("List is full");
            else
                movies.Add(Movie.CreateNewMovie(movieId, movieName, year, genre));
        }
        public static bool CheckYear(int year)
        {
            if (year >= 1900 && year <= 2024)
                return true;
            else
                throw new YearNotInRangeException("Year should be between 1900-2024");
        }

        public static List<Movie> DisplayMovie() 
        {
            if (movies.Count == 0)
                throw new MovieListEmptyException("The List is empty");
            else
                return movies;
        }

        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;
            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
            if (findMovie != null)
                return findMovie;
            else
                throw new MovieNotExistException("Movie not found");
        }

        public static void RemoveMovie(string name)
        {
            Movie findMovie = null;
            
            findMovie = movies.Where(item => item.Name == name).FirstOrDefault();
            if (findMovie == null)
                throw new MovieNotExistException("Movie not found");
            else
                movies.Remove(findMovie);
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieListEmptyException("Movie list is already empty. Nothing to clear");
            else
                movies.Clear();
        }

        public static void ExitMovie()
        {
            DataSerializer.SerializeObject(movies);
        }
    }
}
