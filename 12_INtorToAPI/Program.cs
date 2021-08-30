using _12_INtorToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _12_INtorToAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            // var response = client.GetAsync("https://swapi.dev/api/people/8/");
            HttpResponseMessage response = client.GetAsync("https://swapi.dev/api/people/4/").Result;
            
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                string contentString = content.ReadAsStringAsync().Result;
                //Console.WriteLine(contentString);

                Person Person = content.ReadAsAsync<Person>().Result;
                Console.WriteLine($"{Person.Name}: {Person.Height, 3}cm, {Person.Mass, 3}kg,");

                foreach(string vehicleUrl in Person.Vehicles)
                {
                    HttpResponseMessage vehicleMessage = client.GetAsync(vehicleUrl).Result;

                    Vehicle vehicle = vehicleMessage.Content.ReadAsAsync<Vehicle>().Result;
                    Console.WriteLine($"Name: {vehicle.Name}\nModel: {vehicle.Model}\nCost:{vehicle.Cost_In_Credits}\n");
                }
            }
            Console.ReadKey();
            Console.Clear();

            SWAPIService service = new SWAPIService("https://swapi.dev/api/");

            while (true)
            {
                Console.Write("Enter an Id: ");
                string id = Console.ReadLine();

                if (id == "no")
                {
                    break;
                }


                Person person2 = service.GetPersonByIdAsync(id).Result;

                Console.WriteLine(person2.Name);

                foreach (string vehicleUrl in person2.Vehicles)
                {
                    var vehicle = service.GetAsync<Vehicle>(vehicleUrl).Result;
                    Console.WriteLine($"    {vehicle.Name, 30}");
                }

                Console.ReadKey();
            }

            Console.WriteLine("Search for a vehicle? ");
            string query = Console.ReadLine();
            var results = service.GetVehicleSearchAsync(query).Result.Results;

            Console.WriteLine($"{results.Count} vehicles found:");

            foreach(Vehicle vehicle in results)
            {
                Console.WriteLine($"{vehicle.Name}, {vehicle.Model}\n");
            }

            Console.ReadKey();
        }
    }
}
