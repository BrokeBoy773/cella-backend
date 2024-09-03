using API.DTOs.SizeDTOs;
using Domain.Entities.SizeEntity;
using Domain.Entities.SizeEntity.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class SizeEndpoints
    {
        public static void MapSizeEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup("sizes");

            routeGroupBuilder.MapGet("", GetAllSizesAsync);
            routeGroupBuilder.MapPost("", CreateSizeAsync);
            routeGroupBuilder.MapPut("{id:guid}", UpdateSizeAsync);
            routeGroupBuilder.MapDelete("{id:guid}", DeleteSizeAsync);
        }

        private static async Task<IResult> GetAllSizesAsync([FromServices] ISizeService service,
                                                            CancellationToken cancellationToken)
        {
            List<Size> sizes = await service.GetAllSizesAsync(cancellationToken);

            return Results.Ok(sizes.Adapt<List<SizeGetDTO>>());
        }

        private static async Task<IResult> CreateSizeAsync([FromBody] SizeCreateDTO sizeCreateDTO,
                                                           [FromServices] ISizeService service,
                                                           CancellationToken cancellationToken)
        {
            await service.CreateSizeAsync(sizeCreateDTO.Adapt<Size>(), cancellationToken);

            return Results.Created();
        }

        private static async Task<IResult> UpdateSizeAsync([FromRoute] Guid id, [FromBody] SizeCreateDTO sizeCreateDTO,
                                                           [FromServices] ISizeService service,
                                                           CancellationToken cancellationToken)
        {
            await service.UpdateSizeAsync(id, sizeCreateDTO.Adapt<Size>(), cancellationToken);

            return Results.NoContent();
        }

        private static async Task<IResult> DeleteSizeAsync([FromRoute] Guid id, [FromServices] ISizeService service,
                                                           CancellationToken cancellationToken)
        {
            await service.DeleteSizeAsync(id, cancellationToken);

            return Results.NoContent();
        }
    }
}
