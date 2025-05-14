namespace DevExpressExpenseControl.Services.ExpenseControlApi.Interfaces;

public interface ICategoryService
{
    ValueTask<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest request,CancellationToken cancellationToken);
    ValueTask<DeleteCategoryResponse> DeleteCategoryAsync(DeleteCategoryRequest request,CancellationToken cancellationToken);
    ValueTask<ListCategoryResponse> ListCategoriesAsync(ListCategoryRequest request,CancellationToken cancellationToken);
}