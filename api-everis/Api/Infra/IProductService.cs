using Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(string id);
        Task AddProduct(Product model);
        Task<bool> Update(Product model);
        Task<DeleteResult> Remove(string id);

    }
}
