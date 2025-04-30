using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.M6UF3EA2_sol.model;
using cat.itb.NF3EA1_VillodresAdrian.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using UF3_test.connections;

namespace cat.itb.NF3EA4_VillodresAdrian.cruds
{
    public class RestaurantCRUD
    {
        public void LoadRestaurantsCollection()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            database.DropCollection("restaurants");

            var collection = database.GetCollection<Restaurant>("restaurants");

            FileInfo file = new FileInfo("../../../files/restaurants.json");

            using (StreamReader sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Restaurant restaurants = JsonConvert.DeserializeObject<Restaurant>(line);

                    if (ObjectId.TryParse(restaurants._id, out var objectId))
                    {
                        restaurants._id = objectId.ToString();
                    }
                    else
                    {
                        restaurants._id = ObjectId.GenerateNewId().ToString();
                    }

                    collection.InsertOne(restaurants);
                    Console.WriteLine(restaurants.Name);
                }
            }
        }

        public void SelectRestaurantScores()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var restaurantCollection = database.GetCollection<Restaurant>("restaurants");

            var results = restaurantCollection.Aggregate()
                .Unwind("grades")
                .Group(new BsonDocument
                {
                    { "_id", "$grades.score" },
                    { "count", new BsonDocument("$sum", 1) }
                })
                .Sort(new BsonDocument("_id", 1))
                .ToList();

            foreach (var result in results)
            {
                var score = result["_id"];
                var count = result["count"];

                Console.WriteLine($"Score: {score}, Count: {count}");
            }
        }


        public void SelectBoroughtZipCodes()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var restaurantCollection = database.GetCollection<Restaurant>("restaurants");

            var results = restaurantCollection.Aggregate()
                .Group(r => r.Borough, g => new
                {
                    Borough = g.Key,
                    ZipCodes = g.Select(r => r.Address.Zipcode).Where(z => z != null).Distinct().ToList()
                })
                .ToList();

            foreach (var result in results)
            {
                var borough = result.Borough;
                Console.WriteLine($"Borough: {borough}");
                foreach (var zipcode in result.ZipCodes)
                {
                    Console.WriteLine($"  Zipcode: {zipcode}");
                }
            }
        }


        public void CountRestaurantsByCuisine()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var restaurantCollection = database.GetCollection<Restaurant>("restaurants");

            var results = restaurantCollection.Aggregate()
                .Group(r => r.Cuisine, g => new
                {
                    Cuisine = g.Key,
                    Count = g.Count()
                })
                .SortBy(r => r.Count)
                .ToList();

            foreach (var result in results)
            {
                var cuisine = result.Cuisine;
                Console.WriteLine($"Cuisine: {cuisine}, Count: {result.Count}");
            }
        }



        public void CountRestaurantGrades()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var restaurantCollection = database.GetCollection<Restaurant>("restaurants");

            var results = restaurantCollection.Aggregate()
                .Project(r => new
                {
                    Name = r.Name,
                    RatingsCount = r.Grades.Count
                })
                .ToList();

            foreach (var result in results)
            {
                Console.WriteLine($"Restaurant: {result.Name}, Ratings Count: {result.RatingsCount}");
            }
        }



        public void SelectRestaurantNamesByCuisineAndBorought()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var restaurantCollection = database.GetCollection<Restaurant>("restaurants");

            var results = restaurantCollection.Aggregate()
                .Group(r => new { r.Borough, r.Cuisine }, g => new
                {
                    Borough = g.Key.Borough,
                    Cuisine = g.Key.Cuisine,
                    RestaurantNames = g.Select(r => r.Name).ToList()
                })
                .SortBy(r => r.Borough)
                .SortBy(r => r.Cuisine)
                .ToList();

            foreach (var result in results)
            {
                Console.WriteLine($"Borough: {result.Borough}, Cuisine: {result.Cuisine}");
                foreach (var name in result.RestaurantNames)
                {
                    Console.WriteLine($"    {name}");
                }
            }
        }


        public void SelectHigherScore()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var restaurantCollection = database.GetCollection<Restaurant>("restaurants");

            var results = restaurantCollection.Aggregate()
                .Unwind("grades")
                .Group(new BsonDocument
                {
            { "_id", "$name" },
            { "highestScore", new BsonDocument("$max", "$grades.score") }
                })
                .Sort(new BsonDocument { { "highestScore", -1 } })
                .ToList();

            foreach (var result in results)
            {
                var name = result["_id"].AsString;
                var score = result["highestScore"].AsInt32;
                Console.WriteLine($"Restaurant: {name}, Highest Score: {score}");
            }
        }





    }
}
