using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infra;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        [HttpGet]
        [Route("api/product")]
        public Task<IEnumerable<Product>> Get()
        {
            return _productService.GetAll();
        }

        [HttpGet]
        [Route("api/productById")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var product = await _productService.GetById(id);
                if (product == null)
                {
                    return Json("Nenhum produto encontrado!");
                }
                return Json(product);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());

            }

        }

        [HttpPost]
        [Route("api/product")]
        public async Task<IActionResult> Post([FromBody]Product model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Name))
                    return BadRequest("Nome obrigatório");
                else if (string.IsNullOrWhiteSpace(model.Category))
                    return BadRequest("Categoria obrigatória");
                else if (model.Price <= 0)
                    return BadRequest("Preço obrigatório");

                model.CreatedOn = DateTime.UtcNow;
                await _productService.AddProduct(model);
                return Ok("Produto registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("api/product/update")]
        public async Task<IActionResult> Update([FromBody]Product model)
        {
            if (model == null)
                return BadRequest("Erro no envio do produto!");

            model.UpdatedOn = DateTime.UtcNow;
            var result = await _productService.Update(model);
            if (result)
            {
                return Ok("Produto atualizado com sucesso!");
            }
            return BadRequest("Nenhum produto encontrato!");

        }

        [HttpDelete]
        [Route("api/product")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    return BadRequest("Erro de envio de Id");
                await _productService.Remove(id);
                return Ok("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}

