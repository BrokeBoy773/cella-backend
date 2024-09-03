using API.DTOs.BrandDTOs;
using Domain.Entities.BrandEntity;
using Domain.Entities.BrandEntity.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class BrandEndpoints
    {
        public static void MapBrandEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup("brands");

            routeGroupBuilder.MapGet("", GetAllBrandsAsync);
            routeGroupBuilder.MapPost("", CreateBrandAsync);
            routeGroupBuilder.MapPut("{id:guid}", UpdateBrandAsync);
            routeGroupBuilder.MapDelete("{id:guid}", DeleteBrandAsync);
        }

        private static async Task<IResult> GetAllBrandsAsync([FromServices] IBrandService service,
                                                             CancellationToken cancellationToken)
        {
            List<Brand> brands = await service.GetAllBrandsAsync(cancellationToken);

            return Results.Ok(brands.Adapt<List<BrandGetDTO>>());
        }

        private static async Task<IResult> CreateBrandAsync([FromBody] BrandCreateDTO brandCreateDTO,
                                                            [FromServices] IBrandService service,
                                                            CancellationToken cancellationToken)
        {
            await service.CreateBrandAsync(brandCreateDTO.Adapt<Brand>(), cancellationToken);

            return Results.Created();
        }

        private static async Task<IResult> UpdateBrandAsync([FromRoute] Guid id, [FromBody] BrandCreateDTO brandCreateDTO,
                                                            [FromServices] IBrandService service,
                                                            CancellationToken cancellationToken)
        {
            await service.UpdateBrandAsync(id, brandCreateDTO.Adapt<Brand>(), cancellationToken);

            return Results.NoContent();
        }

        private static async Task<IResult> DeleteBrandAsync([FromRoute] Guid id, [FromServices] IBrandService service,
                                                            CancellationToken cancellationToken)
        {
            await service.DeleteBrandAsync(id, cancellationToken);

            return Results.NoContent();
        }
    }
}
