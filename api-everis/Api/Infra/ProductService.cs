using Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra
{
    public class ProductService : IProductService
    {
        private readonly MongoRepository _repository = null;
        public ProductService(IOptions<Settings> settings)
        {
            _repository = new MongoRepository(settings);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.products.Find(x => x.Name != "").ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", id);
            return await _repository.products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddProduct(Product model)
        {
            await _repository.products.InsertOneAsync(model);
        }

        public async Task<bool> Update(Product model)
        {

            var filter = Builders<Product>.Filter.Eq("_id", model._id);
            var product = _repository.products.Find(filter).FirstOrDefaultAsync();
            if (product.Result == null)
                return false;
            var update = Builders<Product>.Update
                                          .Set(x => x.Name, model.Name)
                                          .Set(x => x.Category, model.Category)                                      
                                          .Set(x => x.Description, model.Description)
                                          .Set(x => x.Price, model.Price)
                                          .Set(x => x.Thumb, model.Thumb)
                                          .Set(x => x.UpdatedOn, model.UpdatedOn);

            await _repository.products.UpdateOneAsync(filter, update);
            return true;
        }

        public async Task<DeleteResult> Remove(string id)
        {
            var filter = Builders<Product>.Filter.Eq("_id", id);
            return await _repository.products.DeleteOneAsync(filter);
        }



    }
}
