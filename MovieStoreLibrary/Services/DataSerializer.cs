using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieStoreLibrary.Models;

namespace MovieStoreLibrary.Services
{
    public class DataSerializer
    {
        static string file = @"C:\Users\sreerag.babu\Documents\C# Projects\MovieStoreAppFinal\MovieStoreLibrary\Assets\myMovies.json";

        public static void SerializeObject(List<Movie> movies)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movies));
            }
        }

        public static List<Movie> DeserializeObject()
        {
            if (!File.Exists(file))
                return new List<Movie>();
            using (StreamReader sr = new StreamReader(file))
            {
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return movies;
            }
        }
    }
}
