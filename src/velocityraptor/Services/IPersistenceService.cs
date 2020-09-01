using System;
using velocityraptor.Model;

namespace velocityraptor.Services
{
    public interface IPersistenceService
    {
        void AddProduct(Product product);
        Product GetProduct(Guid id);
        void UpdateProject(Product product);
        Product[] GetProducts();
    }
}