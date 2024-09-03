using API.DTOs.CategoryDTOs;
using Domain.Entities.CategoryEntity;
using Domain.Entities.CategoryEntity.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            RouteGroupBuilder routeGroupBuilder = endpointRouteBuilder.MapGroup("categories");

            routeGroupBuilder.MapGet("", GetAllСategoriesAsync);
            routeGroupBuilder.MapPost("", CreateCategoryAsync);
            routeGroupBuilder.MapPut("{id:guid}", UpdateCategoryAsync);
            routeGroupBuilder.MapDelete("{id:guid}", DeleteCategoryAsync);
        }

        private static async Task<IResult> GetAllСategoriesAsync([FromServices] ICategoryService service,
                                                                 CancellationToken cancellationToken)
        {
            List<Category> categories = await service.GetAllСategoriesAsync(cancellationToken);

            return Results.Ok(categories.Adapt<List<CategoryGetDTO>>());
        }

        private static async Task<IResult> CreateCategoryAsync([FromBody] CategoryCreateDTO categoryCreateDTO,
                                                               [FromServices] ICategoryService service,
                                                               CancellationToken cancellationToken)
        {
            await service.CreateCategoryAsync(categoryCreateDTO.Adapt<Category>(), cancellationToken);

            return Results.Created();
        }

        private static async Task<IResult> UpdateCategoryAsync([FromRoute] Guid id, [FromBody] CategoryCreateDTO categoryCreateDTO,
                                                               [FromServices] ICategoryService service,
                                                               CancellationToken cancellationToken)
        {
            await service.UpdateCategoryAsync(id, categoryCreateDTO.Adapt<Category>(), cancellationToken);

            return Results.NoContent();
        }

        private static async Task<IResult> DeleteCategoryAsync([FromRoute] Guid id, [FromServices] ICategoryService service,
                                                               CancellationToken cancellationToken)
        {
            await service.DeleteCategoryAsync(id, cancellationToken);

            return Results.NoContent();
        }
    }
}
