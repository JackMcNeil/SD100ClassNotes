using _07_RepositoryPattern_Repository;
using _08_StreamingContent_Inheritance.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Inheritance
{
    public class StreamingRepository : StreamingContentRepository
    {
        public Show GetShowByTitle(string title)
        {
            foreach (StreamingContent content in _contentDirectory)
            {
                // if (content is Show && content.Title == title)
                if (content.GetType() == typeof(Show) && content.Title == title)
                {
                    return (Show) content;
                }
            }

            return null;

            //fancy way
            return (Show)_contentDirectory.FirstOrDefault(s => s is Show && s.Title == title);
        }

        public Movie GetMovieByTitle(string title)
        {
            return (Movie)_contentDirectory.FirstOrDefault(s => s is Movie && s.Title == title);
        }

        public List<Show> GetAllShows()
        {
            List<Show> allShows = new List<Show>();
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content is Show)
                {
                    allShows.Add((Show) content);
                }
            }
            return allShows;

            return _contentDirectory.Where(s => s is Show).Cast<Show>().ToList();
        }

        public List<Movie> GetAllMovies()
        {
            return _contentDirectory.Where(s => s is Movie).Cast<Movie>().ToList();
        }

        public List<Movie> GetMoviesByRating(MaturityRating rating)
        {
            List<Movie> moviesByRating = new List<Movie>();
            foreach (StreamingContent item in _contentDirectory)
            {
                if (item.MaturityRating == rating && item is Movie)
                {
                    moviesByRating.Add((Movie) item);
                }
            }
            return moviesByRating;
        }

        public List<Movie> GetMoviesByStarRating(double stars)
        {
            return GetAllMovies().Where(m => m.StarRating >= stars).ToList();
        }


        public List<Show> GeShowsByRating(MaturityRating rating)
        {
            List<Show> showsByRating = new List<Show>();
            foreach (StreamingContent item in _contentDirectory)
            {
                if (item.MaturityRating == rating && item is Show)
                {
                    showsByRating.Add((Show) item);
                }
            }
            return showsByRating;

            // 1. getting list of all shows
            // 2. where the maturity rating is less than or equal to selction
            // 3. turns it into list.
            // return GetAllShows().Where(m => m.MaturityRating <= rating).ToList();
        }

        public List<Movie> GetMoviesByGenre(GenreType genre)
        {
            List<Movie> moviesByGenre = new List<Movie>();
            foreach (StreamingContent item in _contentDirectory)
            {
                if (item.GenreType == genre && item is Movie)
                {
                    moviesByGenre.Add((Movie) item);
                }
            }
            return moviesByGenre;
        }
        
        public List<Show> GetShowByGenre(GenreType genre)
        {
            List<Show> showByGenre = new List<Show>();
            foreach (StreamingContent item in _contentDirectory)
            {
                if (item.GenreType == genre && item is Show)
                {
                    showByGenre.Add((Show) item);
                }
            }
            return showByGenre;
        }
    }
}
