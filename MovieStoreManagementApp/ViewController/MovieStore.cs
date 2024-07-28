using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MovieStoreLibrary.Repository;
using MovieStoreLibrary.Exceptions;
using MovieStoreLibrary.Models;
namespace MovieStoreManagementApp.ViewController
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            MovieManager.Start();
            while (true)
            {
                Console.WriteLine("Welcome to MovieStore App");
                Console.WriteLine("What operation would you like to perform? \n" +
                    "1. Add new Movie \n" +
                    "2. Display All Movie \n" +
                    "3. Find Movie by Id \n" +
                    "4. Remove Movie by Name \n" +
                    "5. Clear All Movie \n" +
                    "6. Exit \n");

                Console.WriteLine("Enter your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                catch (MovieListEmptyException mle)
                {
                    Console.WriteLine(mle.Message);
                }
                catch (MovieNotExistException mne)
                {
                    Console.WriteLine(mne.Message);
                }
                catch (ListCapacityFullException lcf)
                {
                    Console.WriteLine(lcf.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    Console.WriteLine();
                    break;
                case 2:
                    Display();
                    Console.WriteLine();
                    break;
                case 3:
                    Find();
                    Console.WriteLine();
                    break;
                case 4:
                    Remove();
                    Console.WriteLine();
                    break;
                case 5:
                    MovieManager.ClearAllMovies();
                    Console.WriteLine("All Movies released from List");
                    Console.WriteLine();
                    break;
                case 6:
                    MovieManager.ExitMovie();
                    Console.WriteLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                    break;
            }
        }
        static void Add()
        {
            Console.WriteLine("Enter Movie Details");
            Console.WriteLine("Enter Movie Id");
            try
            {
                int movieId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie Name");
                string movieName = Console.ReadLine()!;
                Console.WriteLine("Enter Year of Release");
                int year = Convert.ToInt32(Console.ReadLine());
                try
                {
                    MovieManager.CheckYear(year);
                    Console.WriteLine("Enter Genre");
                    string genre = Console.ReadLine()!;

                    MovieManager.AddMovie(movieId, movieName, year, genre);
                    Console.WriteLine("Movie added successfully");
                }
                catch (YearNotInRangeException ynir)
                {
                    Console.WriteLine(ynir.Message);
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Display()
        {
            List<Movie> movies = MovieManager.DisplayMovie();
            movies.ForEach(movie => Console.WriteLine(movie));
        }
        static void Find()
        {
            Console.WriteLine("Enter Movie Id");
            int id = Convert.ToInt32(Console.ReadLine());

            Movie findMovie = MovieManager.FindMovieById(id);
            Console.WriteLine(findMovie);
        }
        static void Remove()
        {
            Console.WriteLine("Enter Movie Name");
            string name = Console.ReadLine();
            MovieManager.RemoveMovie(name);
            Console.WriteLine("Movie deleted successfully");
        }
    }
}
