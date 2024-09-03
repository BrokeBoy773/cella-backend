using Domain.Entities.CategoryEntity;
using Domain.Entities.CategoryEntity.Interfaces;

namespace Application.Services
{
    public class CategoryService(ICategoryRepository repository) : ICategoryService
    {
        private readonly ICategoryRepository _repository = repository;

        public async Task<List<Category>> GetAllСategoriesAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllСategoriesAsync(cancellationToken);
        }

        public async Task<Category?> CreateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            Category newCategory = new()
            {
                Id = Guid.NewGuid(),
                Name = category.Name,
            };

            return await _repository.CreateCategoryAsync(newCategory, cancellationToken);
        }

        public async Task<Guid> UpdateCategoryAsync(Guid id, Category category, CancellationToken cancellationToken)
        {
            Category newCategory = new()
            {
                Id = id,
                Name = category.Name,
            };

            return await _repository.UpdateCategoryAsync(id, newCategory, cancellationToken);
        }

        public async Task<Guid> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCategoryAsync(id, cancellationToken);
        }
    }
}
