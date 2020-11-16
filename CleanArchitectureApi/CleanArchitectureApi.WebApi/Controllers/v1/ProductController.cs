using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureApi.Application.Exceptions;
using CleanArchitectureApi.Application.Features.Products.Commands;
using CleanArchitectureApi.Application.Features.Products.Commands.CreateProduct;
using CleanArchitectureApi.Application.Features.Products.Commands.DeleteProductById;
using CleanArchitectureApi.Application.Features.Products.Commands.UpdateProduct;
using CleanArchitectureApi.Application.Features.Products.Queries.GetAllProducts;
using CleanArchitectureApi.Application.Features.Products.Queries.GetProductById;
using CleanArchitectureApi.Application.Filters;
using CleanArchitectureApi.Application.Interfaces.Repositories;
using CleanArchitectureApi.Application.Wrappers;
using CleanArchitectureApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitectureApi.WebApi.Controllers.v1
{
   // [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        private readonly IProductRepositoryAsync _productRepository;
        public ProductController(IProductRepositoryAsync productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllProductsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Response<Product>> Get(int id)
        {
            //  return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new ApiException($"Product Not Found.");
            return new Response<Product>(product);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
    }
}
