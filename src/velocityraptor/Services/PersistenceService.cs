using System;
using System.IO;
using Newtonsoft.Json;
using velocityraptor.Model;
using velocityraptor.Services;

namespace velocityraptor.Controllers
{
    public class PersistenceService : IPersistenceService
    {
        public void AddProduct(Product product)
        {
            if (File.Exists(product.Id + ".json"))
            {
                throw new InvalidOperationException("Project already exists");
            }
            JsonSerializer.Create().Serialize(new StreamWriter(product.Id + ".json",false),product);
        }

        public Product GetProduct(Guid id)
        {
            using var fs = File.OpenRead(id + ".json");
            return JsonSerializer.Create().Deserialize<Product>(new JsonTextReader(new StreamReader(fs)));
        }

        public void UpdateProject(Product product)
        {
            if (!File.Exists(product.Id + ".json"))
            {
                throw new InvalidOperationException("Project doesn't exists");
            }
            JsonSerializer.Create().Serialize(new StreamWriter(product.Id + ".json", false), product);
        }
    }
}