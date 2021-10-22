namespace FeshShop.Products.Controllers
{
    using FeshShop.Common.Mvc;
    using FeshShop.Products.Dto;
    using FeshShop.Products.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService) => this.productService = productService;

        [HttpGet]
        [Route(nameof(GetById) + PathSeparator + Id)]
        public async Task<ActionResult<GetProductViewModel>> GetById([FromRoute] Guid id)
            => this.Single(await this.productService.GetProductByIdAsync(id));


        [HttpPost]
        [Route(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductInputModel model)
        {
            model.BindId(x => x.Id);
            await this.productService.CreateProductAsync(model);

            return this.Accepted();
        }

        [HttpPut]
        [Route(nameof(UpdateProduct) + PathSeparator + Id)]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductInputModel model)
        {
            await this.productService.UpdateProductAsync(id, model);

            return this.Accepted();
        }
    }
}
