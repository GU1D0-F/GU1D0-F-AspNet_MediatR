namespace AspNet_MediatR_Demo.ViewModels
{
    public record CollectionResponse<TResponse>(IEnumerable<TResponse> Items, int TotalCount);
}
