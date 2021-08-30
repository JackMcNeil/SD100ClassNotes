using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repository
{
    public class StreamingContentRepository
    {
        protected readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

        // CRUD
        // Create
        // Read
        // Update
        // Delete

        // Repository pattern = a "database" or list + CRUD methods

        // Create
        public bool AddContentToDirectory(StreamingContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = _contentDirectory.Count > startingCount;
            return wasAdded;
        }
        // Read
        public List<StreamingContent> GetContents()
        {
            return _contentDirectory;
        }

        public StreamingContent GetContentByTitle(string title)
        {
            foreach(StreamingContent item in _contentDirectory)
            {
                if(item.Title == title)
                {
                    return item;
                }
            }
            return null;
        }
        
        public List<StreamingContent> GetFamilyFriendlyContent()
        {
            // Get all contents
            // make empty list
            // loop through
            // if friendly
            //add to list
            // return the list

            List<StreamingContent> content = GetContents();
            List<StreamingContent> familyFriendlyContents = new List<StreamingContent>();
            foreach(StreamingContent item in content)
            {
                if (item.IsFamilyFriendly)
                {
                    familyFriendlyContents.Add(item);
                }
            }
            return familyFriendlyContents;
            // Fancy version using LINQ:
            // Lambda Expression
            // return GetContents().Where(s => s.IsFamilyFriendly).ToList();
        }

        public List<StreamingContent> GetContentsByGenre(GenreType genre)
        {
            List<StreamingContent> content = GetContents();
            List<StreamingContent> contentsByGenre = new List<StreamingContent>();
            foreach (StreamingContent item in content)
            {
                if (item.GenreType == genre)
                {
                    contentsByGenre.Add(item);
                }
            }
            return contentsByGenre;
        }




        // Update
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            StreamingContent oldContent = GetContentByTitle(originalTitle);
            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.StarRating = newContent.StarRating;
                oldContent.GenreType = newContent.GenreType;

                return true;
            }
            return false;
        }

        // Delete
        public bool DeleteExistingContent(StreamingContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
