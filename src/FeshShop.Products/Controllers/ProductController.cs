namespace FeshShop.Products.Controllers
{
    using FeshShop.Common.Mediator.Contracts;
    using FeshShop.Common.Mvc;
    using FeshShop.Products.Dto;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class ProductController : ApiController
    {
        public ProductController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        [Route(nameof(GetById) + PathSeparator + Id)]
        public async Task<ActionResult<GetProductViewModel>> GetById([FromRoute] GetProductInputModel model)
            => this.Single(await this.QueryAsync(model));

        [HttpPost]
        [Route(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductInputModel model)
            => await this.SendAsync(model.BindId(x => x.Id));

        [HttpPut]
        [Route(nameof(UpdateProduct) + PathSeparator + Id)]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductInputModel model)
            => await this.SendAsync(model.Bind(x => x.Id, id));

        [HttpDelete]
        [Route(nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductInputModel model)
            => await this.SendAsync(model);
    }
}
