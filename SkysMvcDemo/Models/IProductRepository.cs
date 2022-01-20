using System.Collections.Generic;

namespace SkysMvcDemo.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            return new[]
            {
                new Product{ Id=1, Name="Banan", Price=12 },
                new Product{ Id=2, Name="Mugg", Price=120 },
                new Product{ Id=3, Name="Telefon", Price=22 },
            };
        }
    }
}