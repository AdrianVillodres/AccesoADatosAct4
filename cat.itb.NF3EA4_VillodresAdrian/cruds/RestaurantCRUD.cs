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
            var restaurantCollection = database.GetCollection<Restaurant>("restaurant");

            var results = restaurantCollection.Aggregate()
                .Unwind("Grades")
                .Group(new BsonDocument
                {
            { "_id", "Grades.score" },
            { "count", new BsonDocument("$sum", 1) }
                })
                .Sort("{_id: 1}");
            var fresults = results.ToList();

            foreach (var result in fresults)
            {
                Console.WriteLine("hola");
                Console.WriteLine($"Score: {result["_id"]}, Count: {result["count"]}");
            }
        }
    }
}
