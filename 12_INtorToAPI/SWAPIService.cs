﻿using _12_INtorToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _12_INtorToAPI
{
    public class SWAPIService
    {
        private readonly HttpClient _client = new HttpClient();
        private string _urlBase;

        public SWAPIService(string urlBase)
        {
            _urlBase = urlBase;
        }

        //CRUD
        //C
        public async Task<Person> GetPersonAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Person person = await response.Content.ReadAsAsync<Person>();
                return person;
            }
            return null;
        }

        public async Task<Person> GetPersonByIdAsync(string id)
        {
            return await GetPersonAsync(_urlBase + "people/" + id);
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Vehicle vehicle = await response.Content.ReadAsAsync<Vehicle>();
                return vehicle;
            }
            return default;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default;
        }


        public async Task<SearchResult<Person>> GetPersonSearchAsync(string query)
        {
            HttpResponseMessage response = await _client.GetAsync(_urlBase + "people/?search=" + query);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<Person>>();
            }
            return default;
        }

        // Make a generic search method that could work for Person, vehicle, or any other type we make

        public async Task<SearchResult<T>> GenericSearchAsync<T>(string category, string query)
        {
            HttpResponseMessage response = await _client.GetAsync(_urlBase + category + "/?search=" + query);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<T>>();
            }
            return default;
        }

        public async Task<SearchResult<Vehicle>> GetVehicleSearchAsync(string query)
        {
            return await GenericSearchAsync<Vehicle>("vehicles", query);
        }
    }
}
