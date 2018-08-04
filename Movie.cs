using System;
using System.Collections.Generic;

namespace MovieApi
{
    public class Movie
    {
        public int nr { get; set; }
        public string title { get; set; }

        private static List<Movie> _movies;
        public static Movie[] Movies 
        {
            get 
            { 
                if(_movies == null)
                {
                    _movies = new List<Movie>();
                    _movies.AddRange( new Movie[] {
                        new Movie { nr = 1, title = "Stardust" },
                        new Movie { nr = 2, title = "Top Gun" },
                        new Movie { nr = 3, title = "Harry Potter and the Philosophers Stone"}
                    });
                }
                return _movies.ToArray(); 
            }
        }

        public static Movie Find(int nr)
        {
            Movie result = null;
            int index = 0; 
            while(result == null && index < Movies.Length){
                if(Movies[index].nr == nr){
                    result = Movies[index];
                }
                index++;
            }
            return result;
        }

        private static int NextNumber()
        {
            int result = 0;
            foreach(Movie mov in Movies)
            {
                result = Math.Max(mov.nr, result);
            }
            return result + 1;
        }
    
        public static void New(Movie movie)
        {
            movie.nr = NextNumber();
            _movies.Add(movie);
        }

        public static void Delete(int nr)
        {
            Movie mov = Find(nr);
            if(mov != null)
            {
                _movies.Remove(mov);
            }
        }
    }



    
}