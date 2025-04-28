using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using cat.itb.M6UF3EA2_sol.model;
using cat.itb.NF3EA1_VillodresAdrian.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using UF3_test.connections;

namespace cat.itb.NF3EA4_VillodresAdrian.cruds
{
    public class CountryCRUD
    {
        public void LoadCountriesCollection()
        {
            FileInfo file = new FileInfo("../../../files/countries.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();

            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(fileString);

            var database = MongoLocalConnection.GetDatabase("itb");
            database.DropCollection("countries");
            var collection = database.GetCollection<Country>("countries");

            if (countries != null)
            {
                collection.InsertMany(countries);
                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }

        public void CountEnglishCountries()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var countriesCollection = database.GetCollection<Country>("countries");

            var matchFilter = Builders<Country>.Filter.ElemMatch(country => country.Languages, language => language.Name == "English");

            AggregateCountResult result = countriesCollection.Aggregate()
                .Match(matchFilter)
                .Count()
                .Single();

            Console.WriteLine(result.Count);
        }

        public void SelectMostPoblatedRegion()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var countriesCollection = database.GetCollection<Country>("countries");

            var aggregate = countriesCollection.Aggregate()
                .Group(x => x.Region, g => new
                {
                    Region = g.Key,
                    TotalPopulation = g.Sum(x => (long)x.Population)
                })
                .SortByDescending(g => g.TotalPopulation)
                .Limit(1);

            var mostPopulatedRegion = aggregate.FirstOrDefault();

            Console.WriteLine($"La regió més poblada és: {mostPopulatedRegion.Region}");
        }

        public void CountCountriesSubregions()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var countriesCollection = database.GetCollection<Country>("countries");

            var aggregate = countriesCollection.Aggregate()
                .Group(x => x.Subregion, g => new
                {
                    Subregion = g.Key, 
                    CountryCount = g.Count()
                })
                .SortByDescending(g => g.CountryCount)
                .ToList();

            foreach (var item in aggregate)
            {
                Console.WriteLine($"Subregió: {item.Subregion}, Número de paísos: {item.CountryCount}");
            }
        }

        public void SelectMostSpeakLanguagesCountry()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var countriesCollection = database.GetCollection<Country>("countries");

            var aggregate = countriesCollection.Aggregate()
                .Project(x => new
                {
                    Name = x.Name,
                    LanguageCount = x.Languages.Count
                })
                .SortByDescending(x => x.LanguageCount)
                .Limit(1);

            var mostLanguagesCountry = aggregate.FirstOrDefault();

            Console.WriteLine($"El país amb més idiomes és: {mostLanguagesCountry.Name} amb {mostLanguagesCountry.LanguageCount} idiomes.");

        }
    }
}
