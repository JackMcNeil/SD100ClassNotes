using _07_RepositoryPattern_Repository;
using _08_StreamingContent_Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_StreamingContent_Console.UI
{
    public class ProgramUI
    {
        private readonly StreamingRepository _repo = new StreamingRepository();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Console.WriteLine("Seeding contents...");

            StreamingContent sc1 = new StreamingContent("National Treasure", "A treasure hunt for gold", 5, MaturityRating.PG13, GenreType.Documentary);
            StreamingContent sc2 = new StreamingContent("Shrek", "A true love stroy", 4.5, MaturityRating.PG, GenreType.RomCom);
            StreamingContent sc3 = new StreamingContent("Over the hedge", "Getting over the hedge", 5, MaturityRating.PG, GenreType.Action);

            _repo.AddContentToDirectory(sc1);
            _repo.AddContentToDirectory(sc2);
            _repo.AddContentToDirectory(sc3);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                // \n = new line = CR + LF
                // CR = Carriage Return
                // LF = Line Feed
                Console.WriteLine("Menu:\n" +
                    "1. Show all streaming Content\n" +
                    "2. Find streaming content by title\n" +
                    "3. Add new streaming content\n" +
                    "4. Remove streaming content\n" +
                    "5. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show all content
                        DisplayAllContents();
                        break;
                    case "2":
                        //Find by title
                        GetContentByTitle();
                        break;
                    case "3":
                        //Add new content
                        AddNewContent();
                        break;
                    case "4":
                        // Remove content
                        RemoveContent();
                        break;
                    case "5":
                    case "exit":
                    case "EXIT":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Goodbye!");
            Thread.Sleep(2000);
            // Console.WriteLine("Press any key to exit the program... dude");
            // Console.ReadKey();
        }
        
        public void DisplayAllContents()
        {
            Console.Clear();

            List<StreamingContent> contents = _repo.GetContents();

            foreach (StreamingContent content in contents)
            {
                DisplayContent(content);
            }

            ContinueMessage();
        }

        public void GetContentByTitle()
        {
            Console.Clear();
            Console.Write("Enter a title: ");
            string title = Console.ReadLine();
            
            StreamingContent content = _repo.GetContentByTitle(title);

            if(content == null)
            {
                Console.WriteLine("Content not found");
            }
            else
            {
                DisplayContent(content);
            }

            ContinueMessage();
        }

        public void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"{content.Title} ({content.MaturityRating}) - {content.Description}. {content.StarRating} {(content.StarRating == 1.0 ? "star" : "stars")}");
        }

        public void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }



        private void AddNewContent()
        {
            Console.Clear();

            StreamingContent content = new StreamingContent();

            bool isValidTitle = false;

            while (!isValidTitle)
            {
                Console.Write("Title: ");
                string title = Console.ReadLine();

                // content.Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title;

                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Please enter a valid title (press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    content.Title = title;
                    isValidTitle = true;
                }
            }

            // Description
            Console.Write("Description: ");
            string description = Console.ReadLine();
            content.Description = string.IsNullOrWhiteSpace(description) ? "(No Description)" : description;

            // Star Rating
            Console.Write("Star Rating (0-5): ");
            double stars = double.Parse(Console.ReadLine());
            if (stars > 5)
            {
                content.StarRating = 5;
            } else if (stars < 0)
            {
                content.StarRating = 0;
            }
            else
            {
                content.StarRating = stars;
            }

            // Maturity
            Console.WriteLine("1. G\n" +
                "2. PG\n" +
                "3. PG-13\n" +
                "4. R\n" +
                "5. NC17\n" +
                "6. TVMA\n" +
                "7. TVG\n" +
                "8. TVY\n");
            Console.Write("Maturity Rating: ");
            string maturityInput = Console.ReadLine();
            int matuirtyId = int.Parse(maturityInput);
            content.MaturityRating = (MaturityRating)matuirtyId;

            // Genre
            Console.WriteLine("1. SciFi\n" +
                "2. Comedy\n" +
                "3. Horror\n" +
                "4. RomCom\n" +
                "5. Documentary\n" +
                "6. Western\n" +
                "7. Action");
            Console.Write("Genre: ");
            string genreInput = Console.ReadLine();

            switch (genreInput)
            {
                case "SciFi":
                case "1":
                    content.GenreType = GenreType.SciFi;
                    break;
                case "comedy":
                case "2":
                    content.GenreType = GenreType.Comedy;
                    break;
                case "Horror":
                case "3":
                    content.GenreType = GenreType.Horror;
                    break;
                case "RomCom":
                case "4":
                    content.GenreType = GenreType.RomCom;
                    break;
                case "5":
                    content.GenreType = GenreType.Documentary;
                    break;
                case "6":
                    content.GenreType = GenreType.Western;
                    break;
                case "7":
                    content.GenreType = GenreType.Action;
                    break;
                default:
                    content.GenreType = 0;
                    break;
            }

            _repo.AddContentToDirectory(content);
        }


        private void RemoveContent()
        {
            Console.Clear();
            Console.WriteLine("Enter the title of item to remove: ");

            string title = Console.ReadLine();

            StreamingContent content = _repo.GetContentByTitle(title);

            if (content == null)
            {
                Console.WriteLine("Content not found");
            }
            else
            {
                DisplayContent(content);
                Console.WriteLine("Are you sure you want to delete this? y/n");

                string answer = Console.ReadLine();
                if (answer.ToLower() == "y" || answer.ToLower() == "yes")
                {
                    _repo.DeleteExistingContent(content);
                    Console.WriteLine("Content removed!");
                }
                else
                {
                    Console.WriteLine("Nevermin then...");
                }
            }

            ContinueMessage();
        }
    }
}
