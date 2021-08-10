using _07_RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Inheritance.Content
{
    public class Movie : StreamingContent
    {
        public double RunTime { get; set; }

        public Movie() { }
        public Movie(string title, string description, double stars, MaturityRating rating, GenreType genre, double runTime) : base(title, description, stars, rating, genre)
        {
            RunTime = runTime;
        }
    }
}
