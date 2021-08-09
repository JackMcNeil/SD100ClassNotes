using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repository
{
    public class StreamingContent
    {
        private string _title;
        public string Title { get { return _title; }
            set
            {
                _title = value.ToUpper();
            }
        }
        public string Description { get; set; }
        public double StarRating { get; set; }
        public MaturityRating MaturityRating { get; set; }
        public bool IsFamilyFriendly { get
            {
                switch (MaturityRating)
                {
                    case MaturityRating.G:
                    case MaturityRating.PG:
                    case MaturityRating.TVG:
                    case MaturityRating.TVY:
                        return true;
                    default:
                        return false;
                }
            }
        }
        public GenreType GenreType { get; set; }

        public StreamingContent() { }
        public StreamingContent(string title, string description, double starRating, MaturityRating matuirityRating, GenreType genre)
        {
            Title = title;
            Description = description;
            StarRating = starRating;
            MaturityRating = matuirityRating;
            GenreType = genre;
        }
        /*
        public bool FamilyFriendly(MaturityRating maturityRating)
        {
            bool familyFriendly;
            if (maturityRating == MaturityRating.G || maturityRating == MaturityRating.PG || maturityRating == MaturityRating.TVG || maturityRating == MaturityRating.TVY)
            {
                familyFriendly = true;
            }
            else
            {
                familyFriendly = false;
            }
            return familyFriendly;
        }
        */
    }
}

public enum MaturityRating {G = 1, PG, R, PG13, NC17, TVMA, TVG, TVY }
public enum GenreType { SciFi = 1, Comedy, Horror, RomCom, Documentary, Western, Action}
