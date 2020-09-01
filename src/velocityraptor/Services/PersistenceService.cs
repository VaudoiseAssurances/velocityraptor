using System;
using System.IO;
using System.Linq;
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

            var jsonContent = JsonConvert.SerializeObject(product);
            File.WriteAllText(product.Id + ".json", jsonContent);
        }

        public Product GetProduct(Guid id)
        {
            using var fs = File.OpenRead(id + ".json");
            using var reader = new StreamReader(fs);
            return JsonSerializer.Create().Deserialize<Product>(new JsonTextReader(reader));
        }

        public void UpdateProject(Product product)
        {
            if (!File.Exists(product.Id + ".json"))
            {
                throw new InvalidOperationException("Project doesn't exists");
            }
            JsonSerializer.Create().Serialize(new StreamWriter(product.Id + ".json", false), product);
        }

        public Product[] GetProducts()
        {
            var files = new DirectoryInfo(".").GetFiles("????????-????-????-????-????????????.json");
            var products = files.Select(o => GetProduct(Guid.Parse(o.Name.Substring(0,o.Name.Length - o.Extension.Length))))
                .ToArray();
            return products;
        }
    }
}