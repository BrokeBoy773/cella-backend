using API.DTOs.StatusDTOs;
using Domain.Entities.StatusEntity;
using Domain.Entities.StatusEntity.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class StatusEndpoints
    {
        public static void MapStatusEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup("statuses");

            routeGroupBuilder.MapGet("", GetAllStatusesAsync);
            routeGroupBuilder.MapPost("", CreateStatusAsync);
            routeGroupBuilder.MapPut("{id:guid}", UpdateStatusAsync);
            routeGroupBuilder.MapDelete("{id:guid}", DeleteStatusAsync);
        }

        private static async Task<IResult> GetAllStatusesAsync([FromServices] IStatusService service,
                                                               CancellationToken cancellationToken)
        {
            List<Status> statuses = await service.GetAllStatusesAsync(cancellationToken);

            return Results.Ok(statuses.Adapt<List<StatusGetDTO>>());
        }

        private static async Task<IResult> CreateStatusAsync([FromBody] StatusCreateDTO statusCreateDTO,
                                                             [FromServices] IStatusService service,
                                                             CancellationToken cancellationToken)
        {
            await service.CreateStatusAsync(statusCreateDTO.Adapt<Status>(), cancellationToken);

            return Results.Created();
        }

        private static async Task<IResult> UpdateStatusAsync([FromRoute] Guid id, [FromBody] StatusCreateDTO statusCreateDTO,
                                                             [FromServices] IStatusService service,
                                                             CancellationToken cancellationToken)
        {
            await service.UpdateStatusAsync(id, statusCreateDTO.Adapt<Status>(), cancellationToken);

            return Results.NoContent();
        }

        private static async Task<IResult> DeleteStatusAsync([FromRoute] Guid id, [FromServices] IStatusService service,
                                                             CancellationToken cancellationToken)
        {
            await service.DeleteStatusAsync(id, cancellationToken);

            return Results.NoContent();
        }
    }
}
