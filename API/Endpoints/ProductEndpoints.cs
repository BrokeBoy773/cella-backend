using API.DTOs.ProductDTOs;
using Domain.Entities.ProductEntity;
using Domain.Entities.ProductEntity.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup("products");

            routeGroupBuilder.MapGet("", GetAllProductsAsync);
            routeGroupBuilder.MapGet("{id:guid}", GetProductByIdAsync);
            routeGroupBuilder.MapPost("", CreateProductAsync);
            routeGroupBuilder.MapPut("{id:guid}", UpdateProductAsync);
            routeGroupBuilder.MapDelete("{id:guid}", DeleteProductAsync);
        }

        private static async Task<IResult> GetAllProductsAsync([FromQuery] string? searchString, [FromQuery] string? sortItem,
                                                               [FromQuery] string? sortOrder, [FromServices] IProductService service,
                                                               CancellationToken cancellationToken)
        {
            List<Product> products = await service.GetAllProductsAsync(searchString, sortItem, sortOrder, cancellationToken);

            return Results.Ok(products.Adapt<List<ProductGetDTO>>());
        }

        private static async Task<IResult> GetProductByIdAsync([FromRoute] Guid id, [FromServices] IProductService service,
                                                               CancellationToken cancellationToken)
        {
            Product? product = await service.GetProductByIdAsync(id, cancellationToken);

            return Results.Ok(product.Adapt<ProductGetDTO>());
        }

        private static async Task<IResult> CreateProductAsync([FromBody] ProductCreateDTO productCreateDTO,
                                                              [FromServices] IProductService service,
                                                              CancellationToken cancellationToken)
        {
            await service.CreateProductAsync(productCreateDTO.Adapt<Product>(), cancellationToken);

            return Results.Created();
        }

        private static async Task<IResult> UpdateProductAsync([FromRoute] Guid id, [FromBody] ProductCreateDTO productCreateDTO,
                                                              [FromServices] IProductService service,
                                                              CancellationToken cancellationToken)
        {
            await service.UpdateProductAsync(id, productCreateDTO.Adapt<Product>(), cancellationToken);

            return Results.NoContent();
        }

        private static async Task<IResult> DeleteProductAsync([FromRoute] Guid id, [FromServices] IProductService service,
                                                              CancellationToken cancellationToken)
        {
            await service.DeleteProductAsync(id, cancellationToken);

            return Results.NoContent();
        }
    }
}
