using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.M6UF3EA2_sol.model;
using cat.itb.NF3EA1_VillodresAdrian.Model;
using MongoDB.Bson;
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
                }
            }
        }
    }
}
