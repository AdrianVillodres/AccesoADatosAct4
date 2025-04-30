using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using UF3_test.connections;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using cat.itb.M6UF3EA2_sol.model;

namespace cat.itb.NF3EA3_VillodresAdrian.cruds
{
    public class ProductCRUD
    {
        //metode per carregar la colecció
        public void LoadProductsCollection()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            database.DropCollection("products");

            var collection = database.GetCollection<Product>("products");

            FileInfo file = new FileInfo("../../../files/products.json");

            using (StreamReader sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product product = JsonConvert.DeserializeObject<Product>(line);

                    if (ObjectId.TryParse(product._id, out var objectId))
                    {
                        product._id = objectId.ToString();
                    }
                    else
                    {
                        product._id = ObjectId.GenerateNewId().ToString();
                    }

                    collection.InsertOne(product);
                    Console.WriteLine(product.Name);
                }
            }
        }
    }        

}
